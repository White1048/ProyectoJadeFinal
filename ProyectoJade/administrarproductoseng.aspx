<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="administrarproductoseng.aspx.cs" Inherits="ProyectoJade.administrarproductoseng" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
 <nav class="sb-topnav navbar navbar-expand navbar-dark bg-dark">
            <!-- Navbar Brand-->
            <a class="navbar-brand ps-3" href="inicio_admin.aspx">Jade</a>
            <!-- Sidebar Toggle-->
            <button class="btn btn-link btn-sm order-1 order-lg-0 me-4 me-lg-0" id="sidebarToggle" href="#!"><i class="fas fa-bars"></i></button>
            <!-- Navbar Search-->
           
        </nav>
        <div id="layoutSidenav">
            <div id="layoutSidenav_nav">
                <nav class="sb-sidenav accordion sb-sidenav-dark" id="sidenavAccordion">
                    <div class="sb-sidenav-menu">
                        <div class="nav">
                            <a class="nav-link" href="admineng.aspx">
                                
                               Home
                            </a>
  <a class="nav-link" href="crearproductoeng.aspx">
                                Create product
                            </a>
                              <a class="nav-link" href="administrarproductoseng.aspx">
                             
                                Edit product
                            </a>
                              <a class="nav-link" href="ventas.aspx">
                              
                                Sales
                            </a>
                </nav>
            </div>
            <div class="container">
            <div class="row">
                <div class="col-sm-6  m-auto">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title ">Administrar productos</h5>
                            <div class="myform-top">
                                <asp:Image ID="ImagePreview" Width="90%" CssClass="py-3" runat="server" />
                            </div>
                            <div class="myform-bottom">
                                <div class="mb-3">
                                    <asp:TextBox ID="ProductId" CssClass="form-control" placeholder="Id producto" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-3">
                                    <asp:Label ID="LabelProduct" CssClass="form-label" runat="server" Text="Nombre Producto" Font-Bold="True"></asp:Label>
                                    <asp:TextBox ID="Product" CssClass="form-control" placeholder="Nombre del producto" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-3">
                                    <asp:Label ID="LabelPrice" CssClass="form-label" runat="server" Text="Precio Producto" Font-Bold="True"></asp:Label>
                                    <asp:TextBox ID="Price" CssClass="form-control" placeholder="Precio del producto" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-3">
                                    <asp:Label ID="LabelQuantity" CssClass="form-label" runat="server" Text="Cantidad Producto" Font-Bold="True"></asp:Label>
                                    <asp:TextBox ID="Quantity" CssClass="form-control" placeholder="Cantidad del producto" runat="server"></asp:TextBox>
                                </div>
                                <div class="mb-3">
                                    <asp:Label ID="LabelImage" CssClass="form-label" runat="server" Text="Imagen Producto" Font-Bold="True"></asp:Label>
                                    <asp:FileUpload ID="PhotoFile" CssClass="form-control" runat="server" />
                                </div>
                                <div calss="mb-3">
                                     <asp:DropDownList ID="DropDownList1" runat="server">
                                 </asp:DropDownList>
                                </div>
                                <div class="pt-2">
                                    <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" CssClass="btn btn-primary" Width="30%" OnClick="btnSeleccionar_Click" ></asp:Button>
                                    <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-success" Width="30%" OnClick="btnEditar_Click"></asp:Button>
                                    <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Width="30%" Text="Eliminar" OnClick="btnEliminar_Click" />
                                </div>
                                
                            </div>
                        </div>

                    </div>
                    
                </div>
                

            </div>

            <div class="my-4">
                <div class="center">
                    <asp:GridView ID="ProductsList" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                   <%# Eval ("Id") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                   <%# Eval ("Name") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Precio">
                                <ItemTemplate>
                                   <%# Eval ("Price") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad">
                                <ItemTemplate>
                                   <%# Eval ("Quantity") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Imagen">
                                <ItemTemplate>
                                   <%# Eval ("Image") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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
