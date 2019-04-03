<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Kullanici.aspx.cs" Inherits="Kullanici" %>

<!DOCTYPE html>

<style>
.split {
    height: 100%;
    width: 75%;
    position: fixed;
    z-index: 1;
    top: 41px;
    overflow-x: hidden;
    padding-top: 20px;
}
.splitR {
    height: 100%;
    width: 75%;
    position: fixed;
    z-index: 1;
    top: 41px;
    overflow-x: hidden;
}

.left {
    left: 0;
	background-color:lightblue;
}

.right {
    right: 0;
	background-color:orange;
}

.centered {
    position: absolute;
    top: 0%;
    left: 15%;
    transform: translate(-50%,10%);
    text-align: center;
}
.centeredR {
    position: absolute;
    left: 15%;
    text-align: center;
}
.centered img{
    border:5px solid;
    border-color:lightyellow;
    border-radius: 5%;
    height: 300px;
    width: 250px;
}
a {
     text-decoration: none ;
     color:#3949AB;
     font-size:large;
    }
    a:hover
  {
    color:#124C60;
    text-decoration:none;
    cursor:pointer;
   }
    h2{
        color:#124C60;
    }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kullanıcı Detay</title>

</head>
    	
<body style ="background-color: darkgray; font-family:Arial">
<form id="form1" runat="server">

    <div style="text-align:right;">
        <asp:Label ID="Signed" runat="server" Text="Null: " Font-Bold="True" Font-Names="Arial" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" ForeColor="#3949AB"></asp:Label> &nbsp&nbsp&nbsp
        <asp:Button ID="LogOut" runat="server" Text="Çıkış Yap" BackColor="#CC0000" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="White" Height="26px" Width="74px" BorderStyle="None" OnClick="LogOut_Click" TabIndex="12" /></div>
	
    <!--Kullanıcı Bilgileri-->
    <div class="split left">
        <div class="centered">
            <img src="pp/default.jpg" alt="Default Profile Picture"/>
            <div style="text-align:left;">
                <p style="font-size:21px"><asp:Label ID="UserNick" runat="server" Text="Empty Nick-Null"></asp:Label></p>
            <p style="font-size:15px"><asp:Label ID="Isim" runat="server" Text="Empty Name-Null"></asp:Label></p>
            <p style="font-size:15px"><asp:Label ID="Soyisim" runat="server" Text="Empty Surname-Null"></asp:Label></p>
            <p style="font-size:15px"><asp:Label ID="DogumTarih" runat="server" Text="Empty Date-Null"></asp:Label></p>
            <p style="font-size:15px"><asp:Label ID="Cinsiyet" runat="server" Text="Empty Gender-Null"></asp:Label></p>
            <p>
                <asp:Button ID="MsgGonder" runat="server" Text="Mesaj Yolla" Font-Names="Arial" Font-Size="Medium" BackColor="LightSeaGreen" Font-Bold="True" ForeColor="LightCyan" Height="30px" Width="100px" Visible="True" OnClick="MsgGonder_Click"/>
                <asp:Button ID="buttonGeri" runat="server" Text="Geri" style="margin-left: 35px; margin-right: 0px" Width="70px" Font-Bold="True" Font-Names="Arial" BackColor="#FF9100" Font-Size="Medium" Height="30px" OnClick="buttonGeri_Click" TabIndex="1"/>   
            </p>
            </div>
	    </div>
    </div>
    <div class="splitR right"style="border-left:12px solid #ffff50;" >
        <div class="centeredR">
            
            <br />
            <br />
            <div style="text-align:center;margin-right:15%;font-family:Arial">
                <h2>Okuduğu kitaplar</h2>
                <p>
                    <%
                        //kitap list <a>
                        Response.Write(OkumaInfo());
                        %>
                </p>
                <hr />
                <h2>Puanlamalar</h2>
                <p>
                    <%
                        Response.Write(PuanInfo());
                        //puanlama list
                        %>
                </p>
                <hr />
                <h2> incelemeler</h2>
                <p>
                    <%
                        Response.Write(IncelemeInfo());
                        //İncelemeler list
                        %>
                </p>
                <hr />
                <h2>alintilar</h2>
                <p>
                    <%
                        Response.Write(AlintiInfo());
                        //alintilar list
                        %>
                </p>
                <br />
            </div>

        </div>
    </div>
    </form>
    </body>
</html>