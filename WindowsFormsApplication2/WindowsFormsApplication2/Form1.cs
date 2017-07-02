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
    
    public partial  class Form1 : Form
    {
        SqlConnection baglanti;
        SqlDataAdapter da,akd,cys,drs,lbr,rpr,srn;
       public static String id,bolum_adi="";
        SqlDataReader dr;
        SqlCommand srg;
        
        public Form1()
        {
            InitializeComponent();
        }
        void veritabani_baglantisi()
        {
            baglanti = new SqlConnection("server=.; Database=mekanyonetimi;Trusted_Connection=True;Integrated Security=SSPI");
        }
        public void sorgular()
        {
            
            akd = new SqlDataAdapter("select ao.oda_kodu,ao.bilgisayar_sayisi,ao.bulundugu_kat,ao.dolap_sayisi,ao.masa_sayisi,ao.sandalye_sayisi,ao.telefon_sayisi,ao.yazici_sayisi,ao.sorun from akademisyen_oda as ao inner join bolumler as b on ao.bolum_kodu=b.bolum_kodu where ao.bolum_kodu=" + id, baglanti);
            cys = new SqlDataAdapter("select cy.oda_kodu,cy.bulundugu_kat,cy.sandalye_sayisi,cy.masa_sayisi,cy.cay_makinesi_sayisi,cy.dolap_sayisi,cy.sorun from caysalonu as cy inner join bolumler as b on cy.bolum_kodu=b.bolum_kodu where cy.bolum_kodu=" + id, baglanti);
            drs = new SqlDataAdapter("select drs.oda_kodu,drs.bulundugu_kat,drs.sira_sayisi,drs.projeksiyon_sayisi,drs.perde_sayisi,drs.tahta_sayisi,drs.bilgisayar_sayisi,drs.petek_sayisi,drs.pencere_sayisi,drs.lamba_sayisi,drs.priz_sayisi,drs.sorun from derslik as drs inner join bolumler as b on drs.bolum_kodu=b.bolum_kodu where drs.bolum_kodu=" + id, baglanti);
            lbr = new SqlDataAdapter("select lbr.oda_kodu,lbr.bulundugu_kat,lbr.bilgisayar_sayisi,lbr.projek_perde_sayisi,lbr.projeksiyon_sayisi,lbr.sandalye_sayisi,lbr.masa_sayisi,lbr.lamba_sayisi,lbr.priz_sayisi,lbr.pencere_sayisi,lbr.tahta_sayisi,lbr.sorun from laboratuvar as lbr inner join bolumler as b on lbr.bolum_kodu=b.bolum_kodu where lbr.bolum_kodu=" + id, baglanti);
            rpr = new SqlDataAdapter("select sorun_kodu,mekan_kodu,sorun,onay_durumu from sorunlar where sorun IS NOT NULL and onay_durumu='Çözülmedi' and mekan_kodu=" + id, baglanti);
            srn = new SqlDataAdapter("select sorun_kodu,mekan_kodu,sorun,onay_durumu from sorunlar where onay="+1+" and onay_durumu='Çözüldü' and mekan_kodu="+id,baglanti);
        }
        void  veri_cekme()
        {
            veritabani_baglantisi();
            baglanti.Open();
             da = new SqlDataAdapter("select*from bolumler", baglanti);
             DataTable dt = new DataTable();
             da.Fill(dt);
             comboBox2.ValueMember = "bolum_kodu";
             comboBox2.DisplayMember = "bolum_adi";
             comboBox2.DataSource = dt;
            baglanti.Close();
        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            veri_cekme();
            button1.BackColor = ColorTranslator.FromHtml("#5cb85c");
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#5cb85c");
            button1.FlatAppearance.BorderSize = 1;
            button1.ForeColor = Color.White;
            this.BackColor = ColorTranslator.FromHtml("#e9e3cb");
            
        }
   

        private void button1_Click(object sender, EventArgs e)
        {
            verileriYukle();

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }
       
       public  void verileriYukle()
        {

            Form2 form = new Form2();

            form.Show();
            id = comboBox2.SelectedValue.ToString();

            veritabani_baglantisi();
            baglanti.Open();
            srg = new SqlCommand("select bolum_adi from bolumler where bolum_kodu=" + id, baglanti);
            SqlDataReader dr = srg.ExecuteReader();
            while (dr.Read())
            {

                bolum_adi = dr["bolum_adi"].ToString();
            }
            dr.Close();
            sorgular();
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

            form.dataGridView1.DataSource = akdt;
            form.dataGridView2.DataSource = cysdt;
            form.dataGridView3.DataSource = drsdt;
            form.dataGridView4.DataSource = lbrdt;
            form.dataGridView5.DataSource = rprdt;
            form.dataGridView6.DataSource = srndt;
            form.label1.Text = bolum_adi;
            baglanti.Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }



      
       
       
    }

}