using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace oop6
{
    public partial class Form1 : Form
    {
        public Numbers set1 = new Numbers();

        public class Number
        {
            public string Name { get; set; }
            public int Number1 { get; set; }
            public int Number2 { get; set; }
            public int Addition { get; set; }
            public int Subtraction { get; set; }
            public Number(string N, int nm1, int nm2)
            {
                Name = N; Number1 = nm1; Number2 = nm2; Addition = GetAddition(); Subtraction = GetSubtraction();
            }

            public int GetAddition()
            {
                return Number1 + Number2;
            }

            public int GetSubtraction()
            {
                return Number1 - Number2;
            }
        }

        public class Numbers : ArrayList, ITypedList
        {
            public PropertyDescriptorCollection
            GetItemProperties(PropertyDescriptor[] listAccessors)
            {
                return TypeDescriptor.GetProperties(typeof(Number));
            }
            public string GetListName(PropertyDescriptor[] listAccessors)
            {
                return "Numbers";
            }

        }

        public Form1()
        {
            InitializeComponent();
            set1.Add(new Number("Example 1", 5, 11));
            set1.Add(new Number("Example 2", 13, 123));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = set1;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Number n = new Number(textBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox3.Text));
            set1.Add(n);
            (BindingContext[set1] as CurrencyManager).Refresh();
        }
    }
}
