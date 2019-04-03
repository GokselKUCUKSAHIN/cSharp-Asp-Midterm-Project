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
/// Summary description for TavsiyeDB
/// </summary>
public class TavsiyeDB
{
    static string by = ConfigurationManager.ConnectionStrings["DBYolu"].ToString();
    static SqlConnection conn = new SqlConnection(by);

    

    public static DataTable PuanTavsiye(int KullaniciID)
    {
        string sql = "SELECT NickName,KitapPuan.KullaniciID,KitapID,Puan FROM dbo.KitapPuan INNER JOIN dbo.Kullanici ON Kullanici.KullaniciID = KitapPuan.KullaniciID WHERE KitapPuan.KullaniciID <> @pU ORDER BY KitapID,KitapPuan.KullaniciID,Puan";
        SqlCommand komut = new SqlCommand(sql, conn);
        komut.Parameters.AddWithValue("@pU",KullaniciID);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        DataTable Veri = new DataTable();
        conn.Open();
        adaptor.Fill(Veri);
        conn.Close();
        return Veri;
    }
    public static DataTable PuanKullanici(int KullaniciID)
    {
        string sql= "SELECT KullaniciID,KitapID,Puan FROM dbo.KitapPuan WHERE KullaniciID = @pU";
        SqlCommand komut = new SqlCommand(sql, conn);
        komut.Parameters.AddWithValue("@pU", KullaniciID);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        DataTable Veri = new DataTable();
        conn.Open();
        adaptor.Fill(Veri);
        conn.Close();
        return Veri;
    }
    //
    //
    public static DataTable OkumaTavsiye(int KullaniciID)
    {
        string sql = "SELECT DISTINCT NickName,KitapOkuma.KullaniciID,KitapID FROM dbo.KitapOkuma INNER JOIN dbo.Kullanici ON Kullanici.KullaniciID = KitapOkuma.KullaniciID WHERE KitapOkuma.KullaniciID <> @pU ORDER BY KitapID";
        SqlCommand komut = new SqlCommand(sql, conn);
        komut.Parameters.AddWithValue("@pU", KullaniciID);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        DataTable Veri = new DataTable();
        conn.Open();
        adaptor.Fill(Veri);
        conn.Close();
        return Veri;
    }
    public static DataTable OkumaKullanici(int KullaniciID)
    {
        string sql = "SELECT DISTINCT NickName,KitapOkuma.KullaniciID,KitapID FROM dbo.KitapOkuma INNER JOIN dbo.Kullanici ON Kullanici.KullaniciID = KitapOkuma.KullaniciID WHERE KitapOkuma.KullaniciID = @pU ORDER BY KitapID";
        SqlCommand komut = new SqlCommand(sql, conn);
        komut.Parameters.AddWithValue("@pU", KullaniciID);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        DataTable Veri = new DataTable();
        conn.Open();
        adaptor.Fill(Veri);
        conn.Close();
        return Veri;
    }
    public TavsiyeDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}