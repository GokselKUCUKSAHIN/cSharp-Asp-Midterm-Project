using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class AlintiYaz : System.Web.UI.Page
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
    protected void Send_Click(object sender, EventArgs e)
    {
        if(TextBox1.Text != String.Empty)
        {
            int Page;
            try
            {
                Page = Int32.Parse(TextBox1.Text);
                if (Page >= 0) 
                {
                    if(textBoxMessage.Text != String.Empty)
                    {
                        if (textBoxMessage.Text.Length <= 1000)
                        {
                            if (KitapIslemDB.SendAlinti(Page, textBoxMessage.Text, Int32.Parse(Request.QueryString["Kitapid"]), (int)Session["KullaniciID"]))
                            {
                                InfoLabel.Text = "Alintiniz Başarı ile Kayıt edildi.";
                            }
                            else
                            {
                                InfoLabel.Text = "Beklenmeyen Hata!";
                            }
                        }
                        else
                        {
                            InfoLabel.Text = "Alıntılar 1000 karakteri geçemez!";
                        }
                    }
                    else
                    {
                        InfoLabel.Text = "Alıntı Yazmadınız!!!";
                    }
                }
                else
                {
                    InfoLabel.Text = "Sayfa No Negatif Olamaz.";
                }
            }
            catch
            {
                InfoLabel.Text = "Sayfa No Geçerli bir Sayı olmalı";
            }
        }
        else
        {
            InfoLabel.Text = "Sayfa No Boş Bırakılamaz.";
        }
    }
    protected void buttonGeri_Click(object sender, EventArgs e)
    {
        Response.Redirect("Kitap.aspx?Kitapid="+ Int32.Parse(Request.QueryString["Kitapid"]));
    }
}