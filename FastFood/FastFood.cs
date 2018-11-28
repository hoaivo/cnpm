using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFood
{
    public partial class FastFood : Form
    {
        public DataTable table = new DataTable();
        public FastFood()
        {
            InitializeComponent();
        }

        void CreateColumn(DataTable tbOrder)
        {
            tbOrder.Columns.Add("FoodName");
            tbOrder.Columns.Add("Quantity");
            tbOrder.PrimaryKey = new DataColumn[] { tbOrder.Columns["FoodName"] };
        }

        private void FastFood_Load(object sender, EventArgs e)
        {
            CreateColumn(table);
            dataGridView1.DataSource = table;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            bool kt = false;
            foreach (DataRow s in table.Rows)
                if (btn.Text == s["Foodname"].ToString())
                {
                    s["Quantity"] = int.Parse(s["Quantity"].ToString()) + 1;
                    kt = true;
                }
            if (kt == false)
            {
                DataRow r = table.NewRow();
                table.Rows.Add(btn.Text, 1);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                var a = dataGridView1.CurrentRow.Cells[0].Value;
                DataRow r = table.Rows.Find(a);
                if (r != null)
                {
                    if (int.Parse(r["Quantity"].ToString()) == 1)
                        table.Rows.Remove(r);
                    else
                        r["Quantity"] = int.Parse(r["Quantity"].ToString()) - 1;
                }
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            table.Rows.Clear();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
                MessageBox.Show("Đã gửi Order tới nhà bếp", "Hoàn Thành");
            else
                MessageBox.Show("Bạn phải chọn ít nhất 1 món ăn!", "Thông báo");
        }
    }
}
