<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YazarDetay.aspx.cs" Inherits="YazarDetay" %>

<!DOCTYPE html>
<style>
     a {
     text-decoration: none ;
     color:#3949AB;
     
    }
    a:hover
  {
    color:#FF80AB;
    text-decoration:none;
    cursor:pointer;
   }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yazar Detay</title>
</head>
<body style="background-color:#E53935">
    <form id="form1" runat="server">
        <div style="text-align:right;top: 45px;">
             <asp:Label ID="Signed" runat="server" Text="Null: " Font-Bold="True" Font-Names="Arial" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" ForeColor="#69F0AE"></asp:Label> &nbsp&nbsp&nbsp
            <asp:Button ID="LogOut" runat="server" Text="Çıkış Yap" BackColor="#CC0000" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="White" Height="26px" Width="74px" OnClick="LogOut_Click" TabIndex="20" /></div>
        <br/>
        <div style="text-align:center;margin-left:11%;margin-right:11%;background-color:#81C784;border:solid 11px #303030;border-radius:2% ;padding:2em;min-width:500px">
            <div style ="font-family:Arial, Helvetica, sans-serif">
                <h2>Yazar Detay Sayfası</h2>
                <img style="border:5px solid;border-color:lightyellow;border-radius: 5%;" src="pp/yazardefault.jpg" alt="Default Writer Picture"  height= "400" width="400"/>
                <p style="font-size:19px"><asp:Label ID="YazarAdSoyad" runat="server" Text="Empty Nick-Null"></asp:Label></p>
                <p><asp:Label ID="Tarih" runat="server" Text="Empty Nick-Null"></asp:Label></p>
                
                <p><asp:Button ID="buttonGeri" runat="server" Text="Geri" style="margin-left: 0px; margin-right: 0px" Width="70px" Font-Bold="True" Font-Names="Arial" BackColor="#FF9100" Font-Size="Medium" Height="30px" OnClick="buttonGeri_Click"/>
                   </p>
                <br/>
            </div>
                <hr/>
            <div style="font-family:Arial, Helvetica, sans-serif;text-align:center">
                <br/>
                <h2>Yazarın Kitapları</h2>
                <%
                    ListKitap();
                    %>
            </div>
         </div>
    </form>
</body>
</html>