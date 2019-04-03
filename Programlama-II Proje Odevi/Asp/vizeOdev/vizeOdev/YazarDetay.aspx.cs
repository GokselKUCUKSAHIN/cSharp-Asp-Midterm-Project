using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class YazarDetay : System.Web.UI.Page
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
                if (Request.QueryString["Yazarid"] != null)
                {
                    int YazarID = Int32.Parse(Request.QueryString["YazarID"]);
                    YazarBilgi(YazarID);
                }
            }
        }
    }
    protected void ListKitap()
    {
        DataTable Kitaplar = KitapIslemDB.YazarKitapCek(Int32.Parse(Request.QueryString["YazarID"]));
        int sK = Kitaplar.Rows.Count;
        for (int i = 0; i < sK; i++)
        {
            string KitapAdi = (string)Kitaplar.Rows[i]["Adi"];
            int KitapID = (int)Kitaplar.Rows[i]["KitapID"];
            Response.Write("<a style=\"font-size:20px;\" href=\"Kitap.aspx?Kitapid=" + KitapID + "\">" + KitapAdi + "</ a ><br/>");
        }
    }
    protected void YazarBilgi(int YazarID)
    {
        DataTable Veri = KitapIslemDB.YazarVeriCek(YazarID);
        string adsoyad = String.Empty;
        string tarih = String.Empty;
        if(Veri.Rows.Count != 0)
        {
            adsoyad = (string)Veri.Rows[0]["Adi"] + " " + (string)Veri.Rows[0]["Soyadi"];
            tarih = (string)Veri.Rows[0]["DogumTarih"] + " / " + (string)Veri.Rows[0]["OlumTarih"];
        }
        else
        {
            adsoyad = "Null-Empty";
            tarih = "Null-Empty";
        }
        YazarAdSoyad.Text = "<strong>Adı-Soyadı: </strong>" + "<em>" + adsoyad + "</em>";
        Tarih.Text = "<strong>Doğum/Ölüm Tarihi: </strong>" + "<em>" + tarih + "</em>";
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
}