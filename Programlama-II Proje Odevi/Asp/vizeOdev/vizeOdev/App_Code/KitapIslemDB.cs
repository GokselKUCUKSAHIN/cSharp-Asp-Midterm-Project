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
/// Summary description for KitapIslemDB
/// </summary>
public class KitapIslemDB
{
    static string by = ConfigurationManager.ConnectionStrings["DBYolu"].ToString();
    static SqlConnection conn = new SqlConnection(by);
    public static DataSet KitapBilgiCek()
    {
        string sql = "SELECT * FROM dbo.Kitap";
        SqlCommand komut = new SqlCommand(sql, conn);
        DataSet kitapVeri = new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(kitapVeri);
        conn.Close();
        return kitapVeri;
    }
    public static DataTable KitapBilgiCek(int KitapID)
    {
        string sql = "SELECT * FROM dbo.Kitap WHERE KitapID=" + KitapID;
        SqlCommand komut = new SqlCommand(sql, conn);
        DataTable kitapVeri = new DataTable();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(kitapVeri);
        conn.Close();
        return kitapVeri;
    }
    public static string KitapIsimCek(int KitapID)
    {
        string sql = "SELECT adi FROM dbo.Kitap WHERE KitapID=" + KitapID;
        SqlCommand komut = new SqlCommand(sql, conn);
        DataTable kitapVeri = new DataTable();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(kitapVeri);
        conn.Close();
        if(kitapVeri.Rows.Count != 0)
        {
            return (string)kitapVeri.Rows[0]["adi"];
        }
        else
        {
            return "null";
        }
    }
    public static DataSet KitapAra(string Text)
    {
        Text = "%" + Text + "%";
        DataSet Sonuclar = new DataSet();
        string sql = "SELECT KitapID,Adi FROM dbo.Kitap WHERE Adi LIKE @pa";
        SqlCommand komut = new SqlCommand(sql, conn);
        komut.Parameters.AddWithValue("@pa", Text);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(Sonuclar);
        conn.Close();
        return Sonuclar;
    }
    public static DataTable YazarVeriCek(int YazarID)
    {
        string sql = "SELECT * FROM dbo.Yazar WHERE YazarID=" + YazarID;
        SqlCommand komut = new SqlCommand(sql, conn);
        DataTable YazarVeri = new DataTable();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(YazarVeri);
        conn.Close();
        return YazarVeri;
    }
    public static DataTable YazarKitapCek(int YazarID)
    {
        string sql = "SELECT * FROM dbo.Kitap WHERE YazarID=" + YazarID;
        SqlCommand komut = new SqlCommand(sql, conn);
        DataTable kitapVeri = new DataTable();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(kitapVeri);
        conn.Close();
        return kitapVeri;
    }
    public static DataTable YazarAra(string Text)
    {
        Text = "%" + Text + "%";
        DataTable Sonuclar = new DataTable();
        string sql = "SELECT YazarID,Adi+' '+Soyadi AS AdSoyad FROM Yazar WHERE Adi+' '+Soyadi LIKE @pa";
        SqlCommand komut = new SqlCommand(sql, conn);
        komut.Parameters.AddWithValue("@pa", Text);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(Sonuclar);
        conn.Close();
        return Sonuclar;
    }
    public static DataTable IncelemeceCek(int KitapID)
    {
        string sql = "Select * from KitapInceleme where KitapID=" + KitapID + " order by i_id desc";
        SqlCommand komut = new SqlCommand(sql, conn);
        DataTable IncelemeVeri = new DataTable();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(IncelemeVeri);
        conn.Close();
        return IncelemeVeri;
    }
    public static DataTable AlintiCek(int KitapID)
    {
        string sql = "Select * from KitapAlinti where KitapID=" + KitapID + " order by a_id desc";
        SqlCommand komut = new SqlCommand(sql, conn);
        DataTable AlintiVeri = new DataTable();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(AlintiVeri);
        conn.Close();
        return AlintiVeri;
    }
    public static void Okudum(int KullaniciID, int KitapID)
    {
        string sql = "insert into KitapOkuma (KullaniciID,KitapID) values(@pKulid,@pKid)";
        SqlCommand komut = new SqlCommand(sql, conn);
        komut.Parameters.AddWithValue("@pKulid",KullaniciID);
        komut.Parameters.AddWithValue("@pKid", KitapID);
        conn.Open();
        komut.ExecuteNonQuery();
        conn.Close();
    }
    public static int CountOkuma(int KitapID)
    {
        string sql = "SELECT KitapID,COUNT(KullaniciID) as Sayi from dbo.KitapOkuma WHERE kitapid= " + KitapID + " GROUP by KitapID";
        SqlCommand komut = new SqlCommand(sql, conn);
        DataTable Veri = new DataTable();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(Veri);
        conn.Close();
        if (Veri.Rows.Count != 0)
        {
            return (int)Veri.Rows[0]["Sayi"];
        }
        else
        {
            return 0;
        }
    }
    public static DataTable PopulerKitaplar()
    {
        string sql = "SELECT KitapID,COUNT(KullaniciID) as Sayi from dbo.KitapOkuma GROUP by KitapID ORDER BY Sayi DESC";
        SqlCommand komut = new SqlCommand(sql, conn);
        DataTable Veri = new DataTable();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(Veri);
        conn.Close();
        return Veri;
    }
    public static DataTable PopulerYazarlar()
    {
        string sql = "SELECT Yazar.YazarID,(Yazar.Adi + ' ' + Soyadi) AS YazarAdSoyad, COUNT(KullaniciID)AS Sayi FROM dbo.Kitap INNER JOIN dbo.Yazar ON Yazar.YazarID = Kitap.YazarID INNER JOIN dbo.KitapOkuma ON KitapOkuma.KitapID = Kitap.KitapID GROUP BY(Yazar.Adi+' ' + Soyadi),Yazar.YazarID ORDER BY Sayi DESC";
        SqlCommand komut = new SqlCommand(sql, conn);
        DataTable Veri = new DataTable();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(Veri);
        conn.Close();
        return Veri;
    }
    public static DataTable YuksekPuanliKitaplar()
    {
        string sql = "SELECT  Kitap.KitapID,Adi,AVG(puan) AS Ort FROM dbo.KitapPuan INNER JOIN dbo.Kitap ON Kitap.KitapID = KitapPuan.KitapID GROUP BY Kitap.KitapID,Adi ORDER BY Ort DESC";
        SqlCommand komut = new SqlCommand(sql, conn);
        DataTable Veri = new DataTable();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(Veri);
        conn.Close();
        return Veri;
    }
    public static void Puanla(int KullaniciID, int KitapID, int Puan)
    {
        string sql = "insert into KitapPuan (KullaniciID,KitapID,Puan) values(@pKulid,@pKid,@Puan)";
        SqlCommand komut = new SqlCommand(sql, conn);
        komut.Parameters.AddWithValue("@pKulid", KullaniciID);
        komut.Parameters.AddWithValue("@pKid", KitapID);
        komut.Parameters.AddWithValue("@Puan", Puan);
        conn.Open();
        komut.ExecuteNonQuery();
        conn.Close();
    }
    public static int PuanAvg(int KitapID)
    {
        string sql = "SELECT KitapID,AVG(Puan) as Ortalama from KitapPuan WHERE kitapid=" + KitapID + " GROUP by KitapID";
        SqlCommand komut = new SqlCommand(sql, conn);
        DataSet Veri = new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(Veri);
        conn.Close();
        if (Veri.Tables[0].Rows.Count != 0)
        {
            return (int)Veri.Tables[0].Rows[0]["Ortalama"];
        }
        else
        {
            return 0;
        }
    }
    public static int PuanCek(int KitapID,int KullaniciID)
    {
        string sql = "select * from KitapPuan where KitapID=@pkid and KullaniciID=@pkullid";
        SqlCommand komut = new SqlCommand(sql, conn);
        komut.Parameters.AddWithValue("@pkid",KitapID);
        komut.Parameters.AddWithValue("@pkullid",KullaniciID);
        DataTable Veri = new DataTable();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(Veri);
        conn.Close();
        if(Veri.Rows.Count != 0)
        {
            return (int)Veri.Rows[0]["Puan"];
        }
        else
        {
            return -1;
        }
    }
    public static void PuanUpdate(int KitapID, int KullaniciID,int NewPuan)
    {
        string sql = "update KitapPuan set Puan=@pnewP where KitapID=@pkid and KullaniciID = @pKull";
        SqlCommand komut = new SqlCommand(sql, conn);
        komut.Parameters.AddWithValue("@pnewP",NewPuan);
        komut.Parameters.AddWithValue("@pkid",KitapID);
        komut.Parameters.AddWithValue("@pKull",KullaniciID);
        conn.Open();
        komut.ExecuteNonQuery();
        conn.Close();
    }
    public static DataSet PuanOrt(int KitapID)
    {
        string sql = "SELECT KitapID,AVG(Puan) as Ortalama from dbo.KitapPuan WHERE kitapid=" + KitapID + " GROUP by KitapID";
        SqlCommand komut = new SqlCommand(sql, conn);
        DataSet Veri = new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(Veri);
        conn.Close();
        return Veri;
    }
    public static float PuanHesapla(int KitapID)
    {
        string sql1 = "SELECT KitapID,sum(Puan) AS toplam FROM dbo.KitapPuan WHERE KitapID =" + KitapID + " GROUP BY KitapID";
        SqlCommand komut = new SqlCommand(sql1, conn);
        DataTable Veri1 = new DataTable();
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(Veri1);
        conn.Close();
        string sql2 = "SELECT KitapID,count(Puan) AS Sayi FROM dbo.KitapPuan WHERE KitapID ="+ KitapID +" GROUP BY p_id";
        SqlCommand komut2 = new SqlCommand(sql1, conn);
        DataTable Veri2 = new DataTable();
        SqlDataAdapter adaptor2 = new SqlDataAdapter(komut2);
        conn.Open();
        adaptor2.Fill(Veri2);
        conn.Close();
        if ((Veri1.Rows.Count == 1) && (Veri2.Rows.Count == 1))
        {
            int Toplam =(int)Veri1.Rows[0]["toplam"];
            int Sayi = (int)Veri2.Rows[0]["Sayi"];
            return Toplam / (float)Sayi;
        }
        else
        {
            return 0;
        }
    }
    public static bool SendAlinti(int SayfaNo, string Alinti, int KitapID, int KullaniciID)
    {
        string sql = "insert into KitapAlinti (KullaniciID,KitapID,SayfaNo,Alinti) values(@pKullid,@pKid,@pS,@pA)";
        try
        {
            SqlCommand komut = new SqlCommand(sql, conn);
            komut.Parameters.AddWithValue("@pKullid", KullaniciID);
            komut.Parameters.AddWithValue("@pKid", KitapID);
            komut.Parameters.AddWithValue("@pS", SayfaNo);
            komut.Parameters.AddWithValue("@pA", Alinti);
            conn.Open();
            komut.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public static bool SendInceleme(int KitapID,int KullaniciID,string Inceleme)
    {
        string sql = "insert into KitapInceleme (KullaniciID,KitapID,Inceleme) values(@pKullid,@pKid,@pI)";
        try
        {
            SqlCommand komut = new SqlCommand(sql, conn);
            komut.Parameters.AddWithValue("@pKullid", KullaniciID);
            komut.Parameters.AddWithValue("@pKid", KitapID);
            komut.Parameters.AddWithValue("@pI", Inceleme);
            conn.Open();
            komut.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }


    //
    //ASP.NET COMMON
    //
    public KitapIslemDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}