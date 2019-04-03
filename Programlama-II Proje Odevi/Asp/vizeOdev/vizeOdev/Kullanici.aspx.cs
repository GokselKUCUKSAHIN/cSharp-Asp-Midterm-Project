using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Kullanici : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool giris = Convert.ToBoolean(Session["giris"]);
        if (giris == false)
        {
            Response.Redirect("Login.aspx?mesaj=Lutfen Once Giris Yapın");
        }
        else
        {
            Signed.Text = YonetimDB.KullaniciNick((int)Session["KullaniciID"])+": olarak Giriş Yapıldı.";
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int UserID = Int32.Parse(Request.QueryString["id"]);
                    AramaYap(UserID);
                }
            }
        }
    }
    protected void AramaYap(int id)
    {
        DataSet userData = YonetimDB.KullaniciProfilData(id);
        //table.rows[rowindex][columnindex]
        string NickName = "Null/nA";
        string Name = "Null/nA";
        string Surname = "Null/nA";
        string BirthDate = "Null/nA";
        string Gender = "Null/nA";

        if (userData.Tables[0].Rows.Count != 0)
        {
            NickName = (string)userData.Tables[0].Rows[0]["Nickname"];
            Name = (string)userData.Tables[0].Rows[0]["Adi"];
            Surname = (string)userData.Tables[0].Rows[0]["Soyadi"];
            BirthDate = (string)userData.Tables[0].Rows[0]["DogumTarih"];
            Gender = (string)userData.Tables[0].Rows[0]["Cinsiyet"];
        }
        else
        {
            NickName = "Null/nA";
            Name = "Null/nA";
            Surname = "Null/nA";
            BirthDate = "Null/nA";
            Gender = "Null/nA";
        }

        UserNick.Text = "<strong>KullanıcıAdı: </strong>" + "<em>" + NickName + "</em>";
        Isim.Text = "<strong>Adı: </strong>" + "<em>" + Name + "</em>";
        Soyisim.Text = "<strong>Soyadı: </strong>" + "<em>" + Surname + "</em>";
        DogumTarih.Text = "<strong>Doğum Tarihi: </strong>" + "<em>" + BirthDate + "</em>";
        Cinsiyet.Text = "<strong>Cinsiyeti: </strong>" + "<em>" + Gender + "</em>";
    }
    protected void MsgGonder_Click(object sender, EventArgs e)
    {
        Response.Redirect("Mail.aspx");
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Session["giris"] = false;
        Session["KullaniciID"] = -1;
        Response.Redirect("Login.aspx?mesaj=Başarı ile Çıkış yapıldı.");
    }
    protected void buttonGeri_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
    protected string OkumaInfo()
    {
        DataTable Veri = YonetimDB.KullaniciOkuduguKitap(Int32.Parse(Request.QueryString["id"]));
        if(Veri.Rows.Count != 0)
        {
            int satir = Veri.Rows.Count;
            string Ret = String.Empty;
            for (int i = 0; i < satir; i++)
            {
                int KitapID = (int)Veri.Rows[i]["KitapID"];
                string KitapAdi;
                DataTable kitap = KitapIslemDB.KitapBilgiCek(KitapID);
                KitapAdi = (string)kitap.Rows[0]["Adi"];
                Ret += "<em><a href=\"Kitap.aspx?Kitapid=" + KitapID + "\">" + KitapAdi + "</a></em><br/>";
            }
            return Ret;
        }
        else
        {
            return "<h3>Kullanıcıya ait Kitap Okuma Bilgisi Bulunmuyor</h3>";
        }
    }
    protected string PuanInfo()
    {
        DataTable Veri = YonetimDB.VerdigiPuan(Int32.Parse(Request.QueryString["id"]));
        if (Veri.Rows.Count != 0)
        {
            int satir = Veri.Rows.Count;
            string Ret = String.Empty;
            for (int i = 0; i < satir; i++)
            {
                int KitapID = (int)Veri.Rows[i]["KitapID"];
                string KitapAdi;
                int Puan = (int)Veri.Rows[i]["Puan"];
                DataTable kitap = KitapIslemDB.KitapBilgiCek(KitapID);
                KitapAdi = (string)kitap.Rows[0]["Adi"];
                
                Ret += "<em><a href=\"Kitap.aspx?Kitapid=" + KitapID + "\">" + KitapAdi + "</a>: " + "<strong>" + Puan + "</strong>" + "</em><br/>";
            }
            return Ret;
        }
        else
        {
            return "<h3>Kullanıcıya ait Puanlama Bilgisi Bulunmuyor</h3>";
        }
    }
    protected string IncelemeInfo()
    {
        DataTable Veri = YonetimDB.IncelemeList(Int32.Parse(Request.QueryString["id"]));
        if (Veri.Rows.Count != 0)
        {
            int satir = Veri.Rows.Count;
            string Ret = String.Empty;
            for (int i = 0; i < satir; i++)
            {
                int KitapID = (int)Veri.Rows[i]["KitapID"];
                string KitapAdi;
                string Incelemeler = (string)Veri.Rows[i]["Inceleme"];
                DataTable kitap = KitapIslemDB.KitapBilgiCek(KitapID);
                KitapAdi = (string)kitap.Rows[0]["Adi"];

                Ret += "<em><a href=\"Kitap.aspx?Kitapid=" + KitapID + "\">" + KitapAdi + "</a>: " + "<p>" + Incelemeler + "</p>" + "</em><br/>";
            }
            return Ret;
        }
        else
        {
            return "<h3>Kullanıcıya ait Puanlama Bilgisi Bulunmuyor</h3>";
        }
    }
    protected string AlintiInfo()
    {
        DataTable Veri = YonetimDB.AlintiList(Int32.Parse(Request.QueryString["id"]));
        if (Veri.Rows.Count != 0)
        {
            int satir = Veri.Rows.Count;
            string Ret = String.Empty;
            for (int i = 0; i < satir; i++)
            {
                int KitapID = (int)Veri.Rows[i]["KitapID"];
                string KitapAdi;
                int SayfoNo = (int)Veri.Rows[i]["SayfaNo"];
                string Alinti = (string)Veri.Rows[i]["Alinti"];
                DataTable kitap = KitapIslemDB.KitapBilgiCek(KitapID);
                KitapAdi = (string)kitap.Rows[0]["Adi"];

                Ret += "<em><a href=\"Kitap.aspx?Kitapid=" + KitapID + "\">" + KitapAdi + "</a> "+ SayfoNo+". Sayfa:" + "<p>" + Alinti + "</p>" + "</em><br/>";
            }
            return Ret;
        }
        else
        {
            return "<h3>Kullanıcıya ait Puanlama Bilgisi Bulunmuyor</h3>";
        }
    }
}