using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Mesaj"] != null)
        {
            label3.Text = Request.QueryString["Mesaj"].ToString();
        }
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        if ((textBox1.Text != String.Empty) || (textBox2.Text != String.Empty))
        {
            string UserName = textBox1.Text;
            string Pass = textBox2.Text;
            int Log = YonetimDB.AdminLogin(UserName, Pass);
            if (Log != -1)
            {
                label3.Text = String.Empty;
                Session["edit"] = true;
                Session["AdminID"] = Log;
                Response.Redirect("KitapDuzenle.aspx");
                //label3.Text = "Working GOod :D";
            }
            else
            {
                label3.Text = "Hatalı giriş Lütfen Tekrar deneyin.";
            }
        }
        else
            label3.Text = "Alanlar Boş bırakılamaz!";
    }
}