using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_WINDOW
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=BAN_HANG;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        DataTable dt;

        private void Form1_Load_1(object sender, EventArgs e)
        {
            LoadHD();
        }
        private void LoadHD()
        {
            try
            {

                ketnoi = new SqlConnection(chuoiketnoi);

                ketnoi.Open();
                sql = "select * from CHI_TIET_DAT_HANG ";
                hienthi();
                dataGridView1.DataSource = dt;
                ketnoi.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void hienthi()
        {
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.CommandType = CommandType.Text;
            docdulieu = thuchien.ExecuteReader();
            dt = new DataTable();
            dt.Load(docdulieu);

        }


        private void KhachHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void them_Click(object sender, EventArgs e)
        {
            string sohoadon = txtshd.Text;
            string mahang = txtmh.Text;
            string giaban = txtgb.Text;
            string soluong = txtsl.Text;
            string mucgiamgia = txtmgg.Text;



            // check gia tri nguời dùng nhập có đúng không - ví dụ là nhập chưa đủ thông tin:

            ketnoi.Open();

            sql = @"insert into SINH_VIEN
	        values 
            (N'" + sohoadon + "' , N'" + mahang + "' , N'" + giaban + "'  , N'" + soluong + ", N'" + mucgiamgia + "')";
            MessageBox.Show("THÊM THÀNH CÔNG!!");

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();

            ketnoi.Close();
        }

        private void them_Click_1(object sender, EventArgs e)
        {
            //private void them_Click_1(object sender, EventArgs e)
            {
                string sohoadon = txtshd.Text;
                string mahang = txtmh.Text;
                string giaban = txtgb.Text;
                string soluong = txtsl.Text;
                string mucgiamgia = txtmgg.Text;
                int soLuongInt;
                if (int.TryParse(soluong, out soLuongInt))
                    // Kiểm tra giá trị người dùng nhập có đúng không - ví dụ là nhập chưa đủ thông tin

                    ketnoi.Open();

                string sql = @"INSERT INTO CHI_TIET_DAT_HANG (SoHoaDon, MaHang, GiaBan, SoLuong, MucGiamGia)
                   VALUES (N'" + sohoadon + "', N'" + mahang + "', N'" + giaban + "', N'" + soluong + "', N'" + mucgiamgia + "')";
                Console.WriteLine(sql);
                SqlCommand thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();

                ketnoi.Close();

                LoadHD();
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Lấy tất cả thông tin muốn thêm
            string sohoadon = txtshd.Text;
            string mahang = txtmh.Text;
            string giaban = txtgb.Text;
            string soluong = txtsl.Text;
            string mucgiamgia = txtmgg.Text;

           



            // check gia tri nguời dùng nhập có đúng không - ví dụ là nhập chưa đủ thông tin:

            ketnoi.Open();

            sql = @"insert into CHI_TIET_DAT_HANG
	        values 
            (N'" + sohoadon + "' , N'" + mahang + "' , N'" + giaban + "'  , N'" + soluong + "',N'"+ mucgiamgia+"')";
            MessageBox.Show("THÊM THÀNH CÔNG!!");

            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();

            ketnoi.Close();

            LoadHD();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                string hoadonCanXoa = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                ketnoi.Open();
                string lenhxoa = "delete from CHI_TIET_DAT_HANG where SoHoaDon ='" + hoadonCanXoa + "'";

                thuchien = new SqlCommand(lenhxoa, ketnoi);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();

                LoadHD();
            }
        }
    }
}