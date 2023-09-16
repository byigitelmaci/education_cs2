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
    public partial class FrmIzinListesi : Form
    {
        public FrmIzinListesi()
        {
            InitializeComponent();
        }

       

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtsure_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            FrmIzinBilgileri frm = new FrmIzinBilgileri();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            combofull = false;
            doldur();
            temizle();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            FrmIzinBilgileri frm = new FrmIzinBilgileri();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            combofull = false;
            doldur();
            temizle();
            
        }
        IzinDTO dto = new IzinDTO();
        private bool combofull;

        void doldur()
        {
            dto = IzinBLL.GetAll();
            dataGridView1.DataSource = dto.Izinler;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "User No";
            dataGridView1.Columns[2].HeaderText = "Ad";
            dataGridView1.Columns[3].HeaderText = "Soyad";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "Başlama Tarihi";
            dataGridView1.Columns[9].HeaderText = "Bitiş Tarihi";
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false; 
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
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
            cmbizindurum.DataSource = dto.Izindurumlar;
            cmbizindurum.DisplayMember = "IzinDurumAd";
            cmbizindurum.ValueMember = "ID";
            cmbizindurum.SelectedIndex = -1;
        }
        private void FrmIzinListesi_Load(object sender, EventArgs e)
        {

            doldur();
        }

        private void cmbdepartman_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                int departmanID = Convert.ToInt32(cmbdepartman.SelectedValue);
                cmbpozisyon.DataSource = dto.Pozisyonlar.Where(x => x.DepartmanID == departmanID).ToList();
            }
        }
        List<IzinDetayDTO> listt = new List<IzinDetayDTO>();
        private void btnAra_Click(object sender, EventArgs e)
        {
            listt = dto.Izinler;
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

            if (rbbaslamatarihi.Checked)
                listt=listt.Where(x => x.BaslamaTarihi>=Convert.ToDateTime(dpbaslama.Value)
                && x.BaslamaTarihi<Convert.ToDateTime(dpbitis.Value)).ToList();
            if (rbbitistarihi.Checked)
                listt = listt.Where(x => x.BitisTarihi >= Convert.ToDateTime(dpbaslama.Value)
                && x.BitisTarihi < Convert.ToDateTime(dpbitis.Value)).ToList();
            if (cmbizindurum.SelectedIndex != -1)
                listt = listt.Where(x => x.IzinDurumID == Convert.ToInt32(cmbizindurum.SelectedValue)).ToList();
            if (txtsure.Text.Trim() != "")
                listt = listt.Where(X => X.Sure==Convert.ToInt32(txtsure.Text)).ToList();

            dataGridView1.DataSource = listt;
        }

        void temizle()
        {
            txtadı.Clear();
            txtsoyad.Clear();
            txtUserNo.Clear();
            cmbdepartman.SelectedIndex = -1;
            cmbpozisyon.DataSource = dto.Pozisyonlar;
            cmbpozisyon.SelectedIndex = -1;
            dataGridView1.DataSource = dto.Izinler;
            rbbaslamatarihi.Checked = false;
            rbbitistarihi.Checked = false;
            txtsure.Clear();
            cmbizindurum.SelectedIndex = -1;
            dpbaslama.Value = DateTime.Today;
            dpbitis.Value = DateTime.Today;
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
        

        
    }
}
