using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhanVien
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ListViewItem data = listView.Items.Add(txtTen.Text);
            data.SubItems.Add(dtpNgaySinh.Value.ToShortDateString());
            data.SubItems.Add(txtSDT.Text);
            data.SubItems.Add(txtDiaChi.Text);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                listView.Items.Remove(listView.SelectedItems[0]);
            }
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Checked)
                    item.Remove();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                listView.SelectedItems[0].SubItems[0].Text = txtTen.Text;
                listView.SelectedItems[0].SubItems[1].Text = dtpNgaySinh.Value.ToShortDateString();
                listView.SelectedItems[0].SubItems[2].Text = txtSDT.Text;
                listView.SelectedItems[0].SubItems[3].Text = txtDiaChi.Text;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                txtTen.Text = listView.SelectedItems[0].SubItems[0].Text;
                dtpNgaySinh.Text = listView.SelectedItems[0].SubItems[1].Text;
                txtSDT.Text = listView.SelectedItems[0].SubItems[2].Text;
                txtDiaChi.Text = listView.SelectedItems[0].SubItems[3].Text; }
        }
    }
}
