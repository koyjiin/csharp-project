using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ТекстРедкт
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                openFileDialog1.FileName = @"*.txt";
                openFileDialog1.Filter = "Текстовые файлы (*.txt)| *.txt| All files (*.*)|*/*";
                saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt| All files (*.*)| *.*";        
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void menuFileOpen()
        {
            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFileDialog1.FileName.Length > 0)
            {
                try
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
                }
                catch
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
                this.Text = "Файл [" + openFileDialog1.FileName + "]";
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuFileOpen();
        }

        private void menuFileSaveAs()
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFileDialog1.FileName.Length > 0)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
                this.Text = "Файл [" + saveFileDialog1.FileName + "]";
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuFileSaveAs();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuFileSaveAs();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void скопироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void отменаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void жирныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetBold();
        }

        private void SetBold()
        {
            if(richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if(richTextBox1.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                CheckMenuFontCharacterStyle();
            }
        }

        private void курсивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetItalic();
        }

        private void SetItalic()
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                CheckMenuFontCharacterStyle();

                if (richTextBox1.SelectionFont.Italic == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Italic;
                }

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                CheckMenuFontCharacterStyle();
            }
        }

        private void подчёркнутыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetUnderline();
        }

        private void SetUnderline()
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;
                CheckMenuFontCharacterStyle();

                if (richTextBox1.SelectionFont.Underline == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Underline;
                }

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                CheckMenuFontCharacterStyle();
            }
        }

        private void перечёркиваниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetStrikeout();
        }

        private void SetStrikeout()
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (richTextBox1.SelectionFont.Strikeout == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Strikeout;
                }

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                CheckMenuFontCharacterStyle();
            }
        }

        private void CheckMenuFontCharacterStyle()
        {
            if(richTextBox1.SelectionFont.Bold == true)
            {
                жирныйToolStripMenuItem.Checked = true;
            }
            else
            {
                жирныйToolStripMenuItem.Checked = false;
            }

            if (richTextBox1.SelectionFont.Italic == true)
            {
                курсивToolStripMenuItem.Checked = true;
            }
            else
            {
                курсивToolStripMenuItem.Checked = false;
            }

            if (richTextBox1.SelectionFont.Underline == true)
            {
                подчёркнутыйToolStripMenuItem.Checked = true;
            }
            else
            {
                подчёркнутыйToolStripMenuItem.Checked = false;
            }

            if (richTextBox1.SelectionFont.Strikeout == true)
            {
                перечёркиваниеToolStripMenuItem.Checked = true;
            }
            else
            {
                перечёркиваниеToolStripMenuItem.Checked = false;
            }
        }
    }
}
