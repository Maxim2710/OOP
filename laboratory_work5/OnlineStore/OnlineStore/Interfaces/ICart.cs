using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Interfaces
{
    public interface ICart
    {
        IUser User { get; }
        List<IProduct> Products { get; }

        void AddProduct(IProduct product);
        void RemoveProduct(IProduct product);
        decimal GetTotalPrice();
    }
}
