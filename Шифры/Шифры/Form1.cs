using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Шифры
{
    public partial class Form1 : Form
    {
        Cezar Me = new Cezar();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = Me.Codeс(textBox1.Text, (int)numericUpDown1.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = Me.Codeс(textBox2.Text, -(int)numericUpDown1.Value);
        }
    }

    class Clent
    {
        string le;

        public Clent(string m)
        {
            le = m;
        }

        public string Repl(string m, int key) //замена символа m на символ со смещением
        {
            int pos = le.IndexOf(m);
            if (pos == -1) return ""; //символ в этой ленте не найден
            pos = (pos + key) % le.Length; //если смещение больше одного круга
            if (pos < 0) pos += le.Length;
            return le.Substring(pos, 1);
        }
    }

    class Cezar : System.Collections.Generic.List<Clent>
    {
        public Cezar()
        { //в конструкторе формирую коллекцию лент
            this.Add(new Clent("abcdefghijklmnopqrstuvwxyz"));
            this.Add(new Clent("ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
            this.Add(new Clent("абвгдеёжзийклмнопрстуфхцчшщъыьэюя"));
            this.Add(new Clent("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"));
            this.Add(new Clent("0123456789"));
            this.Add(new Clent("!\"#$%^&*()+=-_'?.,|/`~№:;@[]{}"));
        }

        public string Codeс(string m, int key) //кодирование и декодирование в зависимости от знака ключа
        {
            string res = "", tmp = "";
            for (int i = 0; i < m.Length; i++)
            {
                foreach (Clent v in this)
                {
                    tmp = v.Repl(m.Substring(i, 1), key);
                    if (tmp != "") //нужная лента найдена, замена символу определена
                    {
                        res += tmp;
                        break; // прерывается foreach (перебор лент)
                    }
                }
                if (tmp == "") res += m.Substring(i, 1); //незнакомый символ оставляю без изменений
            }
            return res;
        }
    }
}
