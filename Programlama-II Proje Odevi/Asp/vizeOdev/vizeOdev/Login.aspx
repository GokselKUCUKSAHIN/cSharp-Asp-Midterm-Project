<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body style="background-color:LightBlue;">
    <form id="form1" runat="server">


        <br />
        <h1 style="text-align: center;color:crimson;font-family:Arial, Helvetica, sans-serif"><strong>Kitap Değerlendirme ve Tavsiye Sistemi</strong></h1>
        

            <div style="background-color:lightgoldenrodyellow ;margin:auto ;border-bottom:10px solid gray;border-top: 10px solid gray;border-right:10px solid gray;border-left:10px solid gray;min-width:500px;max-width:900px;">
                <br />
                <br />
                <p style="text-align:center">
                    <asp:Label ID="label1" runat="server" Text="KullanıcıAdı: " Font-Bold="False" Font-Names="Arial" Font-Size="Large"></asp:Label><asp:TextBox ID="textBox1" runat="server" Width="250px"></asp:TextBox>
                </p>
                <p style="text-align:center">
                    <asp:Label ID="label2" runat="server" Text="Şifre:" Font-Bold="False" Font-Names="Arial" Font-Size="Large"></asp:Label><asp:TextBox ID="textBox2" runat="server" Width="250px" style="margin-left: 66px; margin-right: 0px" TextMode="Password"></asp:TextBox>
                </p>
                <br />
                <p style="text-align:center">
                    <asp:Label ID="label3" runat="server" Text="Giriş yapmak için KullanıcıAdı-Şifrenizi Girin." Font-Names="arial" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </p>
                <p style="text-align:center">
                    <asp:Button ID="Button1" runat="server" BackColor="Maroon" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="White" Height="33px" Text="Giriş Yap" Width="120px" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" BackColor="Coral" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="White" Height="33px" Text="Kayıt Ol" Width="120px" OnClick="Button2_Click" style="margin-left: 31px" />
                </p>
                <br />
                <br />
            </div>
        <p></p>

    </form>
</body>
</html>
<!--style="text-align:center;border: 5px solid gray; margin-left: 200px; margin-right: 200px; min-width:900px; padding: 2em; background-color:coral;"-->