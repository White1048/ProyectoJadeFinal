using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoJade
{
    public partial class Zapatos_m_es : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bool logged_in = Convert.ToBoolean(Session["logged_in"]);


                if (!logged_in)
                    Response.Redirect("Login.aspx");

            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }
            bool addedToCart;
            if (!string.IsNullOrEmpty(Session["addedToCart"].ToString()) && bool.TryParse(Session["addedToCart"].ToString(), out addedToCart))
                if (addedToCart)
                    alerta.Text = "<script>Swal.fire('Producto agregado al carrito!', 'Gracias por preferirnos!', 'success'); </script>";
            Session["addedToCart"] = false;
            Load_Products();
        }
        protected void Load_Products()
        {
            string template = "";

            DataTable products = metodos.Fetch_zapatos_m(false);

            foreach (DataRow row in products.Rows)
            {
                template += "<div class='col-sm-12 col-md-3 col-lg-3'> " +
                                "<div class='card h-100'> " +
                                    "<img src='images/" + row["Image"] + "' class='card-img-top'/>" +
                                    "<div class='card-body p-4'> " +
                                        "<h5 class='card-title' class='text-center'>" + row["Name"] + " </h5>" +
                                        "<p class='card-text'>Precio: <strong>$" + row["Price"] + "</strong> Stock: <strong>" + row["Quantity"] + " </strong></p>" +
                                        "<a href='addtocart.aspx?itemId=" + row["Id"] + "' class='btn btn-outline-dark mt-auto'> Añadir al carrito</a>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";
            }

            ProductsLiteral.Text = template;

        }
    }
}