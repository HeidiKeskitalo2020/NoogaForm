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
using System.Diagnostics;

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
        public class Payroll
        {
            public string Date { get; set; }
            public string PersonId { get; set; }
            public string RegisteredHours { get; set; }
            public string MysteryValue { get; set; }
            public string FiftyPercent { get; set; }
            public string HundredPercent { get; set; }
            public string HolidayFiftyP { get; set; }
            public string HolidayHundredP { get; set; }
            public string XValue { get; set; }
            public string NightWorkExtra { get; set; }
            public string DayHours { get; set; }
            public string EveningHours { get; set; }
            public string PValue { get; set; }
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
            StreamReader sr = new StreamReader(@"C:\Nooga\src\bin\Debug\netcoreapp3.1\Työtunnit.txt");
            StreamWriter writer = new StreamWriter(@"C:\Nooga\src\bin\Debug\netcoreapp3.1\Salary.txt");
            string data = sr.ReadLine();
            while (data != null)
            {
                string repData = data.Replace(".", ",");
                //Console.WriteLine(repData);
                data = sr.ReadLine();

                writer.WriteLine(repData);

            }
            writer.Close();
            Console.WriteLine("");
            Console.WriteLine("Commas replaced to file (¨Salary.txt)");
            Console.WriteLine("");


            string filePath = @"C:\Nooga\src\bin\Debug\netcoreapp3.1\Salary.txt";

            List<Payroll> pay = new List<Payroll>();
            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (var line in lines)
            {
                //string tab = "\t";
                string[] entries = line.Split('\t');
                Payroll newPayroll = new Payroll();

                newPayroll.Date = entries[0];
                newPayroll.PersonId = entries[1];
                newPayroll.RegisteredHours = entries[2];
                newPayroll.MysteryValue = entries[3];
                newPayroll.FiftyPercent = entries[4];
                newPayroll.HundredPercent = entries[5];
                newPayroll.HolidayFiftyP = entries[6];
                newPayroll.HolidayHundredP = entries[7];
                newPayroll.XValue = entries[8];
                newPayroll.NightWorkExtra = entries[9];
                newPayroll.DayHours = entries[10];
                newPayroll.EveningHours = entries[11];
                newPayroll.PValue = entries[12];

                if (entries.Length == 14)
                {
                    pay.Add(newPayroll);
                }
                else
                {
                    Console.WriteLine("Missing PayValue, or too much");
                }
            }
            List<string> outContent = new List<string>();
            foreach (var payroll in pay)
            {
                Console.WriteLine($"{payroll.PersonId} \t {payroll.Date} \t 1 \t {payroll.RegisteredHours}");
                //Console.WriteLine($"{payroll.PersonId} \t {payroll.Date} \t D \t {payroll.MysteryValue}");
                Console.WriteLine($"{payroll.PersonId} \t {payroll.Date} \t 95 \t {payroll.FiftyPercent}");
                Console.WriteLine($"{payroll.PersonId} \t {payroll.Date} \t 96 \t {payroll.HundredPercent}");
                Console.WriteLine($"{payroll.PersonId} \t {payroll.Date} \t 97 \t {payroll.HolidayFiftyP}");
                Console.WriteLine($"{payroll.PersonId} \t {payroll.Date} \t 98 \t {payroll.HolidayHundredP}");
                //Console.WriteLine($"{payroll.PersonId} \t {payroll.Date} \t I \t {payroll.XValue}");
                Console.WriteLine($"{payroll.PersonId} \t {payroll.Date} \t 8 \t {payroll.NightWorkExtra}");
                //Console.WriteLine($"{payroll.PersonId} \t {payroll.Date} \t K \t {payroll.DayHours}");
                Console.WriteLine($"{payroll.PersonId} \t {payroll.Date} \t 7 \t {payroll.EveningHours}");
                //Console.WriteLine($"{payroll.PersonId} \t {payroll.Date} \t M \t {payroll.PValue}");

                outContent.Add($"{payroll.PersonId} \t {payroll.Date} \t 1 \t {payroll.RegisteredHours}");
                //outContent.Add($"{payroll.PersonId} \t {payroll.Date} \t D \t {payroll.MysteryValue}");
                outContent.Add($"{payroll.PersonId} \t {payroll.Date} \t 95 \t {payroll.FiftyPercent}");
                outContent.Add($"{payroll.PersonId} \t {payroll.Date} \t 96 \t {payroll.HundredPercent}");
                outContent.Add($"{payroll.PersonId} \t {payroll.Date} \t 97 \t {payroll.HolidayFiftyP}");
                outContent.Add($"{payroll.PersonId} \t {payroll.Date} \t 98 \t {payroll.HolidayHundredP}");
                //outContent.Add($"{payroll.PersonId} \t {payroll.Date} \t I \t {payroll.XValue}");
                outContent.Add($"{payroll.PersonId} \t {payroll.Date} \t 8 \t {payroll.NightWorkExtra}");
                //outContent.Add($"{payroll.PersonId} \t {payroll.Date} \t K \t {payroll.DayHours}");
                outContent.Add($"{payroll.PersonId} \t {payroll.Date} \t 7 \t {payroll.EveningHours}");
                //outContent.Add($"{payroll.PersonId} \t {payroll.Date} \t M \t {payroll.PValue}");

            }
            string folder = @"C:\Nooga\src\bin\Debug\netcoreapp3.1\Salary.txt";
            File.WriteAllLines(folder, outContent);

            //Console.WriteLine("");
            //Console.WriteLine("Commas replaced to file (Commas.txt)");
            Console.WriteLine("");
            Console.WriteLine("Data written to file (Salary.txt)");

            Console.ReadLine();
            
            //textBox2.Text = outContent;
            LabelMessage.Text = "Data written\nto file (Salary.txt)";
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
            label3.Text = "Data saved";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/HeidiKeskitalo2020/PalkkaForm/blob/master/Palkka/Ty%C3%B6tunnit.txt");
        }
    }
}
