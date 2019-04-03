<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>
<style>
    body{
         font-family:Arial;
    }
    .Admin{
        border:solid 10px #00FF00;
        border-radius:2%;
        margin-top:60px;
        margin-left:21%;
        margin-right:21%;
        
        min-width:500px;
        text-align:center;
        background-color:darkgray;
    }
    h1{
       color:white;
       text-align:center;
    }

</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
</head>
<body style="background-color:#444444" >
    <form id="form1" runat="server">
        <h1>YÖNETİCİ MODÜLÜ</h1>
        <div class="Admin" >
            <br />
                <br />
                <p style="text-align:center;">
                    <asp:Label ID="label1" runat="server" Text="KullanıcıAdı: " Font-Bold="False" Font-Names="Arial" Font-Size="Large"></asp:Label><asp:TextBox ID="textBox1" runat="server" Width="250px"></asp:TextBox>
                </p>
                <p style="text-align:center">
                    <asp:Label ID="label2" runat="server" Text="Şifre:" Font-Bold="False" Font-Names="Arial" Font-Size="Large"></asp:Label><asp:TextBox ID="textBox2" runat="server" Width="250px" style="margin-left: 66px; margin-right: 0px" TextMode="Password"></asp:TextBox>
                </p>
                <br />
                <p style="text-align:center">
                    <asp:Label ID="label3" runat="server" Text="Giriş yapmak için Yönetici-Şifrenizi Girin." Font-Names="arial" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </p>
                <p style="text-align:center">
                    <asp:Button ID="Login" runat="server" BackColor="Maroon" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="White" Height="33px" Text="Giriş Yap" Width="120px" OnClick="Login_Click"  />
                </p>
                <br />
                <br />
        </div>
    </form>
</body>
</html>
