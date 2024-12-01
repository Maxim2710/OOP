namespace OnlineStore.ViewModels
{
    using OnlineStore.Commands;
    using OnlineStore.Facades;
    using OnlineStore.Models;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Input;

    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly StoreFacade _storeFacade;

        public ObservableCollection<IProduct> AvailableProducts { get; set; }
        public ObservableCollection<IProduct> CartProducts { get; set; }

        private IProduct _selectedProduct;
        public IProduct SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private decimal _total;
        public decimal Total
        {
            get => _total;
            set
            {
                _total = value;
                OnPropertyChanged(nameof(Total));
            }
        }

        public ICommand AddToCartCommand { get; }
        public ICommand RemoveFromCartCommand { get; }
        public ICommand CreateOrderCommand { get; }

        public MainViewModel()
        {
            _storeFacade = new StoreFacade();

            AvailableProducts = new ObservableCollection<IProduct>();
            for (int i = 0; i < 60; i++)
            {
                AvailableProducts.Add(new Product($"Product {i + 1}", 100m + (i % 10) * 50));
            }

            CartProducts = new ObservableCollection<IProduct>();

            AddToCartCommand = new RelayCommand(AddToCart, CanAddToCart);
            RemoveFromCartCommand = new RelayCommand(RemoveFromCart, CanRemoveFromCart);
            CreateOrderCommand = new RelayCommand(CreateOrder, CanCreateOrder);
        }

        private void AddToCart(object parameter)
        {
            if (SelectedProduct != null)
            {
                _storeFacade.AddProductToCart(SelectedProduct);
                CartProducts.Add(SelectedProduct);
                AvailableProducts.Remove(SelectedProduct);
                UpdateTotal();
            }
        }

        private bool CanAddToCart(object parameter) => SelectedProduct != null;

        private void RemoveFromCart(object parameter)
        {
            if (parameter is IProduct product)
            {
                _storeFacade.RemoveProductFromCart(product);
                CartProducts.Remove(product);
                AvailableProducts.Add(product);
                UpdateTotal();
            }
        }

        private bool CanRemoveFromCart(object parameter) => SelectedProduct != null && CartProducts.Contains(SelectedProduct);

        private void CreateOrder(object parameter)
        {
            var order = _storeFacade.CreateOrder();
            CartProducts.Clear();
            UpdateTotal();
            // Можно добавить дополнительную логику для отображения или обработки заказа
        }

        private bool CanCreateOrder(object parameter) => CartProducts.Any();

        private void UpdateTotal()
        {
            Total = _storeFacade.GetCartTotal();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
