using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Puanla : System.Web.UI.Page
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
                    PuanInfo();
                }
            }
        }
    }
    protected string KitapAdi()
    {
        DataTable veri = KitapIslemDB.KitapBilgiCek(Int32.Parse(Request.QueryString["Kitapid"]));
        string Adi = (string)veri.Rows[0]["Adi"];
        return Adi;
    }
    protected void PuanInfo()
    {
        if (KitapIslemDB.PuanCek(Int32.Parse(Request.QueryString["Kitapid"]), (int)Session["KullaniciID"]) == -1)
        {
            PuanDisplay.Text = "Puanlamak için Seçim yapın.";
        }
        else
        {
            PuanDisplay.Text = "Bu kitabı önceden Puanladınız. Verdiğiniz Puan: " + KitapIslemDB.PuanCek(Int32.Parse(Request.QueryString["Kitapid"]), (int)Session["KullaniciID"]);
        }
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Session["giris"] = false;
        Session["KullaniciID"] = -1;
        Response.Redirect("Login.aspx?mesaj=Başarı ile Çıkış yapıldı.");
    }
    protected void buttonGeri_Click(object sender, EventArgs e)
    {
        Response.Redirect("Kitap.aspx?Kitapid=" + Int32.Parse(Request.QueryString["Kitapid"]));
    }
    #region Puanlama Sistemi
    protected void PuanVer(int Puan)
    {
        int P = KitapIslemDB.PuanCek(Int32.Parse(Request.QueryString["Kitapid"]), (int)Session["KullaniciID"]);
        if (P == -1)//Puan verilmemiş
        {
            KitapIslemDB.Puanla((int)Session["KullaniciID"], Int32.Parse(Request.QueryString["Kitapid"]), Puan);
            PuanDisplay.Text = Puan.ToString() + " Puan Verdiniz.";
        }
        else//daha önceden Puan verilmiş
        {
            KitapIslemDB.PuanUpdate(Int32.Parse(Request.QueryString["Kitapid"]), (int)Session["KullaniciID"], Puan);
            PuanDisplay.Text = "Puanınızı " + Puan.ToString() + " ile Değiştirdiniz.";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        PuanVer(1);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        PuanVer(2);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        PuanVer(3);
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        PuanVer(4);
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        PuanVer(5);
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        PuanVer(6);
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        PuanVer(7);
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        PuanVer(8);
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        PuanVer(9);
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        PuanVer(10);
    }
    #endregion
}