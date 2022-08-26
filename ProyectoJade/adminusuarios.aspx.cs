using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ProyectoJade
{
    public partial class adminusuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bool logged_in = Convert.ToBoolean(Session["logged_in"]);
                bool isAdmin = Convert.ToBoolean(Session["isAdmin"]);

                if (!isAdmin)
                    Response.Redirect("Inicio");

            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }
            Load_Usuarios();
        }
        protected void Load_Usuarios()
        {
            DataTable myTable = metodos.Fetch_Usuarios(true);
            UserList.DataSource = myTable;
            UserList.DataBind();
        }
        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {           
            if (UsuarioId.Text.Trim() != "")
            {
                alerta.Text = "<script>Swal.fire('Se selecciono correctamente', 'success') </script>";
                int Id = Convert.ToInt32(UsuarioId.Text);
                Fetch_usuario(Id);
            }
            else
                alerta.Text = "<script>Swal.fire('OOPS', 'No deje espacios en blanco', 'error') </script>";
        }
        protected void Fetch_usuario(int Id)
        {
            try
            {
                usuarios usuario = metodos.Search_Usuarios(Id);
                if (usuario.Id != 0)
                {

                    Nombre.Text = usuario.Nombre;
                    Apellido.Text = usuario.Apellido.ToString();
                    Username.Text = usuario.Username.ToString();
                    //Password.Text = usuario.Password.ToString();
                    Correo.Text = usuario.Correo.ToString();
                    Admin.Text = usuario.Admin.ToString();

                }
                else
                   alerta.Text = "<script>Swal.fire('OOPS', 'Hubo un error al obtener los datos', 'error') </script>";

            }
            catch (Exception exc)
            {
                alerta.Text = "<script>Swal.fire('OOPS', 'Hubo un error al obtener los datos', 'error') </script>";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int Id;
            var isNumber = int.TryParse(UsuarioId.Text.Trim(), out Id);

            if (isNumber)
            {
                int eliminado = metodos.Delete_Usuarios(Id);

                if (eliminado == 1)
                {
                    alerta.Text = "<script>Swal.fire('El producto se elimino', 'succes') </script>";
                    Load_Usuarios();
                    Nombre.Text = string.Empty;
                    Apellido.Text = string.Empty;
                    Username.Text = string.Empty;
                    //Password.Text = string.Empty;
                    Correo.Text = string.Empty;
                    Admin.Text = string.Empty;

                }
                else
                    alerta.Text = "<script>Swal.fire('OOPS', 'Hubo un error al eliminar el producto', 'error') </script>";
            }
        }
    }
}