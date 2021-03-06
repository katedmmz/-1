using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лабораторная_1
{
    public partial class Form1 : Form
    {
        private string filePath; //путь к файлу
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Название файла (.txt)| .txt";
            colorDialog1.Color = this.BackColor;
            colorDialog1.FullOpen = true;
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = saveFileDialog1.FileName;
            File.WriteAllText(fileName, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
                richTextBox1.Copy();
        }

        private void вставитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Cut();
                
            }   
                

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = dialog.FileName;
                    richTextBox1.Text = File.ReadAllText(filePath); // в тексбоксе откроется файл
                }
            }
           
                
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FontDialog dialog = new FontDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionFont = dialog.Font;
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath)) // если нет пути к файлу
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = dialog.FileName;
                        File.WriteAllText(filePath, richTextBox1.Text);
                    }
                    File.WriteAllText(filePath, richTextBox1.Text);
                }
            }
        }

        private void переносПоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            переносПоToolStripMenuItem.Checked = !переносПоToolStripMenuItem.Checked;
            richTextBox1.WordWrap = переносПоToolStripMenuItem.Checked;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void времяИДатаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += DateTime.Now;
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PrintDialog dialog = new PrintDialog())
            {
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        printDocument1.Print();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка параметров печати.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void справкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutbox = new AboutBox1();
            aboutbox.Show();
        }

        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            richTextBox1.BackColor = colorDialog1.Color;
        }
    }
}
