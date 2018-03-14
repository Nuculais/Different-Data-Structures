using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Heap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MinHeap<int> liten = new MinHeap<int>(50);
        PriorityQueue<int, int> stor = new PriorityQueue<int, int>();

        private void button1_Click(object sender, EventArgs e)
        {
            int add = Convert.ToInt32(textBox2.Text);
            liten.Add(add);
            textBox1.Text = liten.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int remove = Convert.ToInt32(textBox2.Text);
            liten.Remove(remove);
            textBox1.Text = liten.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int enqueueNumber = Convert.ToInt32(textBox4.Text);
                int enqueueOrder = Convert.ToInt32(textBox5.Text);
                stor.Enqueue(enqueueNumber, enqueueOrder);

                textBox3.Text = stor.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Både ett värde och en prioritet behövs.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int dequeueItem = Convert.ToInt32(textBox4.Text);
            stor.Dequeue();
            textBox3.Text = stor.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {           
            textBox6.Text = stor.Peek().ToString();
        }
    }
}
