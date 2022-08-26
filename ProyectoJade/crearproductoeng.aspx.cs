using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace ProyectoJade
{
    public partial class crearproductoeng : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                ddl();
            }

        }

        private void ddl()
        {
            MySqlConnection con = metodos.conexion;
            con.Open();
            MySqlCommand cmd = new MySqlCommand(String.Format("SELECT * FROM categorias"), con);
            DropDownList1.DataSource = cmd.ExecuteReader();
            DropDownList1.DataTextField = "nombre_categ";
            DropDownList1.DataValueField = "id_categoria";
            DropDownList1.DataBind();
            con.Close();
        }

        protected void Create_Click(object sender, EventArgs e)
        {

            string strFileName;
            string strFilePath;
            string strFolder;

            strFolder = Server.MapPath("./images/");

            if (PhotoFile.HasFile)
            {
                strFileName = PhotoFile.PostedFile.FileName;
                strFileName = Path.GetFileName(strFileName);

                if (!Directory.Exists(strFolder))
                {
                    Directory.CreateDirectory(strFolder);
                }
                // Save the uploaded file to the server.
                strFilePath = strFolder + strFileName;
                if (!File.Exists(strFilePath))
                {
                    PhotoFile.PostedFile.SaveAs(strFilePath);
                }
                string product = Product.Text.Trim();
                double price = Convert.ToDouble(Price.Text.Trim());
                int qty = Convert.ToInt32(Quantity.Text.Trim());
                string image = strFileName;
                string tipo = DropDownList1.SelectedValue;
                string desproduct = descripcion.Text.Trim();
                int guardado = metodos.Add_Producteng(product, price, qty, image, tipo, desproduct);

                if (guardado == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Registro guardado exitosamente');", true);

                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Hubo un error al guardar los datos');", true);

            }
        }
    }
}