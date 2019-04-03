<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Kitap.aspx.cs" Inherits="Kitap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kitap Detay</title>
    <style>
     a {
     text-decoration: none ;
     color:#3949AB;
    }
    a:hover
  {
    color:#EF6C00;
    text-decoration:none;
    cursor:pointer;
   }
</style>
</head>
<body style="background-color:#E53935">
    <form id="form1" runat="server">

         <div style="text-align:right;top: 45px;">
             <asp:Label ID="Signed" runat="server" Text="Null: " Font-Bold="True" Font-Names="Arial" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" ForeColor="#69F0AE"></asp:Label> &nbsp&nbsp&nbsp
            <asp:Button ID="LogOut" runat="server" Text="Çıkış Yap" BackColor="#CC0000" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="White" Height="26px" Width="74px" OnClick="LogOut_Click" TabIndex="20" /></div>
        <br/>
        <div style="text-align:center;margin-left:11%;margin-right:11%;background-color:#81C784;border:solid 11px #303030;border-radius:2% ;padding:2em;min-width:500px">
            <div style ="font-family:Arial, Helvetica, sans-serif">
                <h2>Kitap Detay Sayfası</h2>
                <img style="border:5px solid;border-color:lightyellow;border-radius: 5%;" src="pp/book.jpg" alt="Default Book Picture"  height= "400" width="300"/>
                <p style="font-size:19px"><asp:Label ID="KitapAdi" runat="server" Text="Empty Nick-Null"></asp:Label></p>
                <p><asp:Label ID="KitapYazari" runat="server" Text="Empty Nick-Null"></asp:Label></p>
                <p><asp:Label ID="KitapPuani" runat="server" Text="Empty Nick-Null"></asp:Label></p>
                <p><asp:Label ID="KitapReadCount" runat="server" Text="Empty Nick-Null"></asp:Label></p>
                <p><asp:Label ID="KitapYayinEvi" runat="server" Text="Empty Nick-Null"></asp:Label></p>
                <p><asp:Label ID="KitapInfo" runat="server" Text="Empty Nick-Null"></asp:Label></p>
                <p><asp:Button ID="buttonGeri" runat="server" Text="Geri" style="margin-left: 0px; margin-right: 0px" Width="70px" Font-Bold="True" Font-Names="Arial" BackColor="#FF9100" Font-Size="Medium" Height="30px" OnClick="buttonGeri_Click"/>
                <asp:Button ID="buttonOkudum" runat="server" Text="Okudum" style="margin-left: 26px; margin-right: 0px" Width="75px" Font-Bold="True" Font-Names="Arial" BackColor="BlueViolet" Font-Size="Medium" Height="30px" OnClick="buttonOkudum_Click" TabIndex="1"/></p>
                <br/>
            </div>
            <hr />
            <div  style="font-family:Arial, Helvetica, sans-serif">
                <br/>
                <h2>
                    puanla
                </h2>
                 <br />
                    <asp:Button ID="buttonPuanla" runat="server" Text="Puanla" style="margin-left: 0px; margin-right: 0px" Width="115px" Font-Bold="True" Font-Names="Arial" BackColor="GreenYellow" Font-Size="Medium" Height="30px" TabIndex="2" OnClick="buttonPuanla_Click"/>
                <br />
                <br />
            </div>
            <hr/>
            <div  style="font-family:Arial, Helvetica, sans-serif">
                <br/>
                <h2>
                    incelemeler
                </h2>
                    <%
                        Response.Write(IncelemeBilgi());
                        %>
                <br/>
                <p><asp:Button ID="IncelemeYaz" runat="server" Text="İnceleme Yaz" style="margin-left: 0px; margin-right: 0px" Width="115px" Font-Bold="True" Font-Names="Arial" BackColor="#FF9100" Font-Size="Medium" Height="30px" TabIndex="3" OnClick="IncelemeYaz_Click"/></p>
                <br/>
            </div>
            <hr/>
            <div  style="font-family:Arial, Helvetica, sans-serif">
                <br/>
                <h2>
                    alıntılar
                </h2>
                <%
                    Response.Write(AlintiBilgi());
                    %>
                <br/>

                <p><asp:Button ID="AlintiYaz" runat="server" Text="Alıntı Yaz" style="margin-left: 0px; margin-right: 0px" Width="115px" Font-Bold="True" Font-Names="Arial" BackColor="#FF9100" Font-Size="Medium" Height="30px" TabIndex="4" OnClick="AlintiYaz_Click"/></p>
 
            </div>
        </div>
        <br/>
        <br/>
    </form>
</body>
</html>