using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Inceleme : System.Web.UI.Page
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
        DataTable Veri = KitapIslemDB.KitapBilgiCek(KitapID);
        if (Veri.Rows.Count != 0)
        {
            string Kisim = (string)Veri.Rows[0]["Adi"];
            labelKitapIsmi.Text = Kisim;
        }
        else
        {
            labelKitapIsmi.Text = "Null-Empty";
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
    protected void Send_Click(object sender, EventArgs e)
    {
        string Review = textBoxMessage.Text;
        if (Review.Length < 1000)
        {
            if(Review != String.Empty)
            {
                int Kitapid = Int32.Parse(Request.QueryString["Kitapid"]);
                int Userid = (int)Session["KullaniciID"];
                if (KitapIslemDB.SendInceleme(Kitapid,Userid,Review))
                {
                    InfoLabel.Text = "İncelemeniz Kayıt edildi.";
                }
                else
                {
                    InfoLabel.Text = "Beklenmeyen Hata!!";
                }

            }
            else
            {
                InfoLabel.Text = "İnceleme Yazmadınız";
            }
        }
        else
        {
            InfoLabel.Text = "İnceleme 1000 karakteri geçemez.";
        }
    }
}