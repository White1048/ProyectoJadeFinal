<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="ProyectoJade.IniciarSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
      <meta charset="UTF-8">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Log</title>
    <link href="dist(Login)/style.css" rel="stylesheet"/>
     <link href="dist(Login)/Background.css" rel="stylesheet"/>
     <script src="SweetAlert/sweetalert2.all.min.js"></script>
    <script src="SweetAlert/sweetalert2.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button2" runat="server" Text="Registrarse" ForeColor="white" BackColor="#009975" />
        <div class="wrapper fadeInDown">
  <div id="formContent">
    <!-- Tabs Titles -->
    <h2 class="active"> Bienvenidos </h2>

    <!-- Icon -->
    <div class="fadeIn first">
      <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTVjhgto_r_0qlA6M7LhJNw3X0GtZp24vQrcQ&usqp=CAU" id="icon" alt="User Icon" />
    </div>

    <!-- Login Form -->
    <form>
      <%--<input type="text" id="login" class="fadeIn second" name="login" placeholder="login"/>--%>
        <asp:TextBox ID="TxtUsuario" class="fadeIn second" name="login" placeholder="Usuario" minlength="4" MaxLength="15" runat="server"> </asp:TextBox>
      <%--<input type="text" id="password" class="fadeIn third" name="login" placeholder="password"/>--%>
        <asp:TextBox ID="TxtContra" class="fadeIn third" name="login" placeholder="Contraseña" runat="server"></asp:TextBox>
     <%-- <input type="submit" class="fadeIn fourth" value="Log In"/>--%>
        <asp:Button ID="Button1" runat="server" class="fadeIn fourth" value="Log In" Text="Login"   BackColor="#009975"/>
        <%--Esto es el codigo de las alertas--%>
        <asp:Literal ID="alerta" runat="server" Text=""></asp:Literal>
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>
        <script src="js/bootstrap.min.js"></script>
    </form>

    <!-- Remind Passowrd -->
    <div id="formFooter">
      <a class="underlineHover" href="#">Perdiste tu contraseña? </a>
    </div>

  </div>
</div>
<!-- partial -->
    </form>
</body>
</html>

