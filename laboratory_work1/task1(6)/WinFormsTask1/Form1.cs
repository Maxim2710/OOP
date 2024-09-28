namespace WinFormsTask1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyPress += text_changed;
            buttonClear.Click += buttonClear_Click; // ��������� ���������� ������� �� ������
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void text_changed(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            // ���� ��� ����������� ������ (��������, Backspace)
            if (char.IsControl(c))
            {
                textBox1.BackColor = Color.White;
                return;
            }
            // �������� �� ������� � �����
            if ((c == '.' || c == ',') && (textBox1.Text.Contains(".") || textBox1.Text.Contains(",") || textBox1.Text.Length == 0))
            {
                textBox1.BackColor = Color.Yellow; // ���� ��� ������������� �����
                e.Handled = true;
                return;
            }
            // �������� �� �����
            if (c == '-' && (textBox1.Text.Length > 0 || textBox1.Text.Contains("-")))
            {
                textBox1.BackColor = Color.Yellow; // ���� ��� ������������� �����
                e.Handled = true;
                return;
            }
            // �������� �� ���������� �������
            if (!char.IsDigit(c) && c != '.' && c != ',' && c != '-')
            {
                textBox1.BackColor = Color.Yellow; // ���� ��� ������������� �����
                e.Handled = true;
            }
            textBox1.BackColor = Color.White;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); // �������� ��������� ����
            textBox1.BackColor = Color.White; // ������� ���� ���� � �����
        }
    }
}
