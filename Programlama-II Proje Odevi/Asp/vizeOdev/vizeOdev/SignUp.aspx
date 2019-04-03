<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
</head>
<body style="background-color:LightBlue;">
    <form id="form1" runat="server">


        <br />
        <h1 style="text-align: center;color:crimson;font-family:Arial, Helvetica, sans-serif"><strong>Kitap Değerlendirme ve Tavsiye Sistemi</strong></h1>
        

            <div style="background-color:lightgoldenrodyellow ;margin:auto ;border-bottom:10px solid gray;border-top: 10px solid gray;border-right:10px solid gray;border-left:10px solid gray;min-width:500px;max-width:900px;">
                <br />
                <p style="text-align:center">
                    <asp:Label ID="label1" runat="server" Text="KullanıcıAdı: " Font-Bold="False" Font-Names="Arial" Font-Size="Large"></asp:Label><asp:TextBox ID="textBox1" runat="server" Width="250px" style="margin-left: 10px" AutoPostBack="True" TabIndex="1"></asp:TextBox>
                </p>
                <p style="text-align:center">
                    <asp:Label ID="label2" runat="server" Text="Şifre:" Font-Bold="False" Font-Names="Arial" Font-Size="Large"></asp:Label><asp:TextBox ID="textBox2" runat="server" Width="250px" style="margin-left: 76px; margin-right: 0px" TextMode="Password" TabIndex="1" AutoPostBack="True"></asp:TextBox>
                </p>
                <p style="text-align:center">
                    <asp:Label ID="label3" runat="server" Text="Şifre(Tekrar):" Font-Bold="False" Font-Names="Arial" Font-Size="Large"></asp:Label><asp:TextBox ID="textBox3" runat="server" Width="250px" style="margin-left: 13px; margin-right: 0px" TextMode="Password" TabIndex="2" AutoPostBack="True"></asp:TextBox>
                </p>
                <br />
                <p style ="text-align:center">
                    <asp:Label ID="label4" runat="server" Text="Adınız: " Font-Bold="False" Font-Names="Arial" Font-Size="Large"></asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server" style="margin-left: 60px" TabIndex="3" Width="250px" AutoPostBack="True"></asp:TextBox>
                </p>
                
                <p style ="text-align:center">
                    <asp:Label ID="label5" runat="server" Text="Soyadınız: " Font-Bold="False" Font-Names="Arial" Font-Size="Large"></asp:Label>
                    <asp:TextBox ID="TextBox5" runat="server" style="margin-left: 31px" TabIndex="4" Width="250px" AutoPostBack="True"></asp:TextBox>
                </p>
                
                <p style ="text-align:center">
                    <asp:Label ID="label6" runat="server" Text="Doğum Tarihi:     " Font-Bold="False" Font-Names="Arial" Font-Size="Large"></asp:Label>
                    <asp:Label ID="labelAy" runat="server" Text="Ay: " Font-Bold="False" Font-Names="Arial" Font-Size="Medium"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" TabIndex="5" style="margin-left: 0px" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="labelGun" runat="server" Text="Gün: " Font-Bold="False" Font-Names="Arial" Font-Size="Medium"></asp:Label>
                    <asp:DropDownList ID="DropDownList2" runat="server" TabIndex="6" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="labelYıl" runat="server" Text="Yıl: " Font-Bold="False" Font-Names="Arial" Font-Size="Medium"></asp:Label>
                    <asp:DropDownList ID="DropDownList3" runat="server" TabIndex="7" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Value="1950">1950</asp:ListItem>
                        <asp:ListItem>1951</asp:ListItem>
                        <asp:ListItem>1952</asp:ListItem>
                        <asp:ListItem>1953</asp:ListItem>
                        <asp:ListItem>1954</asp:ListItem>
                        <asp:ListItem>1955</asp:ListItem>
                        <asp:ListItem>1956</asp:ListItem>
                        <asp:ListItem>1957</asp:ListItem>
                        <asp:ListItem>1958</asp:ListItem>
                        <asp:ListItem>1959</asp:ListItem>
                        <asp:ListItem>1960</asp:ListItem>
                        <asp:ListItem>1961</asp:ListItem>
                        <asp:ListItem>1962</asp:ListItem>
                        <asp:ListItem>1963</asp:ListItem>
                        <asp:ListItem>1964</asp:ListItem>
                        <asp:ListItem>1965</asp:ListItem>
                        <asp:ListItem>1966</asp:ListItem>
                        <asp:ListItem>1967</asp:ListItem>
                        <asp:ListItem>1968</asp:ListItem>
                        <asp:ListItem>1969</asp:ListItem>
                        <asp:ListItem>1970</asp:ListItem>
                        <asp:ListItem>1971</asp:ListItem>
                        <asp:ListItem>1972</asp:ListItem>
                        <asp:ListItem>1973</asp:ListItem>
                        <asp:ListItem>1974</asp:ListItem>
                        <asp:ListItem>1975</asp:ListItem>
                        <asp:ListItem>1976</asp:ListItem>
                        <asp:ListItem>1977</asp:ListItem>
                        <asp:ListItem>1978</asp:ListItem>
                        <asp:ListItem>1979</asp:ListItem>
                        <asp:ListItem>1980</asp:ListItem>
                        <asp:ListItem>1981</asp:ListItem>
                        <asp:ListItem>1982</asp:ListItem>
                        <asp:ListItem>1983</asp:ListItem>
                        <asp:ListItem>1984</asp:ListItem>
                        <asp:ListItem>1985</asp:ListItem>
                        <asp:ListItem>1986</asp:ListItem>
                        <asp:ListItem>1987</asp:ListItem>
                        <asp:ListItem>1988</asp:ListItem>
                        <asp:ListItem>1989</asp:ListItem>
                        <asp:ListItem>1990</asp:ListItem>
                        <asp:ListItem>1991</asp:ListItem>
                        <asp:ListItem>1992</asp:ListItem>
                        <asp:ListItem>1993</asp:ListItem>
                        <asp:ListItem>1994</asp:ListItem>
                        <asp:ListItem>1995</asp:ListItem>
                        <asp:ListItem>1996</asp:ListItem>
                        <asp:ListItem>1997</asp:ListItem>
                        <asp:ListItem>1998</asp:ListItem>
                        <asp:ListItem>1999</asp:ListItem>
                        <asp:ListItem>2000</asp:ListItem>
                        <asp:ListItem>2001</asp:ListItem>
                        <asp:ListItem>2002</asp:ListItem>
                        <asp:ListItem>2003</asp:ListItem>
                        <asp:ListItem>2004</asp:ListItem>
                        <asp:ListItem>2005</asp:ListItem>
                        <asp:ListItem>2006</asp:ListItem>
                        <asp:ListItem>2007</asp:ListItem>
                        <asp:ListItem>2008</asp:ListItem>
                        <asp:ListItem>2009</asp:ListItem>
                        <asp:ListItem>2010</asp:ListItem>
                        <asp:ListItem>2011</asp:ListItem>
                        <asp:ListItem>2012</asp:ListItem>
                        <asp:ListItem>2013</asp:ListItem>
                        <asp:ListItem>2014</asp:ListItem>
                        <asp:ListItem>2015</asp:ListItem>
                        <asp:ListItem>2016</asp:ListItem>
                        <asp:ListItem>2017</asp:ListItem>
                        <asp:ListItem>2018</asp:ListItem>
                        <asp:ListItem>2019</asp:ListItem>
                    </asp:DropDownList>
                </p>
                
                <p style ="text-align:center">
                    <asp:Label ID="label7" runat="server" Text="Cinsiyet:     " Font-Bold="False" Font-Names="Arial" Font-Size="Large"></asp:Label>
                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Erkek" TabIndex="8" />
                    <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" Text="Kadın" TabIndex="9" />
                </p>
                



                <p style="text-align:center">
                    <asp:Label ID="InfoLabel" runat="server" Text=" " Font-Names="arial" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </p>
                <p style="text-align:center">
                    <asp:Button ID="Button3" runat="server" BackColor="Coral" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="White" Height="34px" Text="Giriş Yap" Width="120px" OnClick="Button3_Click" TabIndex="11" />
                    <asp:Button ID="Button4" runat="server" BackColor="Maroon" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="White" Height="33px" Text="Kayıt Ol" Width="120px" style="margin-left: 31px" OnClick="Button4_Click" TabIndex="10" />
                </p>
                <br />
            </div>

        <br />

    </form>
</body>
</html>
<!--style="text-align:center;border: 5px solid gray; margin-left: 200px; margin-right: 200px; min-width:900px; padding: 2em; background-color:coral;"-->