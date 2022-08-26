using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ProyectoJade
{
    public partial class camisa_h_es_s : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_Products();
        }
        protected void Load_Products()
        {
            string template = "";

            DataTable products = metodos.Fetch_camisas_h(false);

            foreach (DataRow row in products.Rows)
            {
                template += "<div class='col-sm-12 col-md-3 col-lg-3'> " +
                                "<div class='card h-100'> " +
                                    "<img src='images/" + row["Image"] + "' class='card-img-top'/>" +
                                    "<div class='card-body p-4'> " +
                                        "<h5 class='card-title' class='text-center'>" + row["Name"] + " </h5>" +
                                        "<p class='card-text'>Precio: <strong>$" + row["Price"] + "</strong> Stock: <strong>" + row["Quantity"] + " </strong></p>" +
                                        "<a href='Login.aspx?itemId=" + row["Id"] + "' class='btn btn-outline-dark mt-auto'> Añadir al carrito</a>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";
            }

            ProductsLiteral.Text = template;

        }
    }

}