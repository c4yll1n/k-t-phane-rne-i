using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kutuphane_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=kutuphane.mdb");
        string kimlik_no;   


        void verileriGoster()
        {
            conn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM kitaplar", conn);
            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dataGridView1.DataSource = dt;

            conn.Close();
        }


      

        private void button1_Click(object sender, EventArgs e)
        {
            verileriGoster();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string sorgu = "INSERT INTO kitaplar (adi,yazar_adi,sayfa_sayisi,konum,tur) " +
                               "VALUES ('" + textBox1.Text + "','" + textBox2.Text + "'," + textBox3.Text + ",'" + textBox4.Text + "','" + textBox5.Text + "')";

                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sorgu, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                verileriGoster();

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            verileriGoster();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult basilan_buton;

            basilan_buton = MessageBox.Show("silinecek Emin misin?","UYARI !",MessageBoxButtons.YesNo);

            if(basilan_buton == DialogResult.Yes)
            {
                // Kimlik Alanına göre silme kodu
                string sorgu = "DELETE FROM kitaplar WHERE Kimlik=" + kimlik_no;

                OleDbCommand sql_komut = new OleDbCommand(sorgu, conn);

                conn.Open();
                sql_komut.ExecuteNonQuery();
                conn.Close();

                verileriGoster();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu =  "UPDATE kitaplar " +
                            "SET yazar_adi='"+textBox11.Text+"', sayfa_sayisi='"+textBox10.Text+"',konum='"+textBox9.Text+"', tur='"+textBox8.Text+"'" +
                            "WHERE Kimlik = "+kimlik_no;


            OleDbCommand sql_guncelle = new OleDbCommand(sorgu,conn);

            conn.Open();
            sql_guncelle.ExecuteNonQuery();
            conn.Close();

            verileriGoster();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("deneme");
        }

        private void textBox10_MouseHover(object sender, EventArgs e)
        {
            label13.Visible = true;
        }

        private void textBox10_MouseLeave(object sender, EventArgs e)
        {
            label13.Visible = false;    
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            label13.Visible = true;
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            label13.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            kimlik_no = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
