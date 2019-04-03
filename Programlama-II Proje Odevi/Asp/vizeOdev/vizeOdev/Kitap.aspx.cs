using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Kitap : System.Web.UI.Page
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
            Signed.Text = YonetimDB.KullaniciNick((int)Session["KullaniciID"]) + ": olarak Giriş Yapıldı.";
            if (!IsPostBack)
            {
                if (Request.QueryString["Kitapid"] != null)
                {
                    int KitapID = Int32.Parse(Request.QueryString["Kitapid"]);
                    KitapBilgi(KitapID);
                }
            }
        }
    }
    protected void KitapBilgi(int KitapID)
    {
        DataTable KitapVeri = KitapIslemDB.KitapBilgiCek(KitapID);

        string Adi = "Null/nA";
        int YazarID = -1;
        string Yazari = "Null/nA";
        string YayinEvi = "Null/nA";
        string Info = "Null/nA";
        float Puan = 0f;
        int OkumaSayisi = 0;

        if (KitapVeri.Rows.Count != 0)
        {
            //NickName = (string)userData.Tables[0].Rows[0]["Nickname"];
            Adi = (string)KitapVeri.Rows[0]["Adi"];
            YazarID = (int)KitapVeri.Rows[0]["YazarID"];
            Yazari = (string)KitapIslemDB.YazarVeriCek(YazarID).Rows[0]["Adi"] + " " + (string)KitapIslemDB.YazarVeriCek(YazarID).Rows[0]["Soyadi"];
            YayinEvi = (string)KitapVeri.Rows[0]["YayinEvi"];
            Info = (string)KitapVeri.Rows[0]["Info"];
            OkumaSayisi = KitapIslemDB.CountOkuma(KitapID);
            Puan = KitapIslemDB.PuanAvg(KitapID);
        }
        else
        {
            Adi = "Null/nA";
            YazarID = -1;
            Yazari = "Null/nA";
            YayinEvi = "Null/nA";
            Info = "Null/nA";
            Puan = 0;
            OkumaSayisi = 0;
        }
        KitapAdi.Text = "<strong>Adı: </strong>" + "<em>" + Adi + "</em>";
        KitapYazari.Text = "<strong>Yazarı: </strong>" + "<em><a href=\"YazarDetay.aspx?Yazarid=" + YazarID + "\">" + Yazari + "</a></em>";//yazarın sayfasına giden yolu linklicek
        KitapPuani.Text = "<strong>Puanı: </strong>" + "<em>" + Puan + "</em>";
        KitapReadCount.Text = "<strong>Okuma Sayısı: </strong>" + "<em>" + OkumaSayisi + "</em>";
        KitapYayinEvi.Text = "<strong>YayınEvi: </strong>" + "<em>" + YayinEvi + "</em>";
        KitapInfo.Text = "<strong>Tanıtım Bilgisi: </strong>" + "<em>" + Info + "</em>";
    }
    protected string IncelemeBilgi()
    {
        int KitapID = Int32.Parse(Request.QueryString["Kitapid"]);
        int KullaniciID = -1;
        string Kullanici = String.Empty;
        string Inceleme = String.Empty;
        DataTable Incelemeler = KitapIslemDB.IncelemeceCek(KitapID);
        if(Incelemeler.Rows.Count != 0)
        {
            string ret = "";
            for (int i = 0; i < Incelemeler.Rows.Count ; i++)
            {
                KullaniciID = (int)Incelemeler.Rows[i]["KullaniciID"];
                Kullanici = YonetimDB.KullaniciNick(KullaniciID);
                Inceleme = (string)Incelemeler.Rows[i]["Inceleme"];
                ret += "<p><strong>" + "<a href=\"Kullanici.aspx?id=" + KullaniciID + "\">" + Kullanici + "</a>" + ": <br/></strong>" + "<em>" + Inceleme + "</em></p>";
                //<a href=\"ViewMail.aspx?mesajid="+ Mid +"\">
            }
            return ret;
        }
        else
        {
            return "<h4>Belirtilen Kitaba Ait Her Hangi Bir Inceleme Bulunmuyor.</h4>";
        }
    }
    protected string AlintiBilgi()
    {
        int KitapID = Int32.Parse(Request.QueryString["Kitapid"]);
        int KullaniciID = -1;
        string Kullanici = String.Empty;
        string Alinti = String.Empty;
        int SayfaNo = 0;
        DataTable Alintilar = KitapIslemDB.AlintiCek(KitapID);
        if (Alintilar.Rows.Count != 0)
        {
            string ret = "";
            for (int i = 0; i < Alintilar.Rows.Count; i++)
            {
                KullaniciID = (int)Alintilar.Rows[i]["KullaniciID"];
                Kullanici = YonetimDB.KullaniciNick(KullaniciID);
                SayfaNo = (int)Alintilar.Rows[i]["SayfaNo"];
                Alinti = (string)Alintilar.Rows[i]["Alinti"];
                ret += "<p><strong>" + "<a href=\"Kullanici.aspx?id=" + KullaniciID + "\">" + Kullanici + "</a>" + ": <br/></strong>" + "<em>" + "<strong>" + "Sayfa " + SayfaNo + ": </strong>" + Alinti + "</em></p>";
                //<a href=\"ViewMail.aspx?mesajid="+ Mid +"\">
            }
            return ret;
        }
        else
        {
            return "<h4>Belirtilen Kitaba Ait Her Hangi Bir Alıntı Bulunmuyor.</h4>";
        }
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Session["giris"] = false;
        Session["KullaniciID"] = -1;
        Response.Redirect("Login.aspx?mesaj=Başarı ile Çıkış yapıldı.");
    }
    protected void buttonOkudum_Click(object sender, EventArgs e)
    {
        int KullaniciID = (int)Session["KullaniciID"];
        int KitapID = Int32.Parse(Request.QueryString["Kitapid"]);
        KitapIslemDB.Okudum(KullaniciID, KitapID);
    }
    protected void buttonGeri_Click(object sender, EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }
    protected void buttonPuanla_Click(object sender, EventArgs e)
    {
        Response.Redirect("Puanla.aspx?Kitapid="+ Int32.Parse(Request.QueryString["Kitapid"]));
    }
    protected void buttonYazar_Click(object sender, EventArgs e)
    {

    }
    protected void AlintiYaz_Click(object sender, EventArgs e)
    {
        Response.Redirect("AlintiYaz.aspx?Kitapid="+ Int32.Parse(Request.QueryString["Kitapid"]));
    }
    protected void IncelemeYaz_Click(object sender, EventArgs e)
    {
        Response.Redirect("Inceleme.aspx?Kitapid=" + Int32.Parse(Request.QueryString["Kitapid"]));
    }
}