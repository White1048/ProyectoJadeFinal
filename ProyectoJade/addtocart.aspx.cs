using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoJade
{
    public partial class addtocart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string rawId = Request.QueryString["itemId"];
            int productId;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))
            {

                string CartId = metodos.GetCartId();
                int userId = (int)HttpContext.Current.Session["userID"];

                int agregado = metodos.AddToCart(productId, CartId, userId);

                if (agregado == 1)
                {
                    Session["addedToCart"] = true;
                    Response.Redirect("Inicio.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No fue posible agregar el producto al carrito');", true);
                }
            }
            else
            {
                Debug.Fail("ERROR : We should never get to AddToCart.aspx without a ProductId.");
                throw new Exception("ERROR : It is illegal to load AddToCart.aspx without setting a ProductId.");
            }
            Response.Redirect("Inicio.aspx");

        }
    }
}