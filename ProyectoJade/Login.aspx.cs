using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoJade
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bool logged_in = Convert.ToBoolean(Session["logged_in"]);
                bool isAdmin = Convert.ToBoolean(Session["isAdmin"]);
                if (logged_in)
                {
                    if (isAdmin)
                        Response.Redirect("administrarproductos");
                    Response.Redirect("Inicio");
                }

            }
            catch (Exception ex)
            {
                Response.Redirect("Inicio.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TxtUsuario.Text.Trim();
            string password = TxtContra.Text;


            int login = metodos.login(username, password);
            int isAdmin = metodos.Check_Admin(username);

            if (login != 0)
            {
                Session["logged_in"] = true;
                Session["username"] = username;
                Session["userID"] = login;
                Session["addedToCart"] = false;
                metodos.SetCartId();
                if (isAdmin == 1)
                {
                    Session["isAdmin"] = true;
                    Response.Redirect("administrarproductos.aspx");
                }

                Session["isAdmin"] = false;
                Response.Redirect("Inicio.aspx");
            }
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Los datos de ingreso de sesión no son válidos " + login + "');", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio-es-s.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio-es-s.aspx");
        }
    }
}