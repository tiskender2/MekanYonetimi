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

    public partial class Form2 : Form
    {
        SqlConnection baglanti;
        SqlDataAdapter data_akd, data_lbr, data_cys, data_drs, akd, lbr, cys, drs,rpr,srn;
        bool deger_akd = false, deger_cys = false;
        SqlDataReader dr;
        SqlCommand srg;
        public static int akd_sayi, cys_sayi, drs_sayi, lbr_sayi, rpr_sayi;
        public static int akd_kod, cys_kod, drs_kod, lbr_kodu, rpr_kodu;
        public static string akd_ad, cys_ad, drs_ad, lbr_ad, rpr_ad;
        public static string akd_adı, cys_adı, drs_adı, lbr_adı, rpr_adı;
        public string bolumkodu;



        public Form2()
        {

            InitializeComponent();
           // kolonlar();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {


        }
        private void tabPage2_Click(object sender, EventArgs e)
        {


        }
        private void tabPage5_Click(object sender, EventArgs e)
        {
        }
        private void tabPage6_Click(object sender, EventArgs e)
        {
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


            veritabani_baglantisi();
            baglanti.Open();



        }

        private void button2_Click(object sender, EventArgs e)
        {
           // kolonlar();
        }
        void veritabani_baglantisi()
        {
            baglanti = new SqlConnection("server=.; Database=mekanyonetimi;Trusted_Connection=True;Integrated Security=SSPI");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            AramaSonucForm form3 = new AramaSonucForm();
            form3.Show();

            veritabani_baglantisi();
            baglanti.Open();

            if (secenekler.SelectedIndex == 0)
            {

                akd = new SqlDataAdapter("select oda_kodu,bulundugu_kat,bilgisayar_sayisi,dolap_sayisi,yazici_sayisi,telefon_sayisi,masa_sayisi,sandalye_sayisi,sorun from akademisyen_oda  where  oda_kodu =" + textBox1.Text + " and bolum_kodu=" + Form1.id + "", baglanti);
                DataTable akdt = new DataTable();

                akd.Fill(akdt);

                form3.dataGridView1.DataSource = akdt;


            }
            else if (secenekler.SelectedIndex == 1)
            {

                cys = new SqlDataAdapter("select oda_kodu,bulundugu_kat,sandalye_sayisi,masa_sayisi,cay_makinesi_sayisi,dolap_sayisi,sorun from caysalonu where oda_kodu = " + textBox1.Text + " and bolum_kodu=" + Form1.id + "", baglanti);
                DataTable cyst = new DataTable();

                cys.Fill(cyst);

                form3.dataGridView1.DataSource = cyst;
            }
            else if (secenekler.SelectedIndex == 2)
            {

                akd = new SqlDataAdapter("select oda_kodu,bulundugu_kat,sira_sayisi,projeksiyon_sayisi,perde_sayisi,tahta_sayisi,bilgisayar_sayisi,petek_sayisi,pencere_sayisi,lamba_sayisi,priz_sayisi,sorun from derslik where oda_kodu =" + textBox1.Text + "and bolum_kodu=" + Form1.id + "", baglanti);
                DataTable drst = new DataTable();

                akd.Fill(drst);

                form3.dataGridView1.DataSource = drst;

            }
            else if (secenekler.SelectedIndex == 3)
            {
                akd = new SqlDataAdapter("select oda_kodu,bulundugu_kat,bilgisayar_sayisi,projek_perde_sayisi,projeksiyon_sayisi,sandalye_sayisi,masa_sayisi,lamba_sayisi,priz_sayisi,pencere_sayisi,tahta_sayisi,sorun from laboratuvar where oda_kodu=" + textBox1.Text + "and bolum_kodu=" + Form1.id + "", baglanti);
                DataTable lbrt = new DataTable();

                akd.Fill(lbrt);

                form3.dataGridView1.DataSource = lbrt;
            }
            baglanti.Close();


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void secenekler_SelectedIndexChanged(object sender, EventArgs e)
        {




        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#e9e3cb");
          
            
           
        }
        public void verileriGuncelle()
        {
            veritabani_baglantisi();
            baglanti.Open();
            akd = new SqlDataAdapter("select ao.oda_kodu,ao.bilgisayar_sayisi,ao.bulundugu_kat,ao.dolap_sayisi,ao.masa_sayisi,ao.sandalye_sayisi,ao.telefon_sayisi,ao.yazici_sayisi,ao.sorun from akademisyen_oda as ao inner join bolumler as b on ao.bolum_kodu=b.bolum_kodu where ao.bolum_kodu=" + Form1.id, baglanti);
            cys = new SqlDataAdapter("select cy.oda_kodu,cy.bulundugu_kat,cy.sandalye_sayisi,cy.masa_sayisi,cy.cay_makinesi_sayisi,cy.dolap_sayisi,cy.sorun from caysalonu as cy inner join bolumler as b on cy.bolum_kodu=b.bolum_kodu where cy.bolum_kodu=" + Form1.id, baglanti);
            drs = new SqlDataAdapter("select drs.oda_kodu,drs.bulundugu_kat,drs.sira_sayisi,drs.projeksiyon_sayisi,drs.perde_sayisi,drs.tahta_sayisi,drs.bilgisayar_sayisi,drs.petek_sayisi,drs.pencere_sayisi,drs.lamba_sayisi,drs.priz_sayisi,drs.sorun from derslik as drs inner join bolumler as b on drs.bolum_kodu=b.bolum_kodu where drs.bolum_kodu=" + Form1.id, baglanti);
            lbr = new SqlDataAdapter("select lbr.oda_kodu,lbr.bulundugu_kat,lbr.bilgisayar_sayisi,lbr.projek_perde_sayisi,lbr.projeksiyon_sayisi,lbr.sandalye_sayisi,lbr.masa_sayisi,lbr.lamba_sayisi,lbr.priz_sayisi,lbr.pencere_sayisi,lbr.tahta_sayisi,lbr.sorun from laboratuvar as lbr inner join bolumler as b on lbr.bolum_kodu=b.bolum_kodu where lbr.bolum_kodu=" + Form1.id, baglanti);
            rpr = new SqlDataAdapter("select sorun_kodu,mekan_kodu,sorun,onay_durumu from sorunlar where sorun IS NOT NULL and onay_durumu='Çözülmedi' and mekan_kodu=" + Form1.id, baglanti);
            srn = new SqlDataAdapter("select sorun_kodu,mekan_kodu,sorun,onay_durumu from sorunlar where onay=" + 1 + " and onay_durumu='Çözüldü' and mekan_kodu=" + Form1.id, baglanti);

            DataTable akdt = new DataTable();
            DataTable cysdt = new DataTable();
            DataTable drsdt = new DataTable();
            DataTable lbrdt = new DataTable();
            DataTable rprdt = new DataTable();
            DataTable srndt = new DataTable();

            akd.Fill(akdt);
            cys.Fill(cysdt);
            drs.Fill(drsdt);
            lbr.Fill(lbrdt);
            rpr.Fill(rprdt);
            srn.Fill(srndt);

            dataGridView1.DataSource = akdt;
            dataGridView2.DataSource = cysdt;
            dataGridView3.DataSource = drsdt;
            dataGridView4.DataSource = lbrdt;
            dataGridView5.DataSource = rprdt;
            dataGridView6.DataSource = srndt;

            baglanti.Close();
           
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(comboBox2.SelectedIndex);
            if (a == 0)
            {
                Laboratuvar lbrForm = new Laboratuvar();
                lbrForm.Show();
            }
            else if (a == 1)
            {
                CaySalonu cysForm = new CaySalonu();
                cysForm.Show();
            }
            else if (a == 2)
            {
                Derslik drsForm = new Derslik();
                drsForm.Show();
            }
            else if (a == 3)
            {
                Akademisyen akdForm = new Akademisyen();
                akdForm.Show();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            veritabani_baglantisi();


            foreach (DataGridViewRow row in dataGridView5.Rows)
            {

                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    string sorun_kodu = Convert.ToString(row.Cells["sorun_kodu"].Value);


                   try
                    {
                        if (baglanti.State == ConnectionState.Closed)
                            baglanti.Open();
                        string sorgu_kayit = "update sorunlar set onay_durumu='Çözüldü', onay=" + 1 + " where sorun_kodu =" + sorun_kodu + "";
                        SqlCommand komut = new SqlCommand(sorgu_kayit, baglanti);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Sorun Çözme İşleminiz Gerçekleştirildi.");
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu.");
                    }
                }

            }

        }



        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            button2.Enabled = true;
        }
       

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            veritabani_baglantisi();
            
          
            int a = Convert.ToInt32(comboBox1.SelectedIndex);

            comboBox4.DataSource = null;
            
            if (a == 0)
            {
                data_akd = new SqlDataAdapter("select*from akademisyen_oda where bolum_kodu="+Form1.id, baglanti);
                DataTable dt = new DataTable();
                data_akd.Fill(dt);
             
                comboBox4.ValueMember = "akademisyen_oda_id";
                comboBox4.DisplayMember = "oda_kodu";
                comboBox4.DataSource = dt;
          
            }
            else if (a == 1)
            {
                data_lbr = new SqlDataAdapter("select*from laboratuvar where bolum_kodu=" + Form1.id, baglanti);
                DataTable dt1 = new DataTable();
                data_lbr.Fill(dt1);
                comboBox4.ValueMember = "laboratuvar_id";
                comboBox4.DisplayMember = "oda_kodu";
                comboBox4.DataSource = dt1;
               
               
            }
            else if (a == 2)
            {
                data_cys = new SqlDataAdapter("select*from caysalonu where bolum_kodu=" + Form1.id, baglanti);
                DataTable dt2 = new DataTable();
                data_cys.Fill(dt2);
                comboBox4.ValueMember = "caysalonu_id";
                comboBox4.DisplayMember = "oda_kodu";
                comboBox4.DataSource = dt2;
          
             
            }
            else if (a == 3)
            {
                
                 comboBox4.Refresh();
                data_drs = new SqlDataAdapter("select*from derslik where bolum_kodu="+Form1.id, baglanti);
                DataTable dt3 = new DataTable();
                data_drs.Fill(dt3);
                comboBox4.ValueMember = "derslik_id";
                comboBox4.DisplayMember = "oda_kodu";
                comboBox4.DataSource = dt3;
              
            }

           
           baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            veritabani_baglantisi();
             try
               {
                if (baglanti.State == ConnectionState.Closed)
                   baglanti.Open();
                string c1 = Convert.ToString(comboBox1.Text);
                string c2 = Convert.ToString(comboBox3.Text);
                int c3 = Convert.ToInt32(comboBox4.Text);
                string sql = @"update " + c1 + " set " + c2 + "=@degis where bolum_kodu=@bolumkodu and oda_kodu="+c3+"";
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@degis", richTextBox1.Text.ToString());
                komut.Parameters.AddWithValue("@bolumkodu", Form1.id);
                   komut.ExecuteNonQuery();
                   baglanti.Close();
                   MessageBox.Show("Güncelleme İşlemi Gerçekleşti.");
               }
               catch (Exception hata)
               {
                   MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
               }
           }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            veritabani_baglantisi();
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string c1 = Convert.ToString(comboBox5.Text);
                int c3 = Convert.ToInt32(comboBox6.Text);
                string sql = @"delete from " + c1 + " where oda_kodu="+c3+" and bolum_kodu=@mekankodu";
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@degis", richTextBox1.Text.ToString());
                komut.Parameters.AddWithValue("@mekankodu", Form1.id);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme İşlemi Gerçekleşti.");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Silme Sırasında Hata Oluştu.");
            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            veritabani_baglantisi();
            int b = Convert.ToInt32(comboBox5.SelectedIndex);

            comboBox6.DataSource = null;
            baglanti.Open();
            if (b == 0)
            {
                data_akd = new SqlDataAdapter("select*from akademisyen_oda where bolum_kodu=" + Form1.id, baglanti);
                DataTable dt = new DataTable();
                data_akd.Fill(dt);
                comboBox6.ValueMember = "derslik_id";
                comboBox6.DisplayMember = "oda_kodu";
                comboBox6.DataSource = dt;
            }
            else if (b == 1)
            {
                data_lbr = new SqlDataAdapter("select*from laboratuvar where bolum_kodu=" + Form1.id, baglanti);
                DataTable dt1 = new DataTable();
                data_lbr.Fill(dt1);
                comboBox6.ValueMember = "derslik_id";
                comboBox6.DisplayMember = "oda_kodu";
                comboBox6.DataSource = dt1;

            }
            else if (b == 2)
            {
                data_cys = new SqlDataAdapter("select*from caysalonu where bolum_kodu=" + Form1.id, baglanti);
                DataTable dt2 = new DataTable();
                data_cys.Fill(dt2);
                comboBox6.ValueMember = "derslik_id";
                comboBox6.DisplayMember = "oda_kodu";
                comboBox6.DataSource = dt2;

            }
            else if (b == 3)
            {

                comboBox4.Refresh();
                data_drs = new SqlDataAdapter("select*from derslik where bolum_kodu=" + Form1.id, baglanti);
                DataTable dt3 = new DataTable();
                data_drs.Fill(dt3);
                comboBox6.ValueMember = "derslik_id";
                comboBox6.DisplayMember = "oda_kodu";
                comboBox6.DataSource = dt3;
            }
            baglanti.Close();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dataGridView1.CurrentRow.Cells["sorun"].Value.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
           verileriGuncelle();
            
        }


        }
    }
    

