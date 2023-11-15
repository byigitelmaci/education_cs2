using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL1.DTO;
using BLL1;

namespace PersonelTakip
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btncıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            if (!UserStatic.isAdmin)
            {
                FrmPersonelBilgileri frm = new FrmPersonelBilgileri();
                PersonelDTO dto = new PersonelDTO();
                dto = PersonelBLL.GetAll();
                PersonelDetayDTO detay = new PersonelDetayDTO();
                detay = dto.Personeller.First(x => x.PersoneID == UserStatic.PersonelID);
                frm.isUpdate = true;
                frm.detay = detay;
                frm.ShowDialog();
                this.Visible= true;

            }
            else
            {
                FrmPersonelListesi frm = new FrmPersonelListesi();
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
            }
            
        }

        private void btnisler_Click(object sender, EventArgs e)
        {
            FrmIsListesi frm = new FrmIsListesi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnmaas_Click(object sender, EventArgs e)
        {
            FrmMaasListesi frm = new FrmMaasListesi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnizin_Click(object sender, EventArgs e)
        {
            FrmIzinListesi frm = new FrmIzinListesi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btndepartman_Click(object sender, EventArgs e)
        {
            FrmDepartmanListesi frm = new FrmDepartmanListesi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnpozisyon_Click(object sender, EventArgs e)
        {
            FrmPozisyonListesi frm = new FrmPozisyonListesi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnoturumukapat_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (!UserStatic.isAdmin)
            {
                btndepartman.Visible = false;
                btnpozisyon.Visible = false;
                btnoturumukapat.Location = new Point(232, 158);
                btncıkıs.Location=new Point (400, 158);

            }

        }
    }
}
