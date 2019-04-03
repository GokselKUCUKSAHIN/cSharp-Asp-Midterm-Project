using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)//Load
    {
        if (Request.QueryString["Mesaj"] != null)
        {
            label3.Text = Request.QueryString["Mesaj"].ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)//Giriş Yap
    {
        if ((textBox1.Text != String.Empty) || (textBox2.Text != String.Empty))
        {
            string UserName = textBox1.Text;
            string Pass = textBox2.Text;
            int Log = YonetimDB.GirisYap(UserName, Pass);
            if (Log != -1)
            {
                label3.Text = String.Empty;
                Session["giris"] = true;
                Session["KullaniciID"] = Log;
                Response.Redirect("Main.aspx");
            }
            else
            {
                label3.Text = "Kullanıcı Adı veya Şifre Hatalı Lütfen Tekrar deneyin.";
            }
        }
        else
            label3.Text = "Kullanıcı Adı veya Şifre Boş bırakılamaz!";
    }

    protected void Button2_Click(object sender, EventArgs e)//Kayıt Olma penceresine git
    {
        Response.Redirect("SignUp.aspx");
    }
}