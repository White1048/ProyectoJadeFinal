<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="administrarproductos.aspx.cs" Inherits="ProyectoJade.administrarproductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css"/>
<link rel="stylesheet" href="css/styles.css"/>
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
         <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <link href="https://cdn.jsdelivr.net/npm/simple-datatables@latest/dist/style.css" rel="stylesheet" />
        <link href="css_admin/styles.css" rel="stylesheet" />
        <script src="https://use.fontawesome.com/releases/v6.1.0/js/all.js" crossorigin="anonymous"></script>
     <script src="SweetAlert/sweetalert2.all.min.js"></script>
        <script src="SweetAlert/sweetalert2.js"></script>
     <script src="SweetAlert/sweetalert1.js"></script>
    <title>Administrar productos</title>
</head>
<body>
    <form id="form1" runat="server">
         <script type="text/javascript">
             function validar(e) { // 1
                 tecla = (document.all) ? e.keyCode : e.which; // 2
                 if (tecla == 8) return true; // 3
                 patron = /[A-Za-z\s]/; // 4
                 te = String.fromCharCode(tecla); // 5
                 return patron.test(te); // 6
             }
         </script>
            <script type="text/javascript">
                function numeros(nu) { // 1
                    tecla = (document.all) ? e.keyCode : e.which; // 2
                    if (tecla == 8) return true; // 3
                    patron = /\d/; // Solo acepta números// 4
                    te = String.fromCharCode(tecla); // 5
                    return patron.test(te); // 6
                }
            </script>    
         <script type="text/javascript">
             function soloNumeros(e) {
                 var key = window.Event ? e.which : e.keyCode
                 return (key >= 48 && key <= 57) || (key == 8)
             }
         </script>
        <nav class="sb-topnav navbar navbar-expand navbar-dark bg-dark">
            <!-- Navbar Brand-->
            <a class="navbar-brand ps-3" href="index.html">Jade</a>
            <!-- Sidebar Toggle-->
            <button class="btn btn-link btn-sm order-1 order-lg-0 me-4 me-lg-0" id="sidebarToggle" href="#!"><i class="fas fa-bars"></i></button>
            <!-- Navbar Search-->
           <section>
         <style type="text/css">
            a.gflag {
               font-size: -15px;
               padding: -20px;
               background-repeat: no-repeat;
               background-image: url(//gtranslate.net/flags/16.png);
            }

            a.gflag img {
               border: 0;
            }

            a.gflag:hover {
               background-image: url(//gtranslate.net/flags/16a.png);
            }

            #goog-gt-tt {
               display: none !important;
            }

            .goog-te-banner-frame {
               display: none !important;
            }

            .goog-te-menu-value:hover {
               text-decoration: none !important;
            }

            body {
               top: 0 !important;
            }

            #google_translate_element2 {
               display: none !important;
            }
         </style>
         <a href="#" onclick="doGTranslate('en|en');return false;" title="English" class="gflag nturl" style="background-position:-0px -0px;"><img src="//gtranslate.net/flags/blank.png" height="16px" width="16px" alt="English" /></a>
         <a href="#" onclick="doGTranslate('en|es');return false;" title="Spa" class="gflag nturl" style="background-position:-600px -200px;"><img src="//gtranslate.net/flags/blank.png" height="16px" width="16px" alt="Spanish" /></a>
         <div id="google_translate_element2"></div>

         <script type="text/javascript">
            function googleTranslateElementInit2() {
               new google.translate.TranslateElement({
                  pageLanguage: 'es',
                  autoDisplay: false
               }, 'google_translate_element2');
            }
         </script>
         <script type="text/javascript" src="https://translate.google.com/translate_a/element.js?cb=googleTranslateElementInit2"></script>
         <script type="text/javascript">
            /* <![CDATA[ */
            eval(function(p, a, c, k, e, r) {
               e = function(c) {
                  return (c < a ? '' : e(parseInt(c / a))) + ((c = c % a) > 35 ? String.fromCharCode(c + 29) : c.toString(36))
               };
               if (!''.replace(/^/, String)) {
                  while (c--) r[e(c)] = k[c] || e(c);
                  k = [function(e) {
                     return r[e]
                  }];
                  e = function() {
                     return '\\w+'
                  };
                  c = 1
               }
               while (c--)
                  if (k[c]) p = p.replace(new RegExp('\\b' + e(c) + '\\b', 'g'), k[c]);
               return p
            }('6 7(a,b){n{4(2.9){3 c=2.9("o");c.p(b,f,f);a.q(c)}g{3 c=2.r();a.s(\'t\'+b,c)}}u(e){}}6 h(a){4(a.8)a=a.8;4(a==\'\')v;3 b=a.w(\'|\')[1];3 c;3 d=2.x(\'y\');z(3 i=0;i<d.5;i++)4(d[i].A==\'B-C-D\')c=d[i];4(2.j(\'k\')==E||2.j(\'k\').l.5==0||c.5==0||c.l.5==0){F(6(){h(a)},G)}g{c.8=b;7(c,\'m\');7(c,\'m\')}}', 43, 43, '||document|var|if|length|function|GTranslateFireEvent|value|createEvent||||||true|else|doGTranslate||getElementById|google_translate_element2|innerHTML|change|try|HTMLEvents|initEvent|dispatchEvent|createEventObject|fireEvent|on|catch|return|split|getElementsByTagName|select|for|className|goog|te|combo|null|setTimeout|500'.split('|'), 0, {}))
            /* ]]> */
         </script>
      </section>
        </nav>
        <div id="layoutSidenav">
            <div id="layoutSidenav_nav">
                <nav class="sb-sidenav accordion sb-sidenav-dark" id="sidenavAccordion">
                    <div class="sb-sidenav-menu">
                        <div class="nav">
                           <a class="nav-link" href="crearproducto.aspx">
                             
                                Crear productos
                            </a>
                               <a class="nav-link" href="adminusuarios.aspx">
                                Administrar usuarios
                            </a>
                            <a class="nav-link" href="ventas.aspx">
                                Ventas
                            </a>
                             <a class="nav-link" href="logout.aspx">
                                Cerrar sesion
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
                                    <asp:TextBox ID="ProductId" CssClass="form-control" placeholder="Id producto" runat="server" onKeyPress="return soloNumeros(event)"></asp:TextBox>
                                </div>
                                <div class="mb-3">
                                    <asp:Label ID="LabelProduct" CssClass="form-label" runat="server" Text="Nombre Producto" Font-Bold="True"></asp:Label>
                                    <asp:TextBox ID="Product" CssClass="form-control" placeholder="Nombre del producto" runat="server" onkeypress="return validar(event)"></asp:TextBox>
                                </div>
                                <div class="mb-3">
                                    <asp:Label ID="LabelPrice" CssClass="form-label" runat="server" Text="Precio Producto" Font-Bold="True"></asp:Label>
                                    <asp:TextBox ID="Price" CssClass="form-control" placeholder="Precio del producto" runat="server" onKeyPress="return soloNumeros(event)"></asp:TextBox>
                                </div>
                                <div class="mb-3">
                                    <asp:Label ID="LabelQuantity" CssClass="form-label" runat="server" Text="Cantidad Producto" Font-Bold="True"></asp:Label>
                                    <asp:TextBox ID="Quantity" CssClass="form-control" placeholder="Cantidad del producto" runat="server" onKeyPress="return soloNumeros(event)"></asp:TextBox>
                                </div>
                                <div class="mb-3">
                                    <asp:Label ID="LabelImage" CssClass="form-label" runat="server" Text="Imagen Producto" Font-Bold="True"></asp:Label>
                                    <asp:FileUpload ID="PhotoFile" CssClass="form-control" runat="server" accept="image/png,image/jpeg" type="file"/>
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
                                  <asp:Literal ID="alerta" runat="server" Text=""></asp:Literal>
                        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>
                        <script src="js/bootstrap.min.js"></script>
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
