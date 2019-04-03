<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<!DOCTYPE html>
<style>
body {
    font-family: Arial;
    color: white;
}

.split {
	margin-top:41px;
    height: 100%;
    width: 50%;
    position: fixed;
    z-index: 1;
    top: 0;
    overflow-x: hidden;
    padding-top: 20px;
}

.left {
    left: 0;
    background-color: #02808F;
}

.right {
    right: 0;
    background-color:#FF5252;
	border-left: 20px solid #FF9100;
}

.centered {
    position: absolute;
    left: 50%;
    transform: translate(-50%, 0%);
    text-align: center;
}

.centered img {
    width: 150px;
    border-radius: 50%;
}
a {
    text-decoration: none ;
    color:#FFFFFF;
}
a:hover {
    color:lightslategrey;
    text-decoration:none;
    cursor:pointer;
   }
.jelly{
    font-size:20px;
    font-family:Arial;
    
}
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ana Menü</title>
</head>
<body style="background-color:#1A2521">
    <form id="form1" runat="server">
        <div style="text-align:right;top: 45px;">
             <asp:Label ID="Signed" runat="server" Text="Null: " Font-Bold="True" Font-Names="Arial" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" ForeColor="#69F0AE"></asp:Label> &nbsp&nbsp&nbsp
             <asp:Button ID="Button1" runat="server" Text="Çıkış Yap" BackColor="#CC0000" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="White" Height="26px" Width="74px" TabIndex="20" OnClick="LogOut_Click" />
        </div>
        <br/>
        <!--Üste Dokunma-->


        <div class="split left">
            <div class="centered">
    
                <h2>Göksel Küçükşahin</h2>
                <p style="font-size:x-large;"><b>1030522874 İÖ</b></p>
                <hr />
                <h2>Sizin ile Aynı Puanları Verenler</h2>
                 <br />
                <% Response.Write(PuanTavsiye()); %>
                <br />
                <hr />
                <h2>Ortak Kitapları Okuduğunuz Kullanıcılar</h2>
                 <br />
                <% Response.Write(OkumaTavsiye()); %>
                <br />
                <hr />
                <h2>Kitap Öneri</h2>
                 <br />
                <%Response.Write(KitapTavsiye()); %>
                <br />
                <br />
            </div>
        </div>

        <div class="split right">
	        <div class="centered">
	            <h1></h1>
                <h1>kitap ara</h1>
                <asp:TextBox ID="textBoxKitapAra" runat="server" Width="216px"></asp:TextBox>
                <asp:Button ID="buttonKitapAra" runat="server" Text="ara" BackColor="#FFCC00" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="#FF0066" style="margin-left: 25px" Width="60px" OnClick="buttonKitapAra_Click" />
                <p>
                    <br />
                    <asp:Label ID="labelKitapAra" runat="server" Text="(Aramak istediğiniz kitabın ismini yazın.)" Font-Bold="True" Font-Names="Arial" Font-Size="Large"></asp:Label>
                </p>
                <br />
                <hr />
                <h1>kullanıcı ara</h1>
                <asp:TextBox ID="textBoxKullaniciAra" runat="server" Width="216px"></asp:TextBox>
                <asp:Button ID="buttonKullaniciAra" runat="server" Text="ara" BackColor="#FFCC00" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="#FF0066" style="margin-left: 25px" Width="60px" OnClick="buttonKullaniciAra_Click"  />
                <p>
                    <br />
                    <asp:Label ID="labelKullaniciAra" runat="server" Text="(Aramak istediğiniz Kullanıcının ismini yazın.)" Font-Bold="True" Font-Names="Arial" Font-Size="Large"></asp:Label>
                </p>
                <br />
                <hr />
                <h1>yazar ara</h1>
                <asp:TextBox ID="textBoxYazarAra" runat="server" Width="216px"></asp:TextBox>
                <asp:Button ID="buttonYazarAra" runat="server" Text="ara" BackColor="#FFCC00" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="#FF0066" style="margin-left: 25px" Width="60px" OnClick="buttonYazarAra_Click"/>
                <p>
                    <br />
                    <asp:Label ID="labelYazarAra" runat="server" Text="(Aramak istediğiniz Yazarın ismini yazın.)" Font-Bold="True" Font-Names="Arial" Font-Size="Large"></asp:Label>
                </p>
                <br />
                <hr />
                <h1>popüler kitaplar</h1>
                <p>
                    <br />
                    <asp:Label ID="labelPopulerKitap" runat="server" Text="Kitap Bulunamadı." Font-Bold="True" Font-Names="Arial" Font-Size="Large"></asp:Label>
                </p>
                <br />
                <hr />
                <h1>popüler yazarlar</h1>
                <p>
                    <br />
                    <asp:Label ID="labelPopulerYazar" runat="server" Text="Yazar Bulunamadı." Font-Bold="True" Font-Names="Arial" Font-Size="Large"></asp:Label>
                </p>
                <br />
                <hr />
                <h1>yüksek puanlı kitaplar</h1>
                <p>
                    <br />
                    <asp:Label ID="labelYuksekPuanliKitap" runat="server" Text="Kitap Bulunamadı." Font-Bold="True" Font-Names="Arial" Font-Size="Large"></asp:Label>
                </p>
                <br />
                <br />
                <br /><br /><br />
                <br/><br/><br/>
            </div>
        </div>
    </form>
</body>
</html>