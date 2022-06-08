using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WF_txtEditor
{
    public partial class Form1 : Form
    {
        public int type = 0;
        public Form1()
        {
            InitializeComponent();
        }
        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBox1.Text, fontDialog1.Font, Brushes.Black, 0, 0);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.* ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                string fileText = File.ReadAllText(path);
                textBox1.Text = fileText;
            }
            else return;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                File.WriteAllText(path, textBox1.Text);
            }
            else return;
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;
            fontDialog1.ShowDialog();
            textBox1.ForeColor = fontDialog1.Color;
            textBox1.Font = fontDialog1.Font;
        }

        private void цветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textBox1.BackColor = colorDialog1.Color;
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintPageHandler;
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument.Print();
        }

        private void поверхВсехОконToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (поверхВсехОконToolStripMenuItem.Checked == true)
            {
                TopMost = true;
            }
            else
            {
                TopMost = false;
            }
        }

        private void статусБарToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (статусБарToolStripMenuItem.Checked == true)
            {
                statusStrip1.Visible = true;
            }
            else
            {
                statusStrip1.Visible = false;
            }
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }
        private void ВернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Redo();
        }
        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        { 
                textBox1.SelectedText = "";
        }


        private void открытьToolStripButton_Click(object sender, EventArgs e)
        {
            удалитьToolStripMenuItem.Enabled = textBox1.SelectionLength > 0;
            вырезатьToolStripMenuItem.Enabled = textBox1.SelectionLength > 0;
            копироватьToolStripMenuItem.Enabled = textBox1.SelectionLength > 0;
            отменитьToolStripMenuItem.Enabled = textBox1.Text.Length > 0;
            найтиToolStripMenuItem.Enabled = textBox1.Text.Length > 0;
            заменитьToolStripMenuItem.Enabled = textBox1.Text.Length > 0;
        }

        private void выделитьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void времяИДатаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString(" dd.MM.yyyy HH:mm:ss ");
            textBox1.AppendText(time);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    DialogResult dialogResult = MessageBox.Show("Вы хотите сохранить изменения?\n",
                                                "Блокнот",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            string path = saveFileDialog1.FileName;
                            File.WriteAllText(path, textBox1.Text);
                        }
                        else return;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        Application.Exit();
                    }
                }
            }
        }

        private void найтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            type = 1;
            form2.button2.Visible = false;
            form2.button4.Location = new Point(258, 40);
            form2.label2.Visible = false;
            form2.txt_change.Visible = false;
            form2.StartPosition = FormStartPosition.CenterParent;
            form2.Owner = this;
            form2.ShowDialog();
        }

        private void заменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            type = 2;
            form2.Text = "Заменить";
            form2.StartPosition = FormStartPosition.CenterParent;
            form2.Owner = this;
            form2.ShowDialog(this);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.StartPosition = FormStartPosition.CenterParent;
            form3.ShowDialog(this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.* ";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                string fileText = File.ReadAllText(path);
                textBox1.Text = fileText;
            }
            else return;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                File.WriteAllText(path, textBox1.Text);
            }
            else return;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintPageHandler;
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument.Print();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            textBox1.Redo();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            type = 1;
            form2.button2.Visible = false;
            form2.button4.Location = new Point(258, 40);
            form2.label2.Visible = false;
            form2.txt_change.Visible = false;
            form2.StartPosition = FormStartPosition.CenterParent;
            form2.Owner = this;
            form2.ShowDialog();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            type = 2;
            form2.Text = "Заменить";
            form2.StartPosition = FormStartPosition.CenterParent;
            form2.Owner = this;
            form2.ShowDialog(this);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string txtLength = textBox1.Text.Length.ToString();
            toolStripStatusLabel1.Text = txtLength;
            if (textBox1.Text=="")
            {
                toolStripButton12.Enabled = false;
                toolStripButton13.Enabled = false;
                toolStripButton5.Enabled = false;
                toolStripButton6.Enabled = false;
            }
            else
            {
                toolStripButton12.Enabled = true;
                toolStripButton13.Enabled = true;
                toolStripButton5.Enabled = true;
                toolStripButton6.Enabled = true;
            }
        }
    }
}
