﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form_dersleri_5_qeokrg_oqkerf
{
    public partial class for_döngüsü_ilk_örnek : Form
    {
        public for_döngüsü_ilk_örnek()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            for( i = 0; i < 10; i++) 
            {
                listBox1.Items.Add(i);
            }
        }
    }
}
