<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ukemeny.aspx.cs" Inherits="Kantine_net.ukemeny" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MENY</title>
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
                <a class="nav-link" aria-current="page" href="ukemeny.aspx">MENY</a>
                <a class="nav-link" href="login.aspx">ADMIN</a>
                <a class="nav-link" href="statistikk.aspx">STATISTIKK</a>
              </div>
            </div>
          </div>
    </nav>

    <form id="form1" runat="server" class="center">
        <div>
           <h3>&nbsp;&nbsp;&nbsp;</h3>
            <h3>&nbsp;&nbsp; MENY</h3>
            <br />
          <asp:DropDownList ID="ListDesc" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListDesc_SelectedIndexChanged" Height="27px" Width="159px" CssClass="bg-dark text-light">
                   
              <asp:ListItem Selected="True" Disabled="True" style="display: none;" Value="UKEMENY">UKEMENY</asp:ListItem>
            </asp:DropDownList>


            <br />
        </div>
&nbsp;<asp:Label ID="lbl" runat="server" Text=" "></asp:Label>
        <br />
        <asp:GridView ID="GridView" runat="server" Height="429px" Width="587px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
         
            <AlternatingRowStyle BackColor="#CCCCCC" />
         
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="#2C2C2C" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="White" />

            <SortedAscendingCellStyle BackColor="#CCCCCC" />
            <SortedAscendingHeaderStyle BackColor="#CCCCCC" />
            <SortedDescendingCellStyle BackColor="#CCCCCC" />
            <SortedDescendingHeaderStyle BackColor="#CCCCCC" />
        </asp:GridView>
        <br />
        <br />
        <br />
    </form>
</body>
</html>
