﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDEMY_BLL_ders_73
{
    public partial class FrmMaasListesi : Form
    {
        public FrmMaasListesi()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FrmMaasBilgileri frm = new FrmMaasBilgileri();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FrmMaasBilgileri frm = new FrmMaasBilgileri();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }
    }
}
