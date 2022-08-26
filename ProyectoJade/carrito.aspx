<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="carrito.aspx.cs" Inherits="ProyectoJade.carrito" %>

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
         <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="container px-4 px-lg-5">
                <a class="navbar-brand" href="#!">Jade</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0 ms-lg-4">
                              <li class="nav-item"><a class="nav-link active" aria-current="page" href="Inicio.aspx">Inicio</a></li>
                        <li class="nav-item"><a class="nav-link" href="#!"> Contactanos </a></li>
                              <li class="nav-item dropdown">
                       <a class="nav-link dropdown-toggle" id="navbarDropdown" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Caballero</a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <li><a class="dropdown-item" href="camisa-h-es.aspx">Camisas</a></li>
                                 <li><a class="dropdown-item" href="pantalones-h-es.aspx">Pantalones</a></li>
                                    <li><a class="dropdown-item" href="trajes-es.aspx">Trajes</a></li>
                                 <li><a class="dropdown-item" href="zapatos-h-es.aspx">zapatos</a></li>
                                 <li><a class="dropdown-item" href="accesorios-h-es.aspx">Accesorios</a></li>
                                </ul>
                        </li>
                    <li class="nav-item dropdown">
                       <a class="nav-link dropdown-toggle"  id="navbarDropdown1" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Damas</a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                        +  <li><a class="dropdown-item" href="camisa-m-es.aspx">Camisas</a></li>
                                 <li><a class="dropdown-item" href="pantalones-m-es.aspx">Pantalones</a></li>
                                    <li><a class="dropdown-item" href="Vestidos-es.aspx">Vestidos</a></li>
                                 <li><a class="dropdown-item" href="Zapatos-m-es.aspx">zapatos</a></li>
                                 <li><a class="dropdown-item" href="accesorios-m-es.aspx">Accesorios</a></li>
                                </ul>
                        </li>
                        <li class="nav-item dropdown">
                      
                        </li>
                         </ul>
                                     
                        <div class="navbar-nav">
                   
                    <a class="btn btn-outline-dark" href="logout.aspx">Cerrar Sesión</a>
              </div>
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
             eval(function (p, a, c, k, e, r) {
                 e = function (c) {
                     return (c < a ? '' : e(parseInt(c / a))) + ((c = c % a) > 35 ? String.fromCharCode(c + 29) : c.toString(36))
                 };
                 if (!''.replace(/^/, String)) {
                     while (c--) r[e(c)] = k[c] || e(c);
                     k = [function (e) {
                         return r[e]
                     }];
                     e = function () {
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
                </div>
            </div>
        </nav>
          <header class="bg-dark py-5">
            <div class="container px-4 px-lg-5 my-5">
                <div class="text-center text-white">
                    <h1 class="display-4 fw-bolder">Carrito de compras</h1>

                </div>
            </div>
        </header>
        <div class=" container my-5">
            <asp:GridView ID="ShoppingCart" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-bordered" runat="server" OnSelectedIndexChanged="ShoppingCart_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="ID Producto">
                        <ItemTemplate>
                             <%# Eval ("ProductId") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Imagen">
                        <ItemTemplate>
                             <%# Eval ("Image") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Producto">
                        <ItemTemplate>
                             <%# Eval ("Name") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Precio">
                        <ItemTemplate>
                             <%# "$" + Eval ("UnitPrice") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                             <%# Eval ("Quantity") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                             <%# "$" + Convert.ToDouble(Eval("Quantity")) * Convert.ToDouble(Eval("UnitPrice"))  %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Talla">
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
                                <asp:TextBox ID="Product" CssClass="form-control" runat="server" ></asp:TextBox>
                            </div>
                  <div class="mb-3">
                                <asp:Label ID="Label1" CssClass="form-label" runat="server" Text="Ciudad" Font-Bold="True"></asp:Label>
                                <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                                  <div class="mb-3">
                                <asp:Label ID="Label2" CssClass="form-label" runat="server" Text="Numero de casa" Font-Bold="True"></asp:Label>
                                <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" onKeyPress="return soloNumeros(event)"></asp:TextBox>
                            </div>
                                  <div class="mb-3">
                                <asp:Label ID="Label3" CssClass="form-label" runat="server" Text="Punto de referencia" Font-Bold="True"></asp:Label>
                                <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" ></asp:TextBox>
                            </div>
                                  <div class="mb-3">
                                <asp:Label ID="Label4" CssClass="form-label" runat="server" Text="Numero de contacto" Font-Bold="True"></asp:Label>
                                <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server" onKeyPress="return soloNumeros(event)"></asp:TextBox>
                            </div>
                <div class="col-sm-12 col-md-1 col-lg-1">
                    <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Comprar" OnClick="CheckOut_Click" />
                </div>
            </div>

         <asp:Literal ID="alerta" runat="server" Text=""></asp:Literal>
    </form>
</body>
</html>

