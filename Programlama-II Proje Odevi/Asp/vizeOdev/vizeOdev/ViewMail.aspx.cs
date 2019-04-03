using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class VievMail : System.Web.UI.Page
{
    int MesajID;
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
            if (Request.QueryString["mesajid"] != null)
            {

                //Label1.Text = Request.QueryString["mesajid"].ToString();
                MesajID = Int32.Parse(Request.QueryString["mesajid"]);
                if (!MesajIslemDB.MesajKontrol(MesajID,(int)Session["KullaniciID"]))
                {
                    Response.Redirect("Mail.aspx");
                }
            }
        }
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Session["giris"] = false;
        Session["KullaniciID"] = -1;
        Response.Redirect("Login.aspx?mesaj=Başarı ile Çıkış yapıldı.");
    }
    protected void MesajKutusu_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["mesajid"] != null)
        {
            DataTable Ileti = MesajIslemDB.MesajInfo(MesajID);
            int GonderenID = (int)Ileti.Rows[0]["GonderenID"];
            string GonderenNick = YonetimDB.KullaniciNick(GonderenID);
            string Baslik = (string)Ileti.Rows[0]["Baslik"];
            string Tarih = (string)Ileti.Rows[0]["Tarih"];
            string Mesaj = (string)Ileti.Rows[0]["Mesaj"];
            //MesajKutusu.Text = "test" + Environment.NewLine +"xd"; 
            MesajKutusu.Text = "Gönderen: " + GonderenNick + Environment.NewLine + Environment.NewLine +
                Baslik + Environment.NewLine + Environment.NewLine + Mesaj + Environment.NewLine + Tarih;
        }   
    }
    protected void buttonGeri_Click(object sender, EventArgs e)
    {
        Response.Redirect("Mail.aspx");
    }
    protected void buttonYanitla_Click(object sender, EventArgs e)
    {
        Response.Redirect("Mail.aspx");
    }
    protected void buttonSil_Click(object sender, EventArgs e)
    {
        if(MesajIslemDB.MesajSil(MesajID))
        {
            MesajKutusu.Text = "Mesaj Başarılı bir şekilde Silindi.";
        }
        else
        {
            MesajKutusu.Text = "Beklenmeyen Hata! Lütfen tekrar deneyin.";
        }
    }
}