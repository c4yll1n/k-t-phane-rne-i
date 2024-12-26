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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kutuphane_v2
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=kutuphane.mdb");

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sql = "SELECT * FROM kullanicilar WHERE k_adi='"+textBox1.Text+"' AND parola='"+textBox2.Text+"' ";
            OleDbCommand cmd = new OleDbCommand(sql,conn);

            OleDbDataReader oku = cmd.ExecuteReader();
            
            if(oku.Read())
            {
                // MessageBox.Show("Giriş Başarılı");
                if(oku.GetString(5) == "0" ) // 0 ise müdür penceresi açılsın
                {
                    Mudur formMudur = new Mudur(); 
                    formMudur.ShowDialog();

                }
                else if(oku.GetString(5) == "1" ) //1 ise öğretmen penceresi açılsın
                {
                    Form1 frm = new Form1();
                    this.Hide();
                    frm.ShowDialog();

                }
                else // Değilse 2 dir. Kitap ödünç verme penceresi açılsın.
                {
                    Kitap_Odunc FormKitap = new Kitap_Odunc();
                    FormKitap.ShowDialog();
                }
                
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya Parola HATALI");
            }

            conn.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            metinKutusuRenklendir(textBox3);
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            metinKutusuDuzelt(textBox3);
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            metinKutusuRenklendir(textBox4);

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            metinKutusuDuzelt(textBox4);
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            metinKutusuRenklendir(textBox5);
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            metinKutusuDuzelt(textBox5);
        }




        void metinKutusuRenklendir(System.Windows.Forms.TextBox kutu)
        {
            kutu.BackColor = Color.Magenta;
            kutu.Font = new Font(textBox5.Font.FontFamily, 16);
            kutu.Size = new System.Drawing.Size(220, 40);
        }

        void metinKutusuDuzelt(System.Windows.Forms.TextBox kutu)
        {
            kutu.BackColor = Color.White;
            kutu.Font = new Font(textBox5.Font.FontFamily, 8);
            kutu.Size = new System.Drawing.Size(100, 20);
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            metinKutusuRenklendir(textBox6);
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            metinKutusuDuzelt(textBox6);
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            metinKutusuRenklendir(textBox7);
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            metinKutusuDuzelt(textBox7);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;

        }

        private void Giris_Load(object sender, EventArgs e)
        {
            panel1.Location = panel2.Location;
            panel3.Location = panel2.Location;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            // WHERE bölümünde aynı anda 3 bilginin doğruluğu kontrol ediliyor.
            string sql = "SELECT * FROM kullanicilar WHERE k_adi='"+textBox10.Text+"' AND adSoyad='"+textBox9.Text+"' AND telefon='"+textBox8.Text+"'";

            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader oku = cmd.ExecuteReader();

            if(oku.Read())  //Veri tabanında en az bir kayıt varsa, True değeri döner
            {
                MessageBox.Show("Parolanız : " + oku.GetString(2));
            }
            else 
            {
                MessageBox.Show("Bilgileri yanlış girdiniz.");
            }

            conn.Close();
        }
    }
}
