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
using System.Collections;


namespace PersonelTakip
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

        private void button11_Click(object sender, EventArgs e)
        {
            FrmMaasBilgileri frm = new FrmMaasBilgileri();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            combofull = false;
            doldur();
            Temizle();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            FrmMaasBilgileri frm = new FrmMaasBilgileri();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            combofull = false;
            doldur();
            Temizle();
        }
        MaasDTO dto = new MaasDTO();
        private bool combofull;

        private void FrmMaasListesi_Load(object sender, EventArgs e)
        {
            doldur();

        }

        private void doldur()
        {
            dto = MaasBLL.GetAll();
            dataGridView1.DataSource = dto.Maaslar;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "User No";
            dataGridView1.Columns[2].HeaderText = "Ad";
            dataGridView1.Columns[3].HeaderText = "Soyad";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "Yıl";
            dataGridView1.Columns[9].HeaderText = "Ay";
            dataGridView1.Columns[10].HeaderText = "Maaş";
            dataGridView1.Columns[11].Visible = false;
            cmbdepartman.DataSource = dto.Departmanlar;
            cmbdepartman.DisplayMember = "DepartmanAd";
            cmbdepartman.ValueMember = "ID";
            cmbdepartman.SelectedIndex = -1;
            if (dto.Departmanlar.Count > 0)
                combofull = true;
            cmbpozisyon.DataSource = dto.Pozisyonlar;
            cmbpozisyon.DisplayMember = "PozisyonAd";
            cmbpozisyon.ValueMember = "ID";
            cmbpozisyon.SelectedIndex = -1;
            cmbAylar.DataSource = dto.Aylar;
            cmbAylar.DisplayMember = "Ay";
            cmbAylar.ValueMember = "ID";
            cmbAylar.SelectedIndex = -1;
        }

        private void cmbdepartman_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                int departmanID = Convert.ToInt32(cmbdepartman.SelectedValue);
                cmbpozisyon.DataSource = dto.Pozisyonlar.Where(x => x.DepartmanID == departmanID).ToList();
            }
        }
        List<MaasDetayDTO> listt = new List<MaasDetayDTO>();
        private void btnAra_Click(object sender, EventArgs e)
        {
            listt = dto.Maaslar;
            if (txtUserNo.Text.Trim() != "")
                listt = listt.Where(X => X.UserNO == Convert.ToInt32(txtUserNo.Text)).ToList();
            if (txtadı.Text.Trim() != "")
                listt = listt.Where(X => X.Ad.Contains(txtadı.Text)).ToList();
            if (txtsoyad.Text.Trim() != "")
                listt = listt.Where(X => X.Soyad.Contains(txtsoyad.Text)).ToList();
            if (cmbdepartman.SelectedIndex != -1)
                listt = listt.Where(x => x.DepartmanID == Convert.ToInt32(cmbdepartman.SelectedValue)).ToList();
            if (cmbpozisyon.SelectedIndex != -1)
                listt = listt.Where(x => x.PozisyonID == Convert.ToInt32(cmbpozisyon.SelectedValue)).ToList();
            if (cmbAylar.SelectedIndex != -1)
                listt = listt.Where(x => x.MaasAyID == Convert.ToInt32(cmbAylar.SelectedValue)).ToList();
            if (txtyıl.Text.Trim() != "")
                listt = listt.Where(x => x.MaasYil == Convert.ToInt32(txtyıl.Text)).ToList();
            if (rbBüyük.Checked)
                listt = listt.Where(x => x.MaasMiktar > Convert.ToInt32(txtmaas.Text)).ToList();
            else if (rbKüçük.Checked)
                listt = listt.Where(x => x.MaasMiktar <  Convert.ToInt32(txtmaas.Text)).ToList();
            else if (rbEşit.Checked)
                listt = listt.Where(x => x.MaasMiktar == Convert.ToInt32(txtmaas.Text)).ToList();
            dataGridView1.DataSource= listt;
        }
        void Temizle()
        {
            dataGridView1.DataSource = dto.Maaslar;
            txtadı.Clear();
            txtmaas.Clear();
            txtsoyad.Clear();
            txtUserNo.Clear();
            txtyıl.Clear();
            cmbAylar.SelectedIndex = -1;
            cmbdepartman.SelectedIndex = -1;
            cmbpozisyon.DataSource = dto.Pozisyonlar;
            cmbpozisyon.SelectedIndex = -1;
            rbBüyük.Checked = false;
            rbEşit.Checked = false;
            rbKüçük.Checked = false;
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
