﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form_derleri6_double_örnekleri
{
    public partial class fibonacci : Form
    {
        public fibonacci()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sayi1 = 1;
            int sayi2 = 1;
            int sayi3;

            for (int i = 0; i < 8; i++) 
            {
                sayi3 = sayi1+sayi2;

                sayi1 = sayi2;
                sayi2 = sayi3;

                listBox1.Items.Add(sayi3);





            }


        }
    }
}
