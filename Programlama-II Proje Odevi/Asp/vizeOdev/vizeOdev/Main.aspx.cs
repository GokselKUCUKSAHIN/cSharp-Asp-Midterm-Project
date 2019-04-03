using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Main : System.Web.UI.Page
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
            labelPopulerKitap.Text = PopulerKitapList();
            labelPopulerYazar.Text = PopulerYazarList();
            labelYuksekPuanliKitap.Text = YuksekPuanliKitapList();
        }
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Session["giris"] = false;
        Session["KullaniciID"] = -1;
        Response.Redirect("Login.aspx?mesaj=Başarı ile Çıkış yapıldı.");
    }
    protected string KitapAraList()
    {
        string Search = textBoxKitapAra.Text;
        if(Search != String.Empty)
        {
            DataSet Veri = KitapIslemDB.KitapAra(Search);
            if(Veri.Tables[0].Rows.Count != 0)
            {
                int satir =Veri.Tables[0].Rows.Count;
                string Ret = String.Empty;
                int KitapID;
                string KitapAdi;
                for (int i = 0; i < satir; i++)
                {
                    KitapAdi = (string)Veri.Tables[0].Rows[i]["Adi"];
                    KitapID = (int)Veri.Tables[0].Rows[i]["KitapID"];
                    Ret += "<a href=\"Kitap.aspx?Kitapid="+ KitapID+"\">"+KitapAdi+"</a><br/>";
                }
                return Ret;
            }
            else
            {
                return "<strong style=\"color:#FFE57F;\">Aradığınız kelime ile alakalı kitap bulunamadı.</strong>";
            }
        }
        else
        {
            return "<strong style=\"color:white;\">(Aramak istediğiniz kitabın ismini yazın.)</strong>";
        }
    }
    protected string KullaniciAraList()
    {
        string Search = textBoxKullaniciAra.Text;
        if (Search != String.Empty)
        {
            DataSet Veri = YonetimDB.KullaniciNickArama(Search);
            if (Veri.Tables[0].Rows.Count != 0)
            {
                int satir = Veri.Tables[0].Rows.Count;
                string Ret = String.Empty;
                int KullaniciID;
                string Nick;
                for (int i = 0; i < satir; i++)
                {
                    Nick = (string)Veri.Tables[0].Rows[i]["NickName"];
                    KullaniciID = (int)Veri.Tables[0].Rows[i]["KullaniciID"];
                    Ret += "<a href=\"Kullanici.aspx?id=" + KullaniciID + "\">" + Nick + "</a><br/>";
                }
                return Ret;
            }
            else
            {
                return "<strong style=\"color:#FFE57F;\">Aradığınız kelime ile alakalı Kullanıcı bulunamadı.</strong>";
            }
        }
        else
        {
            return "<strong style=\"color:white;\">(Aramak istediğiniz Kullanıcının ismini yazın.)</strong>";
        }
    }
    protected string YazarAraList()
    {
        string Search = textBoxYazarAra.Text;
        if (Search != String.Empty)
        {
            DataTable Veri = KitapIslemDB.YazarAra(Search);
            if (Veri.Rows.Count != 0)
            {
                int satir = Veri.Rows.Count;
                string Ret = String.Empty;
                int YazarID;
                string YazarAdSoyad;
                for (int i = 0; i < satir; i++)
                {
                    YazarAdSoyad = (string)Veri.Rows[i]["AdSoyad"];
                    YazarID = (int)Veri.Rows[i]["YazarID"];
                    Ret += "<a href=\"YazarDetay.aspx?Yazarid=" + YazarID + "\">" + YazarAdSoyad + "</a><br/>";
                }
                return Ret;
            }
            else
            {
                return "<strong style=\"color:#FFE57F;\">Aradığınız kelime ile alakalı Yazar bulunamadı.</strong>";
            }
        }
        else
        {
            return "<strong style=\"color:white;\">(Aramak istediğiniz Yazarın ismini yazın.)</strong>";
        }
    }
    protected string PopulerKitapList()
    {
        string Ret = String.Empty;
        DataTable Veri = KitapIslemDB.PopulerKitaplar();
        int satir = Veri.Rows.Count;
        if((satir <= 10)&&( satir != 0))
        {
            //0-10 tane kitap var
            //"<a href=\"Kullanici.aspx?id=" + KullaniciID + "\">" + Nick + "</a><br/>"
            int KitapID;
            string KitapAdi;
            int Sayi;
            for (int i = 0; i < satir; i++)
            {
                KitapID = (int)Veri.Rows[i]["KitapID"];
                DataTable kitap = KitapIslemDB.KitapBilgiCek(KitapID);
                KitapAdi = (string)kitap.Rows[0]["Adi"];
                Sayi = (int)Veri.Rows[i]["Sayi"];
                Ret += "<a href=\"Kitap.aspx?Kitapid=" + KitapID + "\">" + KitapAdi + "</a><strong> : "+ Sayi +"</strong><br/>";
            }
            return Ret;
        }
        else if(satir >10)
        {
            //kitap var ama 10 dan fazla
            int KitapID;
            string KitapAdi;
            int Sayi;
            for (int i = 0; i < 10; i++)
            {
                KitapID = (int)Veri.Rows[i]["KitapID"];
                DataTable kitap = KitapIslemDB.KitapBilgiCek(KitapID);
                KitapAdi = (string)kitap.Rows[0]["Adi"];
                Sayi = (int)Veri.Rows[i]["Sayi"];
                Ret += "<a href=\"Kitap.aspx?Kitapid=" + KitapID + "\">" + KitapAdi + "</a><strong> : " + Sayi + "</strong><br/>"; 
            }
            return Ret;
        }
        else
        {
            //kitap Yok
            Ret = "Kitap Bulunamadı.";
            return Ret;
        }
    }
    protected string PopulerYazarList()
    {
        string Ret = String.Empty;
        DataTable Veri = KitapIslemDB.PopulerYazarlar();
        int satir = Veri.Rows.Count;
        if ((satir <= 10) && (satir != 0))
        {
            //0-10 tane yazar var
            //"<a href=\"Kullanici.aspx?id=" + KullaniciID + "\">" + Nick + "</a><br/>"
            int YazarID;
            string YazarAdSoyad;
            int Sayi;
            for (int i = 0; i < satir; i++)
            {
                YazarID = (int)Veri.Rows[i]["YazarID"];
                YazarAdSoyad = (string)Veri.Rows[i]["YazarAdSoyad"];
                Sayi = (int)Veri.Rows[i]["Sayi"];
                Ret += "<a href=\"YazarDetay.aspx?Yazarid=" + YazarID + "\">" + YazarAdSoyad + "</a><strong> : " + Sayi + "</strong><br/>";
            }
            return Ret;
        }
        else if (satir > 10)
        {
            //yazar var ama 10 dan fazla
            int YazarID;
            string YazarAdSoyad;
            int Sayi;
            for (int i = 0; i < 10; i++)
            {
                YazarID = (int)Veri.Rows[i]["YazarID"];
                YazarAdSoyad = (string)Veri.Rows[i]["YazarAdSoyad"];
                Sayi = (int)Veri.Rows[i]["Sayi"];
                Ret += "<a href=\"YazarDetay.aspx?Yazarid=" + YazarID + "\">" + YazarAdSoyad + "</a><strong> : " + Sayi + "</strong><br/>";
            }
            return Ret;
        }
        else
        {
            //yazar Yok
            Ret = "Yazar Bulunamadı.";
            return Ret;
        }
    }
    protected string YuksekPuanliKitapList()
    {
        string Ret = String.Empty;
        DataTable Veri = KitapIslemDB.YuksekPuanliKitaplar();
        int satir = Veri.Rows.Count;
        if ((satir <= 10) && (satir != 0))
        {
            //0-10 tane kitap var
            //"<a href=\"Kullanici.aspx?id=" + KullaniciID + "\">" + Nick + "</a><br/>"
            int KitapID;
            string KitapAdi;
            int Sayi;
            for (int i = 0; i < satir; i++)
            {
                KitapID = (int)Veri.Rows[i]["KitapID"];
                KitapAdi = (string)Veri.Rows[i]["Adi"];
                Sayi = (int)Veri.Rows[i]["Ort"];
                Ret += "<a href=\"Kitap.aspx?Kitapid=" + KitapID + "\">" + KitapAdi + "</a><strong> : " + Sayi + "</strong><br/>";
            }
            return Ret;
        }
        else if (satir > 10)
        {
            //kitap var ama 10 dan fazla
            int KitapID;
            string KitapAdi;
            int Sayi;
            for (int i = 0; i < 10; i++)
            {
                KitapID = (int)Veri.Rows[i]["KitapID"];
                KitapAdi = (string)Veri.Rows[i]["Adi"];
                Sayi = (int)Veri.Rows[i]["Ort"];
                Ret += "<a href=\"Kitap.aspx?Kitapid=" + KitapID + "\">" + KitapAdi + "</a><strong> : " + Sayi + "</strong><br/>";
            }
            return Ret;
        }
        else
        {
            //Kitap Yok
            Ret = "Kitap Bulunamadı.";
            return Ret;
        }
    }
    protected void buttonKitapAra_Click(object sender, EventArgs e)
    {
        labelKitapAra.Text = KitapAraList();
    }
    protected void buttonKullaniciAra_Click(object sender, EventArgs e)
    {
        labelKullaniciAra.Text = KullaniciAraList();
    }
    protected void buttonYazarAra_Click(object sender, EventArgs e)
    {
        labelYazarAra.Text = YazarAraList();
    }

    //
    //Tavsiye
    //
    
    protected string PuanTavsiye()
    {
        DataTable O = TavsiyeDB.PuanTavsiye((int)Session["KullaniciID"]);
        DataTable M = TavsiyeDB.PuanKullanici((int)Session["KullaniciID"]);
        int mS = M.Rows.Count;
        int oS = O.Rows.Count;

        List<string> NickNameList = new List<string>();
        List<int> IDList = new List<int>();

        if ((mS != 0 ) && (oS !=0))
        {
            for (int i = 0; i < mS; i++)
            {
                int kitapid = (int)M.Rows[i]["KitapID"];
                int puan = (int)M.Rows[i]["Puan"];
                for (int j = 0; j < oS; j++)
                {
                    int k = (int)O.Rows[j]["KitapID"];
                    int p = (int)O.Rows[j]["Puan"];
                    if ((kitapid == k) && (puan == p)) 
                    {
                        string Name = (string)O.Rows[j]["NickName"];
                        int Uid = (int)O.Rows[j]["KullaniciID"];
                        NickNameList.Add(Name);
                        IDList.Add(Uid);
                    }
                }
            }

            if ((NickNameList.Count == IDList.Count) && (NickNameList.Count != 0) && (IDList.Count != 0))
            {
                string Ret = String.Empty;
                
                for (int i = 0; i < IDList.Count; i++)
                {
                    string a = NickNameList[i];
                    int g = IDList[i];

                    Ret += "<b><a class=\"jelly\" href=\"Kullanici.aspx?id="+g+"\">"+a+"</a></b><br/>";
                }

                //
                //Öneri 3
                //
                for (int i = 0; i < IDList.Count; i++)
                {
                    if(!Oneri3.Contains(IDList[i]))
                    {
                        Oneri3.Add(IDList[i]);
                    }
                }



                return Ret; 
            }
            else
            {
                return "<h2>Verdiğiniz Puanlar Eşsiz<h2>";
            }
        }
        else
        {
            //Veri Yoksa
            return "<h2>Yerterli Data Yok!<h2>";
        }
    }
    protected string OkumaTavsiye()
    {
        //
        //Bulma
        //
        DataTable O = TavsiyeDB.OkumaTavsiye((int)Session["KullaniciID"]);
        DataTable M = TavsiyeDB.OkumaKullanici((int)Session["KullaniciID"]);
        int mS = M.Rows.Count;
        int oS = O.Rows.Count;

        List<int> OrtakKitap = new List<int>();

        if ((mS != 0) && (oS != 0))
        {
            for (int i = 0; i < mS; i++)
            {
                int kitapid = (int)M.Rows[i]["KitapID"];
                for (int j = 0; j < oS; j++)
                {
                    int k = (int)O.Rows[j]["KitapID"];
                    int u = (int)O.Rows[j]["KullaniciID"];
                    if(k == kitapid)
                    {
                        OrtakKitap.Add(u);
                    }
                }
            }
            //
            //Sayma
            //
            OrtakKitap.Sort();
            int indis = 0;
            List<int> Sayi = new List<int>();
            List<int> Tekil = new List<int>();
            Sayi.Add(1);
            for (int i = 0; i < OrtakKitap.Count; ++i)
            {
                if (!Tekil.Contains(OrtakKitap[i]))
                {
                    Tekil.Add(OrtakKitap[i]);
                    indis++;
                    Sayi.Add(1);
                }
                else
                {
                    Sayi[indis] = Sayi[indis] + 1;
                }
            }
            Sayi.RemoveAt(0);

            //
            //İsimlerin Çekilmesi
            //
            List<string> NickS = new List<string>();
            for (int i = 0; i < Tekil.Count; i++)
            {
                string UserName = YonetimDB.KullaniciNick(Tekil[i]);
                NickS.Add(UserName);
            }
            //
            //Yazdırma
            //
            /*
            string Ret = String.Empty;
            foreach (string a in NickS)
            {
                Ret += a + "<br/>";
            }
            return Ret;*/
            if ((Sayi.Count != 0) && (Tekil.Count != 0) && (NickS.Count != 0) && (Sayi.Count == Tekil.Count) && (Tekil.Count == NickS.Count)) 
            {
                string Ret = String.Empty;
                string UName = String.Empty;
                int Uid = -1;
                int Quantity = -1;
                for (int i = 0; i < Sayi.Count; i++)
                {
                    Uid = Tekil[i];
                    UName = NickS[i];
                    Quantity = Sayi[i];
                    Ret += "<b><a class=\"jelly\" href=\"Kullanici.aspx?id=" + Uid + "\">" + UName + "</a>: " + Quantity + "</b><br/>";
                }

                //
                //Öneri 3
                //
                for (int i = 0; i < Tekil.Count; i++)
                {
                    if (!Oneri3.Contains(Tekil[i]))
                    {
                        Oneri3.Add(Tekil[i]);
                    }
                }

                return Ret;
            }
            else
            {
                return "<h2>Beklenmeyen veri hatası</h2>";
            }         
        }
        else
        {
            return "<h2>Yeterli Veri yok</h2>";
        }
    }

    //
    //Öneri 1 ve 2 den gelen kullanicilarin listesi
    //
    List<int> Oneri3 = new List<int>();
    //
    protected string KitapTavsiye()
    {
        //
        //Öneri 1 ve 2 den gelen kullanicilarin okuğu kitaplarin listesi(tekrarsız)
        //
        List<int> OtherBooks = new List<int>();
        foreach (int a in Oneri3)
        {
            DataTable Veri = YonetimDB.KullaniciOkuduguKitap(a);
            if(Veri.Rows.Count != 0)
            {
                for (int i = 0; i < Veri.Rows.Count; i++)
                {
                    if(!OtherBooks.Contains((int)Veri.Rows[i]["KitapID"]))
                    {
                        OtherBooks.Add((int)Veri.Rows[i]["KitapID"]);
                    }
                }
            }
        }
        OtherBooks.Sort();
        //

        //
        //Giriş yapmış olan kullanicinin okuduğu kitap listesi
        //

        List<int> MyBooks = new List<int>();

        DataTable Data = YonetimDB.KullaniciOkuduguKitap((int)Session["KullaniciID"]);
        if(Data.Rows.Count != 0)
        {
            for (int i = 0; i < Data.Rows.Count; i++)
            {
                if (!MyBooks.Contains((int)Data.Rows[i]["KitapID"]))
                {
                    MyBooks.Add((int)Data.Rows[i]["KitapID"]);
                }
            }
        }
        MyBooks.Sort();

        //
        //Diğerlerin Okudugu ama Giriş yapan kullanicinin okumadığı kitapların listesi
        //
        List<int> KitapOneriList = new List<int>();
        //

        if((MyBooks.Count != 0) && (OtherBooks.Count !=0))
        {
            for (int i = 0; i < OtherBooks.Count; i++)
            {
                if(!MyBooks.Contains(OtherBooks[i]))
                {
                    KitapOneriList.Add(OtherBooks[i]);
                }
            }
            KitapOneriList.Sort();
        }
        //10 dan az ise rastgeliğin anlamı yok
        if((KitapOneriList.Count!=0) && (KitapOneriList.Count <=10))
        {
            //Yazdir
            string Ret = String.Empty;
            
            foreach (int kitapid in KitapOneriList)
            {
                string KitapAdi = KitapIslemDB.KitapIsimCek(kitapid);

                Ret += "<b><a class=\"jelly\" href=\"Kitap.aspx?Kitapid=" + kitapid + "\">" + KitapAdi + "</a></b><br/>";
            }
            return Ret;
        }
        else if((KitapOneriList.Count != 0) && (KitapOneriList.Count >= 10))
        {
            string Ret = String.Empty;
            Random rand = new Random();
            List<int> Rindex = new List<int>();
            do
            {
                int r = rand.Next(0, KitapOneriList.Count);
                if (!Rindex.Contains(r))
                    Rindex.Add(r);
            }
            while (Rindex.Count != 10);
            


            foreach (int index in Rindex)
            {
                int kitapid = KitapOneriList[index];
                string KitapAdi = KitapIslemDB.KitapIsimCek(kitapid);

                Ret += "<b><a class=\"jelly\" href=\"Kitap.aspx?Kitapid=" + kitapid + "\">" + KitapAdi + "</a></b><br/>";
            }
            return Ret;

        }
        else
        {
            return "<h2>Önerilecek Kitap Kalmadı</h2>";
        }
    }
}