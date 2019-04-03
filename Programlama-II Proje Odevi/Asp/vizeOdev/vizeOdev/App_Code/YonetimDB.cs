using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
//ADO.NET Classes
using System.Data;
using System.Data.SqlClient;
//ASP CONFIG
using System.Configuration;

/// <summary>
/// Summary description for YonetimDB
/// </summary>
public class YonetimDB
{
    static string by = ConfigurationManager.ConnectionStrings["DBYolu"].ToString();
    static SqlConnection conn = new SqlConnection(by);

    //
    //LOGIN
    //
    public static bool KayitOl(string Nick, string Pass, string Adi, string Soyadi, string DTarih, string Cinsiyet)
    {
        if ((Nick != String.Empty) && (Adi != String.Empty) && (Soyadi != String.Empty))
        {
            string sql = "insert into Kullanici(NickName,Password,Adi,Soyadi,DogumTarih,Cinsiyet) values (@pN,@pP,@pa,@ps,@pd,@pc)";
            SqlCommand komut = new SqlCommand(sql, conn);
            komut.Parameters.AddWithValue("@pN", Nick);
            komut.Parameters.AddWithValue("@pP", Pass);
            komut.Parameters.AddWithValue("@pa", Adi);
            komut.Parameters.AddWithValue("@ps", Soyadi);
            komut.Parameters.AddWithValue("@pd", DTarih);
            komut.Parameters.AddWithValue("@pc", Cinsiyet);
            conn.Open();
            komut.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        else
            return false;
    }
    public static int GirisYap(string Nick, string Pass)//Kullaniciadi Sifre ile Giriş yapma
    {
        //string sql = "select * from Kisiler where Adi like @pa";
        string sql = "SELECT * FROM dbo.Kullanici WHERE NickName =@pN AND Password =@ps";
        SqlCommand komut = new SqlCommand(sql, conn);
        komut.Parameters.AddWithValue("@pN", Nick);
        komut.Parameters.AddWithValue("@ps", Pass);
        DataTable dt = new DataTable();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(dt);
        conn.Close();
        if (dt.Rows.Count == 1)
        {
            //table.rows[rowindex][columnindex]
            int id = (int)dt.Rows[0]["KullaniciID"];

            /*
            foreach (DataRow row in dt.Rows)
            {
                id = (int)row["KullaniciID"];
                //nick = (string)row["NickName"]
            }*/

            return id;
        }
        else
        {
            return -1;
        }
    }
    public static byte SifreKontrol(string Pass1, string Pass2)
    {
        if ((Pass1 == Pass2) && (Pass1.Length >= 6) && (Pass2.Length <= 20))
        {
            //Her iki string de Aynı ve 6 ile 20 hane arasında ise '0';
            return 0;
        }
        else if((Pass1.Length < 6) || (Pass2.Length > 20))
        {
            //Geçersiz Şifre Uzunluğu
            return 4;
        }
        else if ((Pass1 == String.Empty) || (Pass2 == String.Empty))
        {
            //Alanlardan Birisi ya da her ikiside Boş ise '1';
            return 1;
        }
        else if (Pass1 != Pass2)
        {
            //Alanlardaki değerler bir birinden farklı ise '2';
            return 2;
        }
        else
        {
            //Bu kısıma Hiç bir zaman düşmemesi lazım...
            return 3;
        }
    }
    public static bool NickNameKontrol(string Name)
    {
        string sql = "SELECT NickName FROM dbo.Kullanici WHERE NickName = @pN";
        SqlCommand komut = new SqlCommand(sql, conn);
        komut.Parameters.AddWithValue("@pN", Name);
        DataTable dt = new DataTable();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(dt);
        conn.Close();
        if (dt.Rows.Count == 1)
        {
            //Eğer Aratılan İsim ile daha önceden bir kayıt oluşturulmuşsa: True
            return true;

        }
        else
        {
            //Eğer Aratılan İsim ile daha önceden oluşturulmuş bir kayıt yoksa: False
            return false;
        }
    }

    //
    //DATE CONVERTION
    //
    public static string DateConverter(string Date)
    {
        if (Date.Length == 9)
        {
            //Gün/Ay/Yılı -- Ay/Gün/Yıl yapmak
            //Eğer uzunluk 9 ile Gün bölümü 1, 2, 3, 4, 5, 6, 7, 8, 9 dur
            //1.01.2000 like 
            string nDate = String.Empty;
            nDate = Date[2].ToString() + Date[3].ToString() + '.' + Date[0].ToString() + '.' + Date[5].ToString() + Date[6].ToString() + Date[7].ToString() + Date[8].ToString();

            return nDate;
        }
        else //(Date.Length ==10)
        {
            //11.29.2010 like
            string nDate = String.Empty;
            nDate = Date[3].ToString() + Date[4].ToString() + '.' + Date[0].ToString() + Date[1].ToString() + '.' + Date[6].ToString() + Date[7].ToString() + Date[8].ToString() + Date[9].ToString();
            return nDate;
        }
    }
    public static string DateConverter(string Date, char Sep)
    {
        if (Date.Length == 9)
        {
            //Gün/Ay/Yılı -- Ay/Gün/Yıl yapmak
            //Eğer uzunluk 9 ile Gün bölümü 1, 2, 3, 4, 5, 6, 7, 8, 9 dur
            //1.01.2000 like 
            string nDate = String.Empty;
            nDate += Date[2].ToString() + Date[3].ToString() + Sep + Date[0].ToString() + Sep + Date[5].ToString() + Date[6].ToString() + Date[7].ToString() + Date[8].ToString();
            return nDate;
        }
        else //(Date.Length ==10)
        {
            //11.29.2010 like
            string nDate = String.Empty;
            nDate += Date[3].ToString() + Date[4].ToString() + Sep + Date[0].ToString() + Date[1].ToString() + Sep + Date[6].ToString() + Date[7].ToString() + Date[8].ToString() + Date[9].ToString();
            return nDate;
        }
    }
    public static string DateConverter(DateTime DateT)
    {
        string Date = DateT.ToShortDateString();
        if (Date.Length == 9)
        {
            //Gün/Ay/Yılı -- Ay/Gün/Yıl yapmak
            //Eğer uzunluk 9 ile Gün bölümü 1, 2, 3, 4, 5, 6, 7, 8, 9 dur
            //1.01.2000 like 
            string nDate = String.Empty;
            nDate = Date[2].ToString() + Date[3].ToString() + '.' + Date[0].ToString() + '.' + Date[5].ToString() + Date[6].ToString() + Date[7].ToString() + Date[8].ToString();

            return nDate;
        }
        else //(Date.Length ==10)
        {
            //11.29.2010 like
            string nDate = String.Empty;
            nDate = Date[3].ToString() + Date[4].ToString() + '.' + Date[0].ToString() + Date[1].ToString() + '.' + Date[6].ToString() + Date[7].ToString() + Date[8].ToString() + Date[9].ToString();
            return nDate;
        }
    }
    public static string DateConverter(DateTime DateT, char Sep)
    {
        string Date = DateT.ToShortDateString();
        if (Date.Length == 9)
        {
            //Gün/Ay/Yılı -- Ay/Gün/Yıl yapmak
            //Eğer uzunluk 9 ile Gün bölümü 1, 2, 3, 4, 5, 6, 7, 8, 9 dur
            //1.01.2000 like 
            string nDate = String.Empty;
            nDate += Date[2].ToString() + Date[3].ToString() + Sep + Date[0].ToString() + Sep + Date[5].ToString() + Date[6].ToString() + Date[7].ToString() + Date[8].ToString();
            return nDate;
        }
        else //(Date.Length ==10)
        {
            //11.29.2010 like
            string nDate = String.Empty;
            nDate += Date[3].ToString() + Date[4].ToString() + Sep + Date[0].ToString() + Date[1].ToString() + Sep + Date[6].ToString() + Date[7].ToString() + Date[8].ToString() + Date[9].ToString();
            return nDate;
        }
    }

    //
    //DATA GET
    //
    public static string KullaniciNick(int id)//ID ile İsim Çekme
    {
        try//try catch yapısı düzgün değil!!
        {
            //Kullanici Tablosunun KullaniciIDsi (id) olanlarının NickNamelerini Seçen SQL. 
            string sql = "SELECT NickName FROM dbo.Kullanici WHERE KullaniciID =" + id;

            SqlCommand komut = new SqlCommand(sql, conn);

            DataTable dt = new DataTable();
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            conn.Open();
            adaptor.Fill(dt);
            conn.Close();
            string Nick = String.Empty;
            //table.rows[rowindex][columnindex]
            Nick = (string)dt.Rows[0]["NickName"];
            return Nick;
        }
        catch
        {
            return "Error";
        }

    }
    public static DataSet KullaniciArama(string Text)//Kullanici AD-SOYAD ile arama
    {
        Text = "%" + Text + "%";
        DataSet Sonuclar = new DataSet();
        string sql = "SELECT KullaniciID,Adi+' '+Soyadi AS AdSoyad FROM dbo.Kullanici WHERE Adi+' '+Soyadi LIKE @pa";
        SqlCommand komut = new SqlCommand(sql, conn);
        komut.Parameters.AddWithValue("@pa", Text);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(Sonuclar);
        conn.Close();
        return Sonuclar;
    }
    public static DataSet KullaniciNickArama(string Text)
    {
        Text = "%" + Text + "%";
        DataSet Sonuclar = new DataSet();
        string sql = "SELECT KullaniciID,NickName FROM dbo.Kullanici WHERE NickName LIKE @pa";
        SqlCommand komut = new SqlCommand(sql, conn);
        komut.Parameters.AddWithValue("@pa", Text);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(Sonuclar);
        conn.Close();
        return Sonuclar;
    }
    public static DataSet KullaniciProfilData(int id)//ID ile TÜM Profil Bilgisini Çekme
    {
        string sql = "SELECT NickName,Adi,Soyadi,DogumTarih,Cinsiyet FROM dbo.Kullanici WHERE KullaniciID =" + id;
        SqlCommand komut = new SqlCommand(sql, conn);
        DataSet ProfileData = new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(ProfileData);
        conn.Close();
        return ProfileData;
    }
    public static DataSet KullaniciProfilData(string NickName)//NickName ile TÜM Profil Bilgisini Çekme
    {
        string sql = "SELECT NickName,Adi,Soyadi,DogumTarih,Cinsiyet FROM dbo.Kullanici WHERE NickName = @pN";
        SqlCommand komut = new SqlCommand(sql, conn);
        komut.Parameters.AddWithValue("@pN", NickName);
        DataSet ProfileData = new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(ProfileData);
        conn.Close();
        return ProfileData;
    }
    public static string BoslukDoldur(string Text,int a)//Düzenleme için yazdım ama kullanmadım.
    {
        if (Text.Length > 25)
            return Text;
        else
        {
            string newText = String.Empty;
            int LenText = Text.Length;
            int x = 29 - (14 + LenText);
            char Space = ' ';
            for (int i = 0; i < x; i++)
            {
                newText= newText + Space;
            }
            newText += Text;
            return newText;
        }
    }
    public static string BoslukDoldur(int Len,int Type)//Düzenleme için yazdım ama kullanmadım.
    {
        if (Len > 25)
            return String.Empty;
        else
        {
            string newText = String.Empty;
            int x = 40 - (Type + Len);
            for (int i = 0; i < x; i++)
            {
                newText += "&nbsp";
            }
            return newText;
        }
    }
    public static DataTable KullaniciOkuduguKitap(int KullaniciID)//KullaniciID ile Okuduğu tüm kitapları çekme
    {
        string sql = "select distinct * from KitapOkuma where KullaniciID= " + KullaniciID;
        SqlCommand komut = new SqlCommand(sql, conn);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        DataTable Veri = new DataTable();
        conn.Open();
        adaptor.Fill(Veri);
        conn.Close();
        return Veri;
    }
    public static DataTable VerdigiPuan(int KullaniciID)
    {
        string sql = "select * from KitapPuan where KullaniciID= " + KullaniciID;
        SqlCommand komut = new SqlCommand(sql, conn);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        DataTable Veri = new DataTable();
        conn.Open();
        adaptor.Fill(Veri);
        conn.Close();
        return Veri;
    }
    public static DataTable IncelemeList(int KullaniciID)
    {
        string sql = "select * from KitapInceleme where KullaniciID= " + KullaniciID;
        SqlCommand komut = new SqlCommand(sql, conn);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        DataTable Veri = new DataTable();
        conn.Open();
        adaptor.Fill(Veri);
        conn.Close();
        return Veri;
    }
    public static DataTable AlintiList(int KullaniciID)
    {
        string sql = "select * from KitapAlinti where KullaniciID= " + KullaniciID;
        SqlCommand komut = new SqlCommand(sql, conn);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        DataTable Veri = new DataTable();
        conn.Open();
        adaptor.Fill(Veri);
        conn.Close();
        return Veri;
    }
    
    
    //
    //ADMIN
    //
    public static int AdminLogin(string AdminName, string AdminPassword)
    {
        string sql = "SELECT * FROM Admin WHERE AdminID =@pN AND Password =@ps";
        SqlCommand komut = new SqlCommand(sql, conn);
        komut.Parameters.AddWithValue("@pN", AdminName);
        komut.Parameters.AddWithValue("@ps", AdminPassword);
        DataTable dt = new DataTable();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(dt);
        conn.Close();
        if (dt.Rows.Count == 1)
        {
            //table.rows[rowindex][columnindex]
            int id = (int)dt.Rows[0]["Id"];
            return id;
        }
        else
        {
            return -1;
        }
    }



    //
    //Common
    //
    public YonetimDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}