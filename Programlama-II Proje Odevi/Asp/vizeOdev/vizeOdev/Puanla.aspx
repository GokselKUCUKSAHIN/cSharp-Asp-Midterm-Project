<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Puanla.aspx.cs" Inherits="Puanla" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Puanla</title>
</head>
<body style="background-color:#7986CB;font-family:Arial">
    <form id="form1" runat="server">
        <div style="text-align:right;top: 45px;">
            <asp:Label ID="Signed" runat="server" Text="Null: " Font-Bold="True" Font-Names="Arial" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" ForeColor="#69F0AE"></asp:Label> &nbsp&nbsp&nbsp
            <asp:Button ID="LogOut" runat="server" Text="Çıkış Yap" BackColor="#CC0000" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="White" Height="26px" Width="74px" OnClick="LogOut_Click" TabIndex="20" /></div>
        
        <div style="text-align:center;margin-left:11%;margin-right:11%;background-color:#81C784;border:solid 11px;border-color:#EF6C00 ;border-radius:2% ;padding:2em;min-width:500px">
            <br/>
            <h2><%Response.Write(KitapAdi());%></h2>
            <p>
                <asp:Button ID="Puan1" runat="server" Text="1" BackColor="#FEFE00" Font-Bold="True" Font-Names="Arial" Font-Size="X-Large" Height="35px" Width="35px" style="margin-right: 25px; margin-left: 45px;" OnClick="Button1_Click" />
                <asp:Button ID="Puan2" runat="server" Text="2" BackColor="#FEFE00" Font-Bold="True" Font-Names="Arial" Font-Size="X-Large" Height="35px" Width="35px" style="margin-right: 25px" OnClick="Button2_Click" TabIndex="1" />
                <asp:Button ID="Puan3" runat="server" Text="3" BackColor="#FEFE00" Font-Bold="True" Font-Names="Arial" Font-Size="X-Large" Height="35px" Width="35px" style="margin-right: 25px" OnClick="Button3_Click" TabIndex="2" />
                <asp:Button ID="Puan4" runat="server" Text="4" BackColor="#FEFE00" Font-Bold="True" Font-Names="Arial" Font-Size="X-Large" Height="35px" Width="35px" style="margin-right: 25px" OnClick="Button4_Click" TabIndex="3" />
                <asp:Button ID="Puan5" runat="server" Text="5" BackColor="#FEFE00" Font-Bold="True" Font-Names="Arial" Font-Size="X-Large" Height="35px" Width="35px" style="margin-right: 25px" OnClick="Button5_Click" TabIndex="4" />
                <asp:Button ID="Puan6" runat="server" Text="6" BackColor="#FEFE00" Font-Bold="True" Font-Names="Arial" Font-Size="X-Large" Height="35px" Width="35px" style="margin-right: 25px" OnClick="Button6_Click" TabIndex="5" />
                <asp:Button ID="Puan7" runat="server" Text="7" BackColor="#FEFE00" Font-Bold="True" Font-Names="Arial" Font-Size="X-Large" Height="35px" Width="35px" style="margin-right: 25px" OnClick="Button7_Click" TabIndex="6" />
                <asp:Button ID="Puan8" runat="server" Text="8" BackColor="#FEFE00" Font-Bold="True" Font-Names="Arial" Font-Size="X-Large" Height="35px" Width="35px" style="margin-right: 25px" OnClick="Button8_Click" TabIndex="7" />
                <asp:Button ID="Puan9" runat="server" Text="9" BackColor="#FEFE00" Font-Bold="True" Font-Names="Arial" Font-Size="X-Large" Height="35px" Width="35px" style="margin-right: 25px" OnClick="Button9_Click" TabIndex="8" />
                <asp:Button ID="Puan10" runat="server" Text="10" BackColor="#FEFE00" Font-Bold="True" Font-Names="Arial" Font-Size="X-Large" Height="35px" Width="37px" style="margin-right: 25px" OnClick="Button10_Click" TabIndex="9" />

            </p>
            <asp:Label ID="PuanDisplay" runat="server" Text="" Font-Names="arial" Font-Size="Medium" ForeColor="Red"></asp:Label>
            <p><asp:Button ID="buttonGeri" runat="server" Text="Geri" style="margin-left: 0px; margin-right: 0px" Width="115px" Font-Bold="True" Font-Names="Arial" BackColor="GreenYellow" Font-Size="Medium" Height="30px" TabIndex="10" OnClick="buttonGeri_Click"/></p>
        </div>
    </form>
</body>
</html>