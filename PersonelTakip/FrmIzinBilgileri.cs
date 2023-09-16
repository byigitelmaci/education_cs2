using DAL1.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL1;
using BLL1;

namespace PersonelTakip
{
    public partial class FrmIzinBilgileri : Form
    {
        public FrmIzinBilgileri()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        TimeSpan sure = new TimeSpan();
        private void FrmIzinBilgileri_Load(object sender, EventArgs e)
        {
            txtUserNo.Text=UserStatic.UserNo.ToString();
        }

        private void dpbaslama_ValueChanged(object sender, EventArgs e)
        {
            sure = dpbitis.Value.Date - dpbaslama.Value.Date;
            txtsure.Text = sure.TotalDays.ToString();
        }

        private void dpbitis_ValueChanged(object sender, EventArgs e)
        {
            sure = dpbitis.Value.Date - dpbaslama.Value.Date;
            txtsure.Text = sure.TotalDays.ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtsure.Text.Trim() == "")
                MessageBox.Show("Süre Boş");
            else if (Convert.ToInt32(txtsure.Text)<=0)
                MessageBox.Show("İzin Süresi Geçersiz");
            else if (txtaciklama.Text.Trim()=="")
                MessageBox.Show("Lütfen Açıklama Giriniz");
            else
            {
                IZIN iz = new IZIN();
                iz.PersonelID=UserStatic.PersonelID;
                iz.IzinDurumID = 1;
                iz.IzinBaslamaTarihi = dpbaslama.Value;
                iz.IzinBitisTarihi = dpbaslama.Value;
                iz.Sure=Convert.ToInt32(sure.TotalDays);
                iz.Acıklama = txtaciklama.Text;
                IzinBLL.IzinEkle(iz);
                MessageBox.Show("İzin Eklendi");
                dpbaslama.Value = DateTime.Today;
                dpbitis.Value = DateTime.Today;
                txtsure.Clear();
                txtaciklama.Clear();
            }
        }

        private void txtaciklama_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
