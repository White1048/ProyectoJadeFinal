using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace ProyectoJade
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text.Trim() != "" && txtclave.Text.Trim() != "" && txtconfirm.Text.Trim() != "" && txtfirst.Text.Trim() != "" && txtapellido.Text.Trim() != "" && txtgmail.Text.Trim() != "")
            {
                if (txtclave.Text == txtconfirm.Text)
                {
                    string nombre;
                    string apellido;
                    string password;
                    string confirmPassword;
                    string usuario;
                    string correo;
                    nombre = txtfirst.Text;
                    apellido = txtapellido.Text;
                    usuario = txtusuario.Text;
                    password = txtclave.Text;
                    confirmPassword = txtconfirm.Text;
                    correo = txtgmail.Text;
                    if (metodos.Sign_Up(usuario, password, confirmPassword, nombre, apellido, correo) != 0)
                    {
                        alerta.Text = "<script>Swal.fire('Successfully registered', 'Thank you for choosing us!', 'success'); </script>";

                        txtfirst.Text = "";
                        txtapellido.Text = "";
                        txtusuario.Text = "";
                        txtclave.Text = "";
                        txtconfirm.Text = "";
                        txtgmail.Text = "";
                    }
                    else
                    {
                        alerta.Text = "<script>Swal.fire('This user already exists', 'Choose a new user name', 'error'); </script>";
                    }

                }
                else
                {
                    alerta.Text = "<script>Swal.fire('Incorrect password', 'Repeat your password.', 'error');</script>";
                }
            }
            else
            {
                alerta.Text = "<script>Swal.fire('OOPS', 'Do not leave blank spaces', 'error') </script>";
            }
        }
        

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}