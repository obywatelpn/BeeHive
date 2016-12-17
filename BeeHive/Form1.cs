using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeeHive
{
    public partial class Form1 : Form
    {
        private Queen _queen;

        public Form1()
        {
            InitializeComponent();
            Worker[] workers = new Worker[4];
            workers[0] =new Worker(new string[] {"Zbieranie nektaru", "Wytwarzanie miodu"}, 175);
            workers[1] = new Worker(new string[] { "Troska o jaja", "Nauczanie pszczół" }, 114);
            workers[2] = new Worker(new string[] { "Utrzymywanie ula", "Patrol z żądłami"}, 149);
            workers[3] = new Worker(new string[] {"Zbieranie nektaru", "Wytwarzanie miodu", "Troska o jaja", "Nauczanie pszczół", "Utrzymywanie ula", "Patrol z żądłąmi"}, 155);
            _queen = new Queen(workers, 275);
            comboBox1.SelectedItem = "Zbieranie nektaru";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_queen.AssignWork(comboBox1.Text, (int) numericUpDown1.Value) == false)
            {
                MessageBox.Show("Nie ma dostępnych robotnic do wykonania zadania '" + comboBox1.Text + "'",
                    "Królowa pszczół mówi...");
            }
            else
            {
                MessageBox.Show($"Zadanie '{comboBox1.Text}' będzie ukończone za {numericUpDown1.Value} zmiany",
                    "Królowa pszczół mówi...");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = _queen.WorkTheNextShift();
        }
    }
}
