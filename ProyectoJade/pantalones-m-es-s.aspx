<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pantalones-m-es-s.aspx.cs" Inherits="ProyectoJade.pantalones_m_es_s" %>

<!DOCTYPE html>

<html lang="en">
    <head runat="server">
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>Jade</title>
        <!-- Favicon-->
        <link rel="icon" type="image/x-icon" href="assets/favicon.ico" />
        <!-- Bootstrap icons-->
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css" rel="stylesheet" />
        <!-- Core theme CSS (includes Bootstrap)-->
        <link href="css3/styles.css" rel="stylesheet" />
          <style>
        
        .card-image-top{
            height:30%;
            max-height:30%;
            width:auto;
        }
    </style>
    </head>
    <body>
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
                    ppatron = /\d/; // Solo acepta números// 4
                    te = String.fromCharCode(tecla); // 5
                    return patron.test(te); // 6
                }
            </script>    
        <!-- Navigation-->
        <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="container px-4 px-lg-5">
                <a class="navbar-brand" href="inicio-es-s.aspx">Inicio</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0 ms-lg-4">
                          <li class="nav-item"><a class="nav-link" href="Login.aspx"> Iniciar sesión </a></li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" id="navbarDropdown" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Caballero</a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <li><a class="dropdown-item" href="camisa-h-es-s.aspx">Camisa</a></li>
                                <li><a class="dropdown-item" href="pantalones-h-es-s.aspx">Pantalones</a></li>
                                  <li><a class="dropdown-item" href="trajes-es-s.aspx">Trajes</a></li>
                                <li><a class="dropdown-item" href="zapatos-h-es-s.aspx">Zapatos</a></li>
                                <li><a class="dropdown-item" href="accesorios-h-es-s.aspx">Accesorios</a></li>
                            </ul>
                        </li>
                         <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" id="navbarDropdown" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Damas</a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <li><a class="dropdown-item" href="camisa-m-es-s.aspx">Camisa</a></li>
                                <li><a class="dropdown-item" href="#">Pantalones</a></li>
                                  <li><a class="dropdown-item" href="Vestidos-es-s.aspx">Vestidos</a></li>
                                <li><a class="dropdown-item" href="Zapatos-m-es-s.aspx">Zapatos</a></li>
                                 <li><a class="dropdown-item" href="accesorios-m-es-s.aspx">Accesorios</a></li>
                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                      <a class="nav-link dropdown-toggle"  id="navbarDropdown2" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Idioma</a>
                           <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                               <li><a class="dropdown-item" href="#!">Español</a></li>
                               <li><hr class="dropdown-divider" /></li>
                           <li><a class="dropdown-item" href="pantalones-m-eng-s.aspx">English</a></li>
                               </ul>
                       </li>
                    </ul>
                    <form class="d-flex">
                      <div class="navbar-nav">
                    <a class="nav-link active" href="carrito.aspx">Carrito</a>
                      </div>
                    </form>
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
         <a href="#" onclick="doGTranslate('en|es');return false;" title="Español" class="gflag nturl" style="background-position:-600px -200px;"><img src="//gtranslate.net/flags/blank.png" height="16px" width="16px" alt="Spanish" /></a>
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
        <!-- Header-->
        <header class="bg-dark py-4">
            <div class="container px-4 px-lg-5 my-0">
                <div class="text-center text-white">
                    <h1 class="display-4 fw-bolder">Pantalones</h1>
                    <p class="lead fw-normal text-white-50 mb-0">Mejor ropa al mejor precio!</p>
                </div>
            </div>
        </header>
        <!-- Section-->
             <div class="container my-4">
            <div class="row">
                <asp:Literal ID="ProductsLiteral" runat="server"></asp:Literal>
            </div>
                 </div>
             <asp:Literal ID="alerta" runat="server" Text=""></asp:Literal>
        <!-- Footer-->
        <!-- Bootstrap core JS-->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
        <!-- Core theme JS-->
        <script src="js/scripts.js"></script>
    </form>
    </body>
</html>
