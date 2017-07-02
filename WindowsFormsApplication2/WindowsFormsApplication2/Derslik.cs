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
    public partial class Derslik : Form
    {
        SqlConnection baglanti;
        SqlDataAdapter da, akd, cys, drs, lbr;
        public static String id, bolum_adi = "";
        SqlDataReader dr;
        SqlCommand srg;
        public Derslik()
        {
            InitializeComponent();
            bolumleri_cekme();
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Derslik_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            derslik_kayit();
           
            
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
        void derslik_kayit()
        {
            string bolumkodu = Convert.ToString(comboBox1.SelectedValue);


            veritabani_baglantisi();
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayit = "insert into derslik(oda_kodu,bolum_kodu,bulundugu_kat,sira_sayisi,projeksiyon_sayisi,perde_sayisi,tahta_sayisi,bilgisayar_sayisi,petek_sayisi,pencere_sayisi,lamba_sayisi,priz_sayisi,sorun) values (" + textBox1.Text + ",'" + bolumkodu + "'," + textBox2.Text + " ," + textBox3.Text + " ," + textBox4.Text + "," + textBox5.Text + " ," + textBox6.Text + " , " + textBox7.Text + "," + textBox8.Text + " , " + textBox9.Text + "," + textBox10.Text + " ," + textBox11.Text + ",'" + richTextBox1.Text + "')";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
