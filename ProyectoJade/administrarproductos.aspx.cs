using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace ProyectoJade
{
    public partial class administrarproductos : System.Web.UI.Page
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
           
            Load_Products();
        }
        
        protected void Load_Products()
        {
            DataTable myTable = metodos.Fetch_Products(true);
            ProductsList.DataSource = myTable;
            ProductsList.DataBind();
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (ProductId.Text.Trim() != "")
            {
                alerta.Text = "<script>Swal.fire('Se selecciono correctamente', 'succes') </script>";
                int Id = Convert.ToInt32(ProductId.Text);
                Fetch_product(Id);
            }
            else
                alerta.Text = "<script>Swal.fire('OOPS', 'No deje espacios en blanco', 'error') </script>";
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string strFileName;
            string strFilePath;
            string strFolder;

            strFolder = Server.MapPath("./images/");
            //try
            //{
                int id = Convert.ToInt32(ProductId.Text);
                string product = Product.Text.Trim();
                double price = Convert.ToDouble(Price.Text.Trim());
                int quantity = Convert.ToInt32(Quantity.Text.Trim());
                int tipo = Convert.ToInt32(DropDownList1.SelectedValue.Trim());
                if (!Directory.Exists(strFolder))
                {
                    Directory.CreateDirectory(strFolder);
                }

                if (PhotoFile.HasFile)
                {
                    // Obtener el nombre del archivo subido.
                    strFileName = PhotoFile.PostedFile.FileName;
                    strFileName = Path.GetFileName(strFileName);
                    string foto = strFileName;
                    // Guardando el archivo en el servidor
                    strFilePath = strFolder + strFileName;
                    if (!File.Exists(strFilePath)) //Si el archivo subido no existe, lo crea en el servidor
                    {
                        PhotoFile.PostedFile.SaveAs(strFilePath);
                    }

                    int guardado = metodos.Update_Product(id, product, price, quantity, foto, tipo);
                    if (guardado == 1)
                    {
                    alerta.Text = "<script>Swal.fire('El producto se actualizo con exito', 'success') </script>";
                    Load_Products();
                        Fetch_product(id);
                    }
                    else
                        alerta.Text = "<script>Swal.fire('OOPS', 'Hubo un error al obtener los datos', 'error') </script>";
                }
                else
                {
                    int guardado = metodos.Update_Product(id, product, price, quantity, tipo);
                    if (guardado == 1)
                    {
                    alerta.Text = "<script>Swal.fire('El producto se actualizo con exito', 'success') </script>";
                    Load_Products();
                        Fetch_product(id);
                    }
                    else
                    alerta.Text = "<script>Swal.fire('OOPS', 'Hubo un error al actualizar el producto', 'error') </script>";

            }
            //}
            //catch (Exception ex)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Hubo un error al editar el registro.');", true);
            //}

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id;
            var isNumber = int.TryParse(ProductId.Text.Trim(), out id);

            if (isNumber)
            {
                int eliminado = metodos.Delete_Product(id);

                if (eliminado == 1)
                {
                    alerta.Text = "<script>Swal.fire('El producto se elimino con exito', 'success') </script>";
                    Load_Products();
                    Product.Text = string.Empty;
                    Price.Text = string.Empty;
                    Quantity.Text = string.Empty;
                    ImagePreview.ImageUrl = null;
                }
                else
                    alerta.Text = "<script>Swal.fire('OOPS', 'Hubo un error al eliminar el producto', 'error') </script>";
            }

        }
        protected void Fetch_product(int Id)
        {
            try
            {
                Product respuesta = metodos.Search_Product(Id);
                if (respuesta.Id != 0)
                {
                    ImagePreview.ImageUrl = "/images/" + respuesta.Image;
                    Product.Text = respuesta.Name;
                    Price.Text = respuesta.Price.ToString();
                    Quantity.Text = respuesta.Quantity.ToString();
                }
                else
                    alerta.Text = "<script>Swal.fire('OOPS', 'Hubo un error al obtener los datos', 'error') </script>";

            }
            catch (Exception exc)
            {
                alerta.Text = "<script>Swal.fire('OOPS', 'Hubo un error al obtener los datos', 'error') </script>";
            }

        }
    }
}