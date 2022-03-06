using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathModelir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Button[,] cell;
        bool doc = false;
        int x, y;

        private void button1_Click(object sender, EventArgs e)
        {
            RemoveCellFromPanel();

            x = Convert.ToInt32(numericUpDown1.Value);
            y = Convert.ToInt32(numericUpDown2.Value);
            cell = new Button[x, y];

            for(int i = 0; i < x; i++)
            {
                for(int q = 0; q < y; q++)
                {
                    cell[i, q] = new Button();
                    cell[i, q].FlatStyle = FlatStyle.Flat;
                    cell[i, q].Size = new Size(25, 25);
                    cell[i, q].Location = new Point(i * 25, q * 25);
                    cell[i, q].Tag = 3;
                    cell[i, q].BackColor = Color.White;
                    cell[i, q].Click += new EventHandler(Cell_Click);
                    panel1.Controls.Add(cell[i, q]);
                }
            }
        }

        private void RemoveCellFromPanel()
        {
            if(cell != null)
            {
                foreach (var cells in cell)
                {
                    if (cells != null)
                    {
                        panel1.Controls.Remove(cells);
                    }
                }
            }
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            Button cells = sender as Button;

            if (Convert.ToInt32(cells.Tag) == 3)
            {
                cells.Tag = 2;
                cells.BackColor = Color.Black;
            }

            else if (Convert.ToInt32(cells.Tag) == 2)
            {
                cells.Tag = 3;
                cells.BackColor = Color.White;
            }

        }

        int[,] lifecell;

        private void Checked()
        {
            for(int i = 0; i < x; i++)
            {
                for(int q = 0; q < y; q++)
                {
                    if (Convert.ToInt32(cell[i, q].Tag) == 2)
                    {
                        if (lifecell[i, q] <= 1 || lifecell[i, q] >= 4)
                        {
                            cell[i, q].Tag = 1;
                            cell[i, q].BackColor = Color.Red;
                        }
                    }

                    else if (Convert.ToInt32(cell[i, q].Tag) == 3)
                    {
                        if(lifecell[i, q] == 3)
                        {
                            cell[i, q].Tag = 0;
                            cell[i, q].BackColor = Color.Yellow;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(doc)
            {
                doc = false;

                for(int i = 0; i < x; i++)
                {
                    for(int q = 0; q < y; q++)
                    {
                        if (Convert.ToInt32(cell[i, q].Tag) == 0)
                        {
                            cell[i, q].Tag = 2;
                            cell[i, q].BackColor = Color.Black;
                        }

                        else if (Convert.ToInt32(cell[i, q].Tag) == 1)
                        {
                             cell[i, q].Tag = 3;
                             cell[i, q].BackColor = Color.White;
                        }
                    }
                }
            }

            else if (!doc)
            {
                doc = true;

                if (radioButton1.Checked) //Мур
                {
                    lifecell = new int[x, y];

                    for (int i = 0; i < x; i++)
                    {
                        for (int q = 0; q < y; q++)
                        {
                            lifecell[i, q] = 0;

                            if (i - 1 != -1)
                            {
                                if (Convert.ToInt32(cell[i - 1, q].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (i - 1 != -1 && q - 1 != -1)
                            {
                                if (Convert.ToInt32(cell[i - 1, q - 1].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (i + 1 <= x - 1 && q - 1 != -1)
                            {
                                if (Convert.ToInt32(cell[i + 1, q - 1].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (i - 1 != -1 && q + 1 <= y - 1)
                            {
                                if (Convert.ToInt32(cell[i - 1, q + 1].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (i + 1 <= x - 1 && q + 1 <= y - 1)
                            {
                                if (Convert.ToInt32(cell[i + 1, q + 1].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (q - 1 != -1)
                            {
                                if (Convert.ToInt32(cell[i, q - 1].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (q + 1 <= y - 1)
                            {
                                if (Convert.ToInt32(cell[i, q + 1].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (i + 1 <= x - 1)
                            {
                                if (Convert.ToInt32(cell[i + 1, q].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }
                        }
                    }
                    Checked();
                }

                if (radioButton2.Checked) // Фон-Нейман
                {
                    lifecell = new int[x, y];

                    for(int i = 0; i < x; i++)
                    {
                        for(int q = 0; q < y; q++)
                        {
                            lifecell[i, q] = 0;

                            if(i - 1 != -1)
                            {
                                if(Convert.ToInt32(cell[i - 1, q].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (q - 1 != -1)
                            {
                                if (Convert.ToInt32(cell[i, q - 1].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (i + 1 <= x - 1)
                            {
                                if (Convert.ToInt32(cell[i + 1, q].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (q + 1 <= y - 1)
                            {
                                if (Convert.ToInt32(cell[i, q + 1].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                        }
                    }
                    Checked();
                }
            }

            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (doc)
            {
                doc = false;

                for (int i = 0; i < x; i++)
                {
                    for (int q = 0; q < y; q++)
                    {
                        if (Convert.ToInt32(cell[i, q].Tag) == 0)
                        {
                            cell[i, q].Tag = 2;
                            cell[i, q].BackColor = Color.Black;
                        }

                        else if (Convert.ToInt32(cell[i, q].Tag) == 1)
                        {
                            cell[i, q].Tag = 3;
                            cell[i, q].BackColor = Color.White;
                        }
                    }
                }
            }

            else if (!doc)
            {
                doc = true;

                if (radioButton1.Checked) //Мур
                {
                    lifecell = new int[x, y];

                    for (int i = 0; i < x; i++)
                    {
                        for (int q = 0; q < y; q++)
                        {
                            lifecell[i, q] = 0;

                            if (i - 1 != -1)
                            {
                                if (Convert.ToInt32(cell[i - 1, q].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (i - 1 != -1 && q - 1 != -1)
                            {
                                if (Convert.ToInt32(cell[i - 1, q - 1].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (i + 1 <= x - 1 && q - 1 != -1)
                            {
                                if (Convert.ToInt32(cell[i + 1, q - 1].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (i - 1 != -1 && q + 1 <= y - 1)
                            {
                                if (Convert.ToInt32(cell[i - 1, q + 1].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (i + 1 <= x - 1 && q + 1 <= y - 1)
                            {
                                if (Convert.ToInt32(cell[i + 1, q + 1].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (q - 1 != -1)
                            {
                                if (Convert.ToInt32(cell[i, q - 1].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (q + 1 <= y - 1)
                            {
                                if (Convert.ToInt32(cell[i, q + 1].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (i + 1 <= x - 1)
                            {
                                if (Convert.ToInt32(cell[i + 1, q].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }
                        }
                    }
                    Checked();
                }

                if (radioButton2.Checked) // Фон-Нейман
                {
                    lifecell = new int[x, y];
                    for (int i = 0; i < x; i++)
                    {
                        for (int q = 0; q < y; q++)
                        {
                            lifecell[i, q] = 0;

                            if (i - 1 != -1)
                            {
                                if (Convert.ToInt32(cell[i - 1, q].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (q - 1 != -1)
                            {
                                if (Convert.ToInt32(cell[i, q - 1].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (i + 1 <= x - 1)
                            {
                                if (Convert.ToInt32(cell[i + 1, q].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                            if (q + 1 <= y - 1)
                            {
                                if (Convert.ToInt32(cell[i, q + 1].Tag) == 2)
                                {
                                    lifecell[i, q]++;
                                }
                            }

                        }
                    }
                    Checked();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button1.Enabled = true;
            timer1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = Convert.ToInt32(numericUpDown4.Value);
        }

    }
}
