<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crearproductoeng.aspx.cs" Inherits="ProyectoJade.crearproductoeng" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <meta charset="utf-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>Jade</title>
        <link href="https://cdn.jsdelivr.net/npm/simple-datatables@latest/dist/style.css" rel="stylesheet" />
        <link href="css_admin/styles.css" rel="stylesheet" />
        <script src="https://use.fontawesome.com/releases/v6.1.0/js/all.js" crossorigin="anonymous"></script>
</head>
<body class="sb-nav-fixed">
    <form id="form1" runat="server">
       <nav class="sb-topnav navbar navbar-expand navbar-dark bg-dark">
            <!-- Navbar Brand-->
            <a class="navbar-brand ps-3" href="index.html">Jade</a>
            <!-- Sidebar Toggle-->
            <button class="btn btn-link btn-sm order-1 order-lg-0 me-4 me-lg-0" id="sidebarToggle" href="#!"><i class="fas fa-bars"></i></button>
            <!-- Navbar Search-->
           
        </nav>
        <div id="layoutSidenav">
            <div id="layoutSidenav_nav">
                <nav class="sb-sidenav accordion sb-sidenav-dark" id="sidenavAccordion">
                    <div class="sb-sidenav-menu">
                        <div class="nav">
                            <a class="nav-link" href="index.html">
                                
                                Home
                            </a>
  <a class="nav-link" href="charts.html">
                                Create product
                            </a>
                              <a class="nav-link" href="charts.html">
                             
                               Edit product
                            </a>
                              <a class="nav-link" href="charts.html">
                              
                               Sales
                            </a>
                </nav>
            </div>
            <div id="layoutSidenav_content">
                <main>
                    <div class="container-fluid px-4">
                        <h1 class="mt-4">Bienvenido administrador</h1>
                        <ol class="breadcrumb mb-4">
                        </ol>
                     <div class="centered my-5">
            <div class="row">
                <div class="col-sm-12 col-md-8 col-lg-8 m-auto">
                    <div class="card ">
                        <div class="card-body">
                            <h5 class="card-title">Iniciar sesión</h5>
                            <hr />
                            <div class="mb-3">
                                <asp:Label ID="LabelProduct" CssClass="form-label" runat="server" Text="Name" Font-Bold="True"></asp:Label>
                                <asp:TextBox ID="Product" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                              
                             <div class="mb-3">
                              <asp:Label ID="Label2" CssClass="form-label" runat="server" Text="Product description" Font-Bold="True"></asp:Label>
                                <asp:TextBox ID="descripcion" CssClass="form-control" runat="server"></asp:TextBox>
                                     </div>
                                                          
                            <div class="mb-3">
                                <asp:Label ID="LabelPrice" CssClass="form-label" runat="server" Text="Price" Font-Bold="True"></asp:Label>
                                <asp:TextBox ID="Price" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Label ID="LabelQty" CssClass="form-label" runat="server" Text="Quantity" Font-Bold="True"></asp:Label>
                                <asp:TextBox ID="Quantity" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Label ID="LabelImage" CssClass="form-label" runat="server" Text="Image" Font-Bold="True"></asp:Label>
                                <asp:FileUpload ID="PhotoFile" CssClass="form-control" runat="server" />
                            </div>
                             <div class="mb-3">
                                <asp:Label ID="LabelTipo" CssClass="form-label" runat="server" Text="Categories" Font-Bold="True"></asp:Label>
                                 <asp:DropDownList ID="DropDownList1" runat="server">
                                 </asp:DropDownList>
                            </div>
                            <asp:Button ID="Create" CssClass="btn btn-success" runat="server" Text="Crear" OnClick="Create_Click" />
                              
                         </div>     
                     </div>   
                </div>
            </div>

        </div>
        </div>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
        <script src="js_admin/scripts.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js" crossorigin="anonymous"></script>
        <script src="assets_admin/demo/chart-area-demo.js"></script>
        <script src="assets_admin/demo/chart-bar-demo.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/simple-datatables@latest" crossorigin="anonymous"></script>
        <script src="js_admin/datatables-simple-demo.js"></script>
    </form>
</body>
</html>
