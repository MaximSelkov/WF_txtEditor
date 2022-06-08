using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_txtEditor
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = this.Owner as Form1;
            if (form1.textBox1.Text.Contains(txt_search.Text))
            {
                form1.textBox1.SelectionStart = form1.textBox1.Text.IndexOf(txt_search.Text);
                form1.textBox1.SelectionLength = txt_search.Text.Length;
                form1.textBox1.Focus();
            }
            else
            {
                MessageBox.Show("Такая строка не содержится в тексте", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = this.Owner as Form1;
            if (form1.textBox1.Text.Contains(txt_search.Text))
            {
                form1.textBox1.SelectedText = form1.textBox1.SelectedText.Replace(form1.textBox1.SelectedText,txt_change.Text);
            }
            else
            {
                MessageBox.Show("Такая строка не содержится в тексте", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
