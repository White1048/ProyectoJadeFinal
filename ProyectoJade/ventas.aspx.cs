using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoJade
{
    public partial class ventas : System.Web.UI.Page
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

            Load_Sales();
        }

        protected void Load_Sales()
        {
            DataTable myTable = metodos.Get_Sales();
            Sales.DataSource = myTable;
            Sales.DataBind();
        }


    }
}