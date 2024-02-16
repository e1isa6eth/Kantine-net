<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="statistikk.aspx.cs" Inherits="Kantine_net.statistikk" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>STATISTIKK</title>
     <!-- Bootstrap -->
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css"/>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
  
       <!--------------------- CSS -------------------->
    <link rel="stylesheet" href="css.css" />



</head>
<body>
       <!-- Nav Bar -->
        <nav class="navbar sticky-top justify-content-between navbar-expand-lg">
          <div class="container-fluid">
            <a class="navbar-brand">KANTINE</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation" >
              <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
              <div class="navbar-nav ms-auto">
                <a class="nav-link" href="ukemeny.aspx">UKEMENY</a>
                <a class="nav-link" href="login.aspx">ADMIN</a>
                <a class="nav-link" aria-current="page" href="statistikk.aspx">STATISTIKK</a>
              </div>
            </div>
          </div>
    </nav>

    <form id="form1" runat="server">
        
            <br />
        <div class="center"> <h2>DE MEST POPULÆRE ARTIKKLENE I MENYEN VÅR</h2> </div>
          
        <div class="center">
        <br />
        <asp:DropDownList ID="ListTid" runat="server" AutoPostBack="True" Height="27px" Width="159px" CssClass="bg-dark text-light" >
                   <asp:ListItem Selected="True" Disabled="True" style="display: none;">Velg tidsperiode...</asp:ListItem>
            <asp:ListItem>Denne uka</asp:ListItem>
            <asp:ListItem>Denne måneden</asp:ListItem>
            <asp:ListItem>Dette året</asp:ListItem>
            </asp:DropDownList>

        <asp:DropDownList ID="ListDesc" runat="server" AutoPostBack="True" Height="27px" Width="159px" CssClass="bg-dark text-light" >
                   <asp:ListItem Selected="True" Disabled="True" style="display: none;">Velg kategori...</asp:ListItem>
            </asp:DropDownList>
            </div>
        <div class="center">
        <br />
        <asp:Button ID="Button" runat="server" OnClick="Button_Click" Text="se resultater" CssClass="btn btn-dark"/>
        <br />
        <asp:Label ID="lbl" runat="server" Text=" "></asp:Label>
        <br />
        
            <asp:Chart ID="chartview" runat="server" Height="417px" Width="1488px" BackColor="Transparent" BorderlineColor="Silver" Palette="Grayscale" BackSecondaryColor="DimGray">
                <series>
                    <asp:Series Name="Series1" Color="#2C2C2C">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1"  BackColor="Transparent">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
            </div>
        
    </form>
</body>
</html>
