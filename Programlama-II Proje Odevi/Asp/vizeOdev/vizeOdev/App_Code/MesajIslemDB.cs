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
/// Summary description for MesajIslemDB
/// </summary>



public class MesajIslemDB
{
    static string by = ConfigurationManager.ConnectionStrings["DBYolu"].ToString();
    static SqlConnection conn = new SqlConnection(by);

    public static DataSet KullaniciVeriCek()//Tüm verikeri Çek
    {
        string sql = "SELECT KullaniciID,NickName FROM dbo.Kullanici";
        DataSet KullaniciData = new DataSet();
        SqlCommand komut = new SqlCommand(sql, conn);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(KullaniciData);
        conn.Close();
        return KullaniciData;
    }
    public static DataSet KullaniciVeriCek(int EID)//Belirtilen ID hariç Tüm verileri Çek
    {
        DataSet KullaniciData = new DataSet();
        string sql = "SELECT KullaniciID,NickName FROM dbo.Kullanici where KullaniciID <>" + EID;
        SqlCommand komut = new SqlCommand(sql, conn);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(KullaniciData);
        conn.Close();
        return KullaniciData;
    }
    public static bool MesajYolla(int GonderenID, int GidenID, string Baslik, string Mesaj, DateTime Tarih)
    {
        string cTarih = Tarih.ToShortDateString();
        if (Baslik != String.Empty)
        {
            string sql = "insert into MesajTablo(GonderenID,GidenID,Baslik,Mesaj,Tarih) values(@pS,@pR,@pB,@pM,@pT)";
            SqlCommand komut = new SqlCommand(sql, conn);
            komut.Parameters.AddWithValue("@pS", GonderenID);
            komut.Parameters.AddWithValue("@pR", GidenID);
            komut.Parameters.AddWithValue("@pB", Baslik);
            komut.Parameters.AddWithValue("@pM", Mesaj);
            komut.Parameters.AddWithValue("@pT", cTarih);
            conn.Open();
            komut.ExecuteNonQuery();
            conn.Close();

            return true;
        }
        else
        {
            return false;
        }
    }
    public static DataSet GelenMesajlar(int ID)//Belirtilen ID'ye gönderilen Mesajları Çek
    {
        DataSet Veri = new DataSet();
        string sql = "SELECT MesajID,GonderenID,Baslik,Mesaj,Tarih FROM MesajTablo WHERE GidenID=" + ID + " ORDER BY MesajID DESC";
        //Gelme sırasına göre ters gönderiliyor. First in Last Out.
        SqlCommand komut = new SqlCommand(sql, conn);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(Veri);
        conn.Close();
        return Veri;
    }
    public static DataTable MesajInfo(int MesajID)//MesajID ile Mesaj Çekme
    {
        DataTable Msg = new DataTable();
        string sql = "SELECT GonderenID,Baslik,Mesaj,Tarih FROM dbo.MesajTablo WHERE MesajID="+MesajID;
        SqlCommand komut = new SqlCommand(sql, conn);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(Msg);
        conn.Close();
        return Msg;
    }
    public static bool MesajKontrol(int MesajID,int UserID)
    {
        DataTable Msg = new DataTable();
        string sql = "SELECT GidenID,MesajID FROM dbo.MesajTablo WHERE MesajID=@pmiD AND GidenID=@pID";
        SqlCommand komut = new SqlCommand(sql, conn);
        komut.Parameters.AddWithValue("@pmiD", MesajID);
        komut.Parameters.AddWithValue("@pID", UserID);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        conn.Open();
        adaptor.Fill(Msg);
        conn.Close();
        if(Msg.Rows.Count!=0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool MesajSil(int MesajID)
    {
        try
        {
            string sql = "DELETE FROM dbo.MesajTablo WHERE MesajID =" + MesajID;
            SqlCommand komut = new SqlCommand(sql, conn);
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
    //ASP Common
    //
    public MesajIslemDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}