using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoJade
{
    public partial class deletefromcart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            string rawId = Request.QueryString["productId"];
            int productId;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))
            {
                int userId = (int)HttpContext.Current.Session["userID"];
                int deleted = metodos.Delete_From_Cart(productId, userId);

                if (deleted != 0)
                {
                    Response.Redirect("carrito.aspx");

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No fue posible eliminar el producto del carrito');", true);
                }
            }
            else
            {
                Debug.Fail("ERROR : We should never get to deletefromcart.aspx without a ProductId.");
                throw new Exception("ERROR : It is illegal to load AddToCart.aspx without setting a ProductId.");
            }
            Response.Redirect("carrito.aspx");
        }
    }
}