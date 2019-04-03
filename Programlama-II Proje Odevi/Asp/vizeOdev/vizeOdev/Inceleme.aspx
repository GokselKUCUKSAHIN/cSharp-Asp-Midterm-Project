﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inceleme.aspx.cs" Inherits="Inceleme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inceleme Yaz</title>
</head>
<body style ="background-color:darkgray">
    <form id="form1" runat="server">
        <div style="text-align:right;top: 45px;">
            <asp:Label ID="Signed" runat="server" Text="Null: " Font-Bold="True" Font-Names="Arial" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" ForeColor="#3949AB"></asp:Label> &nbsp&nbsp&nbsp
            <asp:Button ID="LogOut" runat="server" Text="Çıkış Yap" BackColor="#CC0000" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="White" Height="26px" Width="74px" OnClick="LogOut_Click" TabIndex="20" /></div>
       
        <div style="min-width:600px;margin-left:17%;margin-right:17%;margin-top:2px;padding:2em ;border:inset 4px #FAB340;background-color:#FE8787">
             <h1 style="text-align:center;color:crimson;font-family:Arial, Helvetica, sans-serif">inceleme</h1>
            <p style ="text-align:center;font-family:Arial, Helvetica, sans-serif">
                <asp:Label ID="labelKitapIsmi" runat="server" Text="Kitap-Null: " Font-Bold="True" Font-Names="Arial" Font-Size="Large" ForeColor="Beige"></asp:Label>
             </p>      
            <p style="text-align:left;padding-left:3em; margin-right:0%;">
                <asp:TextBox ID="textBoxMessage" runat="server" Height="325px" Width="571px" TextMode="MultiLine" Wrap="False" style="margin-left: 0px" TabIndex="1"></asp:TextBox>
            </p>
            <p style="text-align:left;padding-left:3em; margin-right:0%;">
                <asp:Label ID="InfoLabel" runat="server" Text=" " Font-Bold="false" Font-Names="Arial" Font-Size="Medium" ForeColor="Red"></asp:Label>
            </p>
            <p style="text-align:left;padding-left:3em; margin-right:0%;">
                <asp:Button ID="Send" runat="server" BackColor="#98FF2C" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="DarkGreen" Height="33px" Text="Inceleme Yaz" Width="120px" OnClick="Send_Click" TabIndex="2"/>
            </p>
             <p style="text-align:left;padding-left:3em; margin-right:0%;">
                 <asp:Button ID="buttonGeri" runat="server" Text="Geri" style="margin-left: 0px; margin-right: 0px" Width="70px" Font-Bold="True" Font-Names="Arial" BackColor="#FF9100" Font-Size="Medium" Height="30px" OnClick="buttonGeri_Click" TabIndex="3"/>
            </p>
        </div>
        <div>
        </div>
    </form>
</body>
</html>