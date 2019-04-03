<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewMail.aspx.cs" Inherits="VievMail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mesaj Detay</title>
</head>
<body style="background-color:#124C60">
    <form id="form1" runat="server">
         <div style="text-align:right;top: 45px;">
            <asp:Label ID="Signed" runat="server" Text="Null: " Font-Bold="True" Font-Names="Arial" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" ForeColor="#69F0AE"></asp:Label> &nbsp&nbsp&nbsp
            <asp:Button ID="LogOut" runat="server" Text="Çıkış Yap" BackColor="#CC0000" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="White" Height="26px" Width="74px" OnClick="LogOut_Click" TabIndex="20" /></div>
        <br/>
        <div style="min-width:800px;padding-top:2em;padding-bottom:2em;margin-left:10%;margin-right:10%;margin-top:14px;text-align:center;border:10px solid #02808F; border-radius:3%;background-color:white;">
            <asp:TextBox ID="MesajKutusu" runat="server" ReadOnly="True" Height="440px" style="margin-left: 0px" Width="712px" OnLoad="MesajKutusu_Load" TextMode="MultiLine" TabIndex="5"></asp:TextBox>
        </div>
        <br/>
        <p style="text-align:center">

            <asp:Button ID="buttonGeri" runat="server" Text="Geri" style="margin-left: 0px; margin-right: 10px;" Width="70px" Font-Bold="True" Font-Names="Arial" BackColor="#00E676" Font-Size="Medium" OnClick="buttonGeri_Click" TabIndex="1" />
            <asp:Button ID="buttonSil" runat="server" Text="Sil" style="margin-left: 50px; margin-right: 0px" Width="70px" Font-Bold="True" Font-Names="Arial" BackColor="#CC0000" Font-Size="Medium" OnClick="buttonSil_Click" TabIndex="2" />
            <asp:Button ID="buttonYanitla" runat="server" Text="Yanıtla" style="margin-left: 50px; margin-right: 0px" Width="70px" Font-Bold="True" Font-Names="Arial" BackColor="#FF9100" Font-Size="Medium" OnClick="buttonYanitla_Click" TabIndex="3" />
        </p>
    </form>
</body>
</html>