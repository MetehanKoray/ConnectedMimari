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

namespace ConnectedMimari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=ServerAdresi...;Initial Catalog=VeriTabanıAdı...; Integrated Securtiy=true"); //Server kısmında Server Adresi yazılacak. Initial Catalog kısmında Veritabanı ismi yazılacak. Integrated Security kısmında true yazarak güvenilir bağlantı sağlamış oluyoruz.
            SqlCommand cmd = new SqlCommand();    //SQlCommand ile veritabanı sorgumuzu çalıştıracağız.
            cmd.CommandText = "Select * From Tabloİsmi...";    //cmd.CommandText ile veritanı sorgumuzu yazıyoruz.
            cmd.Connection = con;    //SqlCommand bir Connection istiyor ve cmd'ye con adında tanımladığımız SqlConnection'ı veriyoruz.
            con.Open();  //Connection nesnesini açmak için Open metodunu kullanıyoruz.
            SqlDataReader dr = cmd.ExecuteReader();  //Verileri okumak için SQlDataReader sınıfını kullanıyoruz.
            while (dr.Read())   //Veriler okunduğu sürece çalışması için While döngüsü tanımlıyoruz.
            {
                string isim = dr["Kolonİsmi"].ToString();   //Okumak istediğimiz kolonu string bir değişkene atıyoruz.
                listBox1.Items.Add(isim);     //string değişkeni ListBox'a ekliyoruz.
            }
            con.Close();  //Connection nesnesini kapatmak için Close metodunu kullanıyoruz.
           
        }
    }
}
