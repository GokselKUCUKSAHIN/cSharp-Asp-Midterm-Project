<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mail.aspx.cs" Inherits="Mail" %>

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
    <title>Mesajlar</title>
</head>
<body style ="background-color:darkgray"> 
    <form id="form1" runat="server">
       
        <div style="text-align:right;top: 45px;">
            <asp:Label ID="Signed" runat="server" Text="Null: " Font-Bold="True" Font-Names="Arial" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" ForeColor="#3949AB"></asp:Label> &nbsp&nbsp&nbsp
            <asp:Button ID="LogOut" runat="server" Text="Çıkış Yap" BackColor="#CC0000" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="White" Height="26px" Width="74px" OnClick="LogOut_Click" TabIndex="20" /></div>
       
        <div style="min-width:600px;margin-left:17%;margin-right:17%;margin-top:10px;padding:4em ;border:inset 4px #FAB340;background-color:#FE8787">
            <p style ="text-align:left;padding-left:4em">
                <asp:Label ID="labelBaslik" runat="server" Text="Başlık: " Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="Beige">

                </asp:Label><asp:TextBox ID="textBoxBaslik" runat="server" Width="260px"></asp:TextBox>
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                <asp:Label ID="labelAlici" runat="server" Text="Alıcı: " Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="Beige"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" style="margin-left: 7px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="111px" TabIndex="1"></asp:DropDownList>
            </p>
            <p style="text-align:left;padding-left:3em; margin-right:0%;">
                <asp:TextBox ID="textBoxMessage" runat="server" Height="325px" Width="571px" TextMode="MultiLine" Wrap="False" style="margin-left: 0px" TabIndex="2"></asp:TextBox>

            </p>
            <p style="text-align:left;padding-left:3em; margin-right:0%;">
                <asp:Label ID="InfoLabel" runat="server" Text="Göndermek istediğiniz kullanıcıyı seçip Mesaj gönderebilirsiniz." Font-Bold="false" Font-Names="Arial" Font-Size="Medium" ForeColor="Red"></asp:Label>

            </p>
            <p style="text-align:left;padding-left:3em; margin-right:0%;">
                <asp:Button ID="Send" runat="server" BackColor="#98FF2C" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="DarkGreen" Height="33px" Text="Mesaj Gönder" Width="120px" OnClick="Send_Click" TabIndex="3" />

            </p>
            <p style="text-align:left;padding-left:3em; margin-right:0%;">
                <asp:Button ID="buttonGeri" runat="server" Text="Geri" style="margin-left: 0px; margin-right: 0px" Width="70px" Font-Bold="True" Font-Names="Arial" BackColor="#FF9100" Font-Size="Medium" Height="30px" OnClick="buttonGeri_Click"/>

            </p>
        </div>
        <br/>
        <br/>
        <hr />
        <br/>
        <br/>
        <div style ="text-align:center;font-family:Arial;font-size:20px;">
            <h2>Gelen Mesajlar</h2>
                <%
                ListMesaj((int)Session["KullaniciID"]);
                %>
            <br/>
        <br/>
        </div>
    </form>
</body>
</html>