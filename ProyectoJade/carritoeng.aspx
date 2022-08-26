<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="carritoeng.aspx.cs" Inherits="ProyectoJade.carritoeng" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css"/>

<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js"></script>
      <link href="css(PI)/styles.css" rel="stylesheet" />
     <script src="SweetAlert/sweetalert2.all.min.js"></script>
        <script src="SweetAlert/sweetalert2.js"></script>
     <script src="SweetAlert/sweetalert1.js"></script>
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/> 
    <title>Carrito</title>
    <style>
        #CheckOut{
            text-align:right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
          <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="container px-4 px-lg-5">
                <a class="navbar-brand" href="#!">Jade</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0 ms-lg-4">
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" id="navbarDropdown" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Gentleman</a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                
                                <li><a class="dropdown-item" href="camisas-h-eng.aspx">Shirts</a></li>
                                <li><a class="dropdown-item" href="pantalones-h-eng.aspx">Pants</a></li>
                                  <li><a class="dropdown-item" href="trajes-eng.aspx">Suits</a></li>
                                <li><a class="dropdown-item" href="zapatos-h-eng.aspx">Shoes</a></li>
                                <li><a class="dropdown-item" href="accesorios-h-eng.aspx">Accessories</a></li>
                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" id="navbarDropdown" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Lady</a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                
                                <li><a class="dropdown-item" href="camisas-m-eng.aspx">Shirts</a></li>
                                <li><a class="dropdown-item" href="pantalones-m-eng.aspx">Pants</a></li>
                                  <li><a class="dropdown-item" href="vestidos-eng.aspx">Dresses</a></li>
                                <li><a class="dropdown-item" href="zapatos-m-eng.aspx">Shoes</a></li>
                                <li><a class="dropdown-item" href="accesorios-m-eng.aspx">Accessories</a></li>
                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                      <a class="nav-link dropdown-toggle"  id="navbarDropdown2" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">language</a>
                           <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                               <li><a class="dropdown-item" href="carrito.aspx">Español</a></li>
                               <li><hr class="dropdown-divider" /></li>
                           <li><a class="dropdown-item" href="#!">English</a></li>
                               </ul>
                       </li>
                    </ul>
                    <form class="d-flex">
                      <div class="navbar-nav">
                    <a class="nav-link active" href="carritoeng.aspx">Cart</a>
                    <a class="nav-link active" href="logout-n.aspx">Log out</a>
               
              </div>
               
            
                    </form>
                </div>
            </div>
        </nav>
        <!-- Header-->
        <header class="bg-dark py-4">
            <div class="container px-4 px-lg-5 my-0">
                <div class="text-center text-white">
                    <h1 class="display-4 fw-bolder">Jade</h1>
                    <p class="lead fw-normal text-white-50 mb-0">Best clothes at the best price!</p>
                </div>
            </div>
        </header>
       <div class=" container my-5">
            <asp:GridView ID="ShoppingCart" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-bordered" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="ID Product">
                        <ItemTemplate>
                             <%# Eval ("ProductId") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                             <%# Eval ("Image") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product">
                        <ItemTemplate>
                             <%# Eval ("Name") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                             <%# "$" + Eval ("UnitPrice") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                             <%# Eval ("Quantity") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                             <%# "$" + Convert.ToDouble(Eval("Quantity")) * Convert.ToDouble(Eval("UnitPrice"))  %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                             <a href='deletefromcart.aspx?productId=<%# Eval ("ProductId") %>' class="btn btn-danger">Eliminar</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="row">
                <div class="col-sm-12 col-lg-11 col-md-11">
                    <asp:Label ID="Total" CssClass="form-label" runat="server" Text="" Font-Bold="True"></asp:Label>
                </div>
               
           
          <div class="mb-3">
                                <asp:Label ID="LabelProduct" CssClass="form-label" runat="server" Text="Departamento" Font-Bold="True"></asp:Label>
                                <asp:TextBox ID="Product" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                  <div class="mb-3">
                                <asp:Label ID="Label1" CssClass="form-label" runat="server" Text="Ciudad" Font-Bold="True"></asp:Label>
                                <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                                  <div class="mb-3">
                                <asp:Label ID="Label2" CssClass="form-label" runat="server" Text="Numero de casa" Font-Bold="True"></asp:Label>
                                <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                                  <div class="mb-3">
                                <asp:Label ID="Label3" CssClass="form-label" runat="server" Text="Punto de referencia" Font-Bold="True"></asp:Label>
                                <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                                  <div class="mb-3">
                                <asp:Label ID="Label4" CssClass="form-label" runat="server" Text="Numero de contacto" Font-Bold="True"></asp:Label>
                                <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                 <div class="col-sm-12 col-md-1 col-lg-1">
                    <asp:Button ID="CheckOut" CssClass="btn btn-primary" runat="server" Text="Comprar" OnClick="CheckOut_Click" />
                </div>
                </div>
          
                
            </div>
         <asp:Literal ID="alerta" runat="server" Text=""></asp:Literal>
    </form>
</body>

</html>
