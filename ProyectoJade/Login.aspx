<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoJade.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/> 
    <!-- Required meta tags-->
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="Colorlib Templates">
    <meta name="author" content="Colorlib">
    <meta name="keywords" content="Colorlib Templates">
    <link href="css2/main.css" rel="stylesheet"
        <script src="SweetAlert/sweetalert2.all.min.js"></script>
        <script src="SweetAlert/sweetalert2.js"></script>
     <script src="SweetAlert/sweetalert1.js"></script>

    <!-- Title Page-->
    <title>Login</title>

    <!-- Icons font CSS-->
    <link href="vendorLOGIN/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all">
    <link href="vendorLOGIN/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all">
    <!-- Font special for pages-->
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i" rel="stylesheet">

    <!-- Vendor CSS-->
    <link href="vendorLOGIN/select2/select2.min.css" rel="stylesheet" media="all">
    <link href="vendorLOGIN/datepicker/daterangepicker.css" rel="stylesheet" media="all">

    <!-- Main CSS-->
    <link href="cssLOGIN/main.css" rel="stylesheet" media="all">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
             <div class="page-wrapper bg-blue p-t-100 p-b-100 font-robo">      
                 <asp:Button ID="Button3" runat="server" Text="Volver" Width="93px" Height="50px" BackColor="White" ForeColor="#2CAF96" OnClick="Button3_Click" ViewStateMode="Enabled"/>
        <div class="wrapper wrapper--w680">
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
            <div class="card card-1">
               
                <div class="card-body">
                    
                    <h2 class="title">Iniciar Sesion
                    </h2>
                    <form method="POST">
                        <div class="input-group">
                           <%-- <input class="input--style-1" type="text" placeholder="User" name="name">--%>
                            <asp:TextBox ID="TxtUsuario" runat="server" class="input--style-1" placeholder="Usuario"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <%--<input class="input--style-1" type="password" placeholder="Password" name="name">--%>
                            <asp:TextBox ID="TxtContra" runat="server" class="input--style-1" type="password"  placeholder="Contraseña"></asp:TextBox>
                        </div>             
                        <asp:Literal ID="alerta" runat="server" Text=""></asp:Literal>
                        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>
                        <script src="js/bootstrap.min.js"></script>
                        <div class="p-t-20">
                           <%-- <button class="btn btn--radius btn--green" type="submit">Log In</button>--%>
                            <asp:Button ID="Button1" runat="server" Text="Iniciar Sesion" class="btn btn--radius btn--green" OnClick="Button1_Click" Width="144px"/>
                            <asp:Button ID="Button2" runat="server" Text="Registro" class="btn btn--radius btn--green" Width="144px" OnClick="Button2_Click"/>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
        </div>
         <!-- Jquery JS-->
    <script src="vendorLOGIN/jquery/jquery.min.js"></script>
    <!-- Vendor JS-->
    <script src="vendorLOGIN/select2/select2.min.js"></script>
    <script src="vendorLOGIN/datepicker/moment.min.js"></script>
    <script src="vendorLOGIN/datepicker/daterangepicker.js"></script>

    <!-- Main JS-->
    <script src="jsLOGIN/global.js"></script>
    </form>
</body>
</html>
