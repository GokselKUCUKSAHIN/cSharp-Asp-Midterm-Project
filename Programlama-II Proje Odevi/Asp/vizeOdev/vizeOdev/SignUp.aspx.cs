using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            textBox2.Attributes["value"] = textBox2.Text;
            textBox3.Attributes["value"] = textBox3.Text;
        }
    }

    #region Cinsiyet Secim
    string Cinsiyet = "Erkek";

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)//erkek
    {
        if (CheckBox2.Checked == false)
            CheckBox2.Checked = true;
        else
            CheckBox2.Checked = false;
    }

    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)//kadın
    {
        if (CheckBox1.Checked == false)
            CheckBox1.Checked = true;
        else
            CheckBox1.Checked = false;
    }
    #endregion

    #region Tarih
    string DTarih = "01.01.1950";
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DTarih = DropDownList1.SelectedValue + '.' + DropDownList2.SelectedValue + '.' + DropDownList3.SelectedValue;
        //InfoLabel.Text = DTarih;
    }
    protected string TarihSec()
    {
        DTarih = DropDownList1.SelectedValue + '.' + DropDownList2.SelectedValue + '.' + DropDownList3.SelectedValue;
        //InfoLabel.Text = DTarih;
        return DTarih;
    }
    #endregion

    protected void Button3_Click(object sender, EventArgs e)//Giriş yap'a dön
    {
        Response.Redirect("Login.aspx?Mesaj=Sizi yeniden görmek hoş.");
    }

    string Nick = String.Empty;
    string Ad = String.Empty;
    string Soyad = String.Empty;
    string Pass = String.Empty;
    string PassRepeat = String.Empty;
    string Tarih = String.Empty;
    protected void Button4_Click(object sender, EventArgs e)//Kayıt Ol
    {
        Tarih = TarihSec();
        Nick = textBox1.Text;
        if(!YonetimDB.NickNameKontrol(Nick))
        {
            Pass = textBox2.Text;
            PassRepeat = textBox3.Text;
            if(YonetimDB.SifreKontrol(Pass,PassRepeat) == 0)
            {
                Ad = TextBox4.Text;
                Soyad = TextBox5.Text;
                if (YonetimDB.KayitOl(Nick, Pass, Ad, Soyad, Tarih, Cinsiyet)) 
                {
                    InfoLabel.Text = "Merhaba " + Nick + " Kaydınız Başarı ile oluşturuldu.";
                }
                else
                {
                    InfoLabel.Text = "Girilen Alanların Eksiksiz olduğundan Emin olun!";
                }
            }
            else if(YonetimDB.SifreKontrol(Pass, PassRepeat) == 1)
            {
                InfoLabel.Text = "Şifre(ler) Boş bırakılamaz!";
            }
            else if(YonetimDB.SifreKontrol(Pass, PassRepeat) == 2)
            {
                InfoLabel.Text = "Girmiş olduğunuz Şifreler Uyuşmuyor!";
            }
            else if(YonetimDB.SifreKontrol(Pass,PassRepeat) == 4)
            {
                InfoLabel.Text = "Kullanmak istediğiniz Şifre Fazla Uzun ya da Kısa!";
            }
            else
            {
                InfoLabel.Text = "Beklenmeyen Hata!";
            }
        }
        else
        {
            InfoLabel.Text = "Kullanmak istediğiniz KullanıcıAdı zaten var.";
        }   
    }
}