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
            workers[0] =new Worker(new string[] {"Zbieranie nektaru", "Wytwarzanie miodu"});
            workers[1] = new Worker(new string[] { "Troska o jaja", "Nauczanie pszczół" });
            workers[2] = new Worker(new string[] { "Utrzymywanie ula", "Patrol z żądłami"});
            workers[3] = new Worker(new string[] {"Zbieranie nektaru", "Wytwarzanie miodu", "Troska o jaja", "Nauczanie pszczół", "Utrzymywanie ula", "Patrol z żądłąmi"});
            _queen= new Queen(workers);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _queen.AssignWork(comboBox1.Text, (int)numericUpDown1.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = _queen.WorkTheNextShift();
        }
    }
}
