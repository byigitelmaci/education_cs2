﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ders_18_Algoritmik_Örnekler
{
    public partial class algoritmik_örnekler_2 : Form
    {
        public algoritmik_örnekler_2()
        {
            InitializeComponent();
        }

        private void temizle()
        {
            textBox1.Clear();
        }

        int tektoplam = 0;
        int cifttoplam = 0;


        private void button1_Click(object sender, EventArgs e)
        {
            int sayi;
            sayi=Convert.ToInt32(textBox1.Text);
            temizle();
            if (sayi %2== 0) 
            {
                cifttoplam = sayi + cifttoplam;
                label4.Text=cifttoplam.ToString();
            }
            if (sayi %2== 1)
            {
                tektoplam = tektoplam + sayi;
                label3.Text=tektoplam.ToString();
            }
        }
    }
}
