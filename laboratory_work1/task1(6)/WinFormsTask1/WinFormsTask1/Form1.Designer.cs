namespace WinFormsTask1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            buttonClear = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(46, 72);
            textBox1.Margin = new Padding(5, 5, 5, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1023, 39);
            textBox1.TabIndex = 0;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(46, 143);
            buttonClear.Margin = new Padding(5, 5, 5, 5);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(162, 48);
            buttonClear.TabIndex = 1;
            buttonClear.Text = "Очистить";
            buttonClear.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(1164, 627);
            Controls.Add(textBox1);
            Controls.Add(buttonClear);
            Margin = new Padding(5, 5, 5, 5);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox textBox1;
        private Button buttonClear;

#endregion
    }
}
