namespace WinFormsTask1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyPress += text_changed;
            buttonClear.Click += buttonClear_Click; // Добавляем обработчик нажатия на кнопку
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void text_changed(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            // Если это управляющий символ (например, Backspace)
            if (char.IsControl(c))
            {
                textBox1.BackColor = Color.White;
                return;
            }
            // Проверка на запятую и точку
            if ((c == '.' || c == ',') && (textBox1.Text.Contains(".") || textBox1.Text.Contains(",") || textBox1.Text.Length == 0))
            {
                textBox1.BackColor = Color.Yellow; // Цвет для некорректного ввода
                e.Handled = true;
                return;
            }
            // Проверка на минус
            if (c == '-' && (textBox1.Text.Length > 0 || textBox1.Text.Contains("-")))
            {
                textBox1.BackColor = Color.Yellow; // Цвет для некорректного ввода
                e.Handled = true;
                return;
            }
            // Проверка на допустимые символы
            if (!char.IsDigit(c) && c != '.' && c != ',' && c != '-')
            {
                textBox1.BackColor = Color.Yellow; // Цвет для некорректного ввода
                e.Handled = true;
            }
            textBox1.BackColor = Color.White;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); // Очистить текстовое поле
            textBox1.BackColor = Color.White; // Вернуть цвет фона в норму
        }
    }
}
