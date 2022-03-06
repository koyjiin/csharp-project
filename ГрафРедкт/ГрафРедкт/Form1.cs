using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ГрафРедкт
{
    public partial class Form1 : Form
    {
        Color color = Color.Black;
        bool isPressed = false;
        Point CurrentPoint;
        Point PrevPoint;
        Graphics g;
        ColorDialog colorDialog = new ColorDialog();

        public Form1()
        {
            InitializeComponent();
            label2.BackColor = Color.Black;
            g = panel1.CreateGraphics();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog.Color;
                label2.BackColor = colorDialog.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        private void my_Pen()
        {
            Pen pen = new Pen(color, (float)numericUpDown1.Value);
            g.DrawLine(pen, CurrentPoint, PrevPoint);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            CurrentPoint = e.Location;
        }
            
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(isPressed)
            {
                PrevPoint = CurrentPoint;
                CurrentPoint = e.Location;
                my_Pen();
            }
        }
    }
}
