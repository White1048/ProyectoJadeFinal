using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoJade
{
    public partial class camisas_h_eng : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                bool logged_in = Convert.ToBoolean(Session["logged_in"]);


                if (!logged_in)
                    Response.Redirect("Login-en.aspx");

            }
            catch (Exception ex)
            {
                Response.Redirect("Login-en.aspx");
            }
            bool addedToCart;
            if (!string.IsNullOrEmpty(Session["addedToCart"].ToString()) && bool.TryParse(Session["addedToCart"].ToString(), out addedToCart))
                if (addedToCart)
                    alerta.Text = "<script>Swal.fire('Added product!', 'Thanks for preferring us!'); </script>";
            Session["addedToCart"] = false;
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
                                        "<h5 class='card-title' class='text-center'>" + row["Nameeng"] + " </h5>" +
                                        "<p class='card-text'>Precio: <strong>$" + row["Price"] + "</strong> Stock: <strong>" + row["Quantity"] + " </strong></p>" +
                                        "<a href='addtocarteng.aspx?itemId=" + row["Id"] + "' class='btn btn-outline-dark mt-auto'> Add to cart</a>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";
            }

            ProductsLiteral.Text = template;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("logout-n.aspx");
        }
    }
}