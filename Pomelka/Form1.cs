using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pomelka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                string name = textBox1.Text;
                int age = (int)numericUpDown1.Value;
                User user1 = new User { Name = name, Age = age };


                db.Users.AddRange(user1);
                db.SaveChanges();
            }
            // получение данных
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                label1.Text = "";
                foreach (User u in users)
                {
                    label1.Text += $"{u.Id}.{u.Name} - {u.Age}\n";
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
