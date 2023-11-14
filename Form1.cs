using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            listBox2.BeginUpdate();

            string[] Strings = richTextBox1.Text.Split(new char[] {'\n', '\t', ' '}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in Strings)
            {
                string Str = s.Trim();

                if (Str == String.Empty) continue;
                if (radioButton1.Checked) listBox2.Items.Add(Str);
                if (radioButton2.Checked)
                {
                    if (Regex.IsMatch(Str, @"\d")) listBox2.Items.Add(Str);
                }
                if (radioButton3.Checked)
                {
                    if (Regex.IsMatch(Str, @"\w+@\w+\.\w+")) listBox2.Items.Add(Str);
                }
            }
            listBox2.EndUpdate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            richTextBox1.Text = string.Empty;

            textBox1.Text = string.Empty; 

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

            checkBox1.Checked = false;
            checkBox2.Checked = false;


        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            MessageBox.Show("Информация о приложении и разработчике.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            string Find = textBox1.Text;

            if (checkBox1.Checked)
            {
                foreach (string String in listBox2.Items)
                {
                    if (String.Contains(Find)) listBox1.Items.Add(String);
                }
            }
            if (checkBox2.Checked)
            {
                foreach (string String in listBox3.Items)
                {
                    if (String.Contains(Find)) listBox1.Items.Add(String);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 AddRec = new Form2();

            AddRec.Owner = this;
            AddRec.ShowDialog();
        }
               
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(OpenDlg.FileName, Encoding.Default);
                richTextBox1.Text = reader.ReadToEnd();
                reader.Close();
            }
            OpenDlg.Dispose();
        }

        private void сохранитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            if (SaveDlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Writer = new StreamWriter(SaveDlg.FileName);
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    Writer.WriteLine((string)listBox2.Items[i]);
                }
                Writer.Close();
            }
            SaveDlg.Dispose();
        }

        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
            MessageBox.Show("Информация о приложении и разработчике.");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(listBox3.Items);
            listBox3.Items.Clear();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            listBox3.Items.AddRange(listBox2.Items);
            listBox2.Items.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox3.BeginUpdate();

            foreach (object Item in listBox2.SelectedItems)
            {
                listBox3.Items.Add(Item);
            }

            listBox3.EndUpdate();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox2.BeginUpdate();
            foreach (object Item in listBox3.SelectedItems)
            {
                listBox2.Items.Add(Item);
            }
            listBox2.EndUpdate();

            listBox3.Items.Remove(listBox3.SelectedItems);
        }
    }
}
