<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Kantine_net.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGG INN</title>

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
                <a class="nav-link" aria-current="page" href="login.aspx">ADMIN</a>
                <a class="nav-link"  href="statistikk.aspx">STATISTIKK</a>
              </div>
            </div>
          </div>
    </nav>
   
    <form id="form1" runat="server">
             <div class="container">
    <div class="row justify-content-center align-items-center";>
        <div class="text-center">
        <div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
           <h4 style="color: white;"> Skriv inn engangskoden din:</h4></div>
            <br />
        <asp:TextBox ID="kodetxt" runat="server" CssClass="form-control bg-dark text-light text-center"></asp:TextBox>
        <p>
            <br />
            <asp:Button ID="loginbtn" runat="server" Text="Logg inn" OnClick="loginbtn_Click"  CssClass="btn btn-dark"/>

        </p>
        <asp:Label ID="lblerror" runat="server" Text=" " ForeColor="White"></asp:Label>
        </div>
         </div>
          </div>
    </form>
</body>
</html>
