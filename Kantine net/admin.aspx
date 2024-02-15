<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Kantine_net.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADMIN</title>
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
                <a class="nav-link"  href="statistikk.aspx">STATISTIKK</a> 
              </div>
            </div>
          </div>
    </nav>

    <form id="form2" runat="server" class="center">
        <div>
            <h2>ENDRE MENYEN</h2>
            <br />
            </div>
         <asp:DropDownList ID="ListDesc" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListKategori_SelectedIndexChanged" Height="27px" Width="159px" CssClass="bg-dark text-light">
                   <asp:ListItem Selected="True" Disabled="True" style="display: none;">Velg kategori...</asp:ListItem>
            </asp:DropDownList>


&nbsp;<asp:DropDownList ID="ListArtic" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ListArtic_SelectedIndexChanged" Height="27px" Width="159px" CssClass="bg-dark text-light">
                   <asp:ListItem Selected="True" Disabled="True" style="display: none;">Velg produkt...</asp:ListItem>
       <asp:ListItem Value="Ny produkt">Ny produkt</asp:ListItem>
            </asp:DropDownList>
        
        <br />
        
        <br />
        
            <h4>ENDRE PRODUKT NAVN ELLER PRISEN TIL PRODUKTET OVENFOR</h4>&nbsp;<asp:TextBox ID="textnavn" runat="server" Width="113px" CssClass="form-control bg-dark text-light">NAVN</asp:TextBox>
        <asp:TextBox ID="textpris" runat="server" Width="113px" CssClass="form-control bg-dark text-light">KOSTNAD</asp:TextBox>
        <p>
            <asp:Button ID="Button4" runat="server" Height="29px" Text="LAGRE" CssClass="btn btn-dark" OnClick="Lagre_Click" />
        </p>
        <p>
            <asp:Label ID="lbl" runat="server" Text=" "></asp:Label>
        </p>
       
           <h4> SLETT PRODUKTET</h4>
        <p>
            <asp:Button ID="slettmeny" runat="server" Height="29px" Text="SLETT" CssClass="btn btn-dark" OnClick="slettmeny_Click" />
        </p>
        <asp:Label ID="lbll" runat="server" Text=" "></asp:Label>
        <p>
            &nbsp;</p>
        
            <h4>GENERER NY UKESMENY</h4>
        <asp:Button ID="ukemenybtn" runat="server" Text="generer" OnClick="ukemenybtn_Click" CssClass="btn btn-dark"/>
        <p>
            <asp:Label ID="lblll" runat="server" Text=" "></asp:Label>
        </p>
    </form>
</body>
</html>
