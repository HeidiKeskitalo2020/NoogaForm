using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Palkka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        OpenFileDialog ofd = new OpenFileDialog();

        private void button1_Click(object sender, EventArgs e)
        {
            
            ofd.Filter = "*TXT|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(ofd.SafeFileName);
                textBox1.Text = ofd.SafeFileName;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = System.IO.File.ReadAllText(ofd.FileName);
            LabelMessage.Text = "Data written\nto file (Palkat.txt)";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter(@"C:\Nooga\src\bin\Debug\netcoreapp3.1\Työtunnit.txt");
            {
                string data = System.IO.File.ReadAllText(ofd.FileName);
                writer.WriteLine(data);
            }
            writer.Close();           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
