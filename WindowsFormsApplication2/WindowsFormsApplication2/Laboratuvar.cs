using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Laboratuvar : Form
    {
        SqlConnection baglanti;
        SqlDataAdapter da, akd, cys, drs, lbr;
        public static String id, bolum_adi = "";
        SqlDataReader dr;
        SqlCommand srg;
        public Laboratuvar()
        {
            InitializeComponent();
            bolumleri_cekme();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        void veritabani_baglantisi()
        {
            baglanti = new SqlConnection("server=.; Database=mekanyonetimi;Trusted_Connection=True;Integrated Security=SSPI");
        }
        void bolumleri_cekme()
        {
            veritabani_baglantisi();
            baglanti.Open();
            da = new SqlDataAdapter("select*from bolumler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "bolum_kodu";
            comboBox1.DisplayMember = "bolum_adi";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            laboratuvar_kayit();
            
            

        }
        void laboratuvar_kayit()
        {
            string bolumkodu = Convert.ToString(comboBox1.SelectedValue);
            veritabani_baglantisi();
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string sorgu_kayit = "insert into laboratuvar(oda_kodu,bolum_kodu,bulundugu_kat,bilgisayar_sayisi,projek_perde_sayisi,projeksiyon_sayisi,sandalye_sayisi,masa_sayisi,lamba_sayisi,priz_sayisi,pencere_sayisi,tahta_sayisi,sorun) values (" + textBox1.Text + ",'" + bolumkodu + "'," + textBox2.Text + " ," + textBox3.Text + " ," + textBox4.Text + "," + textBox5.Text + "," + textBox6.Text + "," + textBox7.Text + "," + textBox8.Text + "," + textBox9.Text + "," + textBox10.Text + "," + textBox11.Text + ",'" + richTextBox1.Text + "')";
                SqlCommand komut = new SqlCommand(sorgu_kayit, baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                sorun_kayit();
                MessageBox.Show("Kayıt İşlemi Gerçekleşti.");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kayıt İşlemi Sırasında Hata Oluştu.Lütfen girdiğiniz değerleri kontrol ediniz.");
            }
            
        }
        void sorun_kayit()
        {
             string bolumkodu = Convert.ToString(comboBox1.SelectedValue);
            veritabani_baglantisi();
            string b = "Çözülmedi";
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string sorgu_kayit = "insert into sorunlar(mekan_kodu,sorun_kodu,sorun,onay_durumu,onay)values ('" + bolumkodu + "'," + textBox1.Text + ",'" + richTextBox1.Text + "','" + b + "'," + 0 + ")";
                SqlCommand komut = new SqlCommand(sorgu_kayit, baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Sorun Kayıt Sırasında Hata Oluştu.");
            }
            
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void Laboratuvar_Load(object sender, EventArgs e)
        {
          
        }
    }
}
