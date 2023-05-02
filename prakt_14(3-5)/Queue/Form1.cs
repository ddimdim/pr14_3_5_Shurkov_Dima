using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace prakt14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Queue nums = new Queue();
            int n = Convert.ToInt32(numericUpDown1.Value);
            for (int i = 1; i <= n; i++)
            {
                nums.Enqueue(i);
            }
            while (nums.Count > 0)
            {
                int num = Convert.ToInt32(nums.Dequeue());
                listBox1.Items.Add(num);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Queue people1 = new Queue();
            Queue people2 = new Queue();
            StreamReader sr = File.OpenText("fio.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] info = line.Split(' ');
                string surname = info[0];
                string name = info[1];
                string otchestvo = info[2];
                int age = Convert.ToInt32(info[3]);
                int weight = Convert.ToInt32(info[4]);
                if (age < 40)
                    people1.Enqueue($"{surname} {name} {otchestvo} {age} {weight}");
                else
                    people2.Enqueue($"{surname} {name} {otchestvo} {age} {weight}");
            }
            foreach (string str in people1)
            {
                listBox2.Items.Add(str);
            }
            foreach (string str in people2)
            {
                listBox2.Items.Add(str);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            Queue<string> people = new Queue<string>();
            Queue<string> sort_people = new Queue<string>();
            StreamReader sr = File.OpenText("fio.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                people.Enqueue(line);
            }
            sort_people = new Queue<string>(people.OrderBy(sort => Convert.ToInt32(sort.Split()[3])));
            foreach (string str in sort_people)
            {
                listBox3.Items.Add(str);
            }
        }
    }
}
