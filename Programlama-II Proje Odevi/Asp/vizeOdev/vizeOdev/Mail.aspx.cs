using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Mail : System.Web.UI.Page
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
                DataSet Kullanicilar = MesajIslemDB.KullaniciVeriCek((int)Session["KullaniciID"]);
                DropDownList1.DataTextField = "NickName";
                DropDownList1.DataValueField = "KullaniciID";
                DropDownList1.DataSource = Kullanicilar.Tables[0];
                DropDownList1.DataBind();

                if (Request.QueryString["id"] != null)
                {
                    ID = Int32.Parse(Request.QueryString["id"]);
                }
            }
        }
    }
    int ID = -1;


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ID = Int32.Parse(DropDownList1.SelectedValue);
    }

    protected void Send_Click(object sender, EventArgs e)
    {
        if(textBoxBaslik.Text == String.Empty)
        {
            InfoLabel.Text = "Başlık Boş Bırakılamaz!";
        }
        else if(textBoxBaslik.Text.Length > 50)
        {
            InfoLabel.Text = "Mesaj Başlığı 50 karakteri geçemez!";
        }
        else if(textBoxMessage.Text.Length > 520)
        {
            InfoLabel.Text = "Mesaj 520 karakteri geçemez!";
        }
        else
        {
            try
            {
                MesajIslemDB.MesajYolla((int)Session["KullaniciID"], Int32.Parse(DropDownList1.SelectedValue), textBoxBaslik.Text, textBoxMessage.Text, DateTime.Now);
                InfoLabel.Text = "Mesajınız Başarı ile gönderildi.";
            }
            catch
            {
                InfoLabel.Text = "Beklenmeyen Hata! Lütfen seçimlerinizi ve bağlantınızı kontrol edin.";
            }
        }
    }

   protected void ListMesaj(int ID)
    {
        DataSet Mesajlar = MesajIslemDB.GelenMesajlar(ID);
        int sM = Mesajlar.Tables[0].Rows.Count;
        for (int i = 0; i < sM; i++)
        {
            string Baslik = (string)Mesajlar.Tables[0].Rows[i]["Baslik"];
            string Mesaj = (string)Mesajlar.Tables[0].Rows[i]["Mesaj"];
            string Tarih = (string)Mesajlar.Tables[0].Rows[i]["Tarih"];
            int Mid = (int)Mesajlar.Tables[0].Rows[i]["MesajID"];
            int GonderenID = (int)Mesajlar.Tables[0].Rows[i]["GonderenID"];
            string GonderenNick = YonetimDB.KullaniciNick(GonderenID);
            Response.Write("<a href=\"ViewMail.aspx?mesajid="+ Mid +"\">"+ GonderenNick+" "+ Baslik + " "+Tarih+"</ a ><br/>");
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
        Response.Redirect("Main.aspx");
    }
}