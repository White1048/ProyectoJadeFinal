using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.IO;
namespace ProyectoJade
{
    public partial class carrito : System.Web.UI.Page
    {
        private int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                bool logged_in = Convert.ToBoolean(Session["logged_in"]);
                if (!logged_in)
                {
                    Response.Redirect("login.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("login.aspx");
            }

            if (int.TryParse(HttpContext.Current.Session["userID"].ToString(), out userId))
            {
                Load_Cart(userId);
                Load_Total(userId);
            }
        }

        protected void Load_Cart(int userId)
        {

            DataTable myTable = metodos.Fetch_Cart(userId);
            ShoppingCart.DataSource = myTable;
            ShoppingCart.DataBind();
        }
        protected void Load_Total(int userId)
        {
            double total = metodos.Cart_Total(userId);
            Total.Text = "Total: $" + Math.Round(total, 2).ToString();
        }
        protected void CheckOut_Click(object sender, EventArgs e)
        {
            string total2 = Total.Text;
            if (TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" && TextBox5.Text != "")
            {
                string dep = Product.Text;
                string ciudad = TextBox2.Text;
                string ncasa = TextBox3.Text;
                string pref = TextBox4.Text;
                string ncont = TextBox5.Text;
                int checkedOut = metodos.Check_Out(userId, dep, ciudad, ncasa, pref, ncont);

                if (checkedOut != 0)
                {
                    alerta.Text = "<script>Swal.fire('Compra realizada con exito!', 'Gracias por preferirnos!', 'success'); </script>";

                    string user = HttpContext.Current.Session["Username"].ToString();
                    MySqlConnection conexion = new MySqlConnection("Server=127.0.0.1; database=jadeptc; Uid=root; pwd=;");
                    var cmd1 = "Select Correo from usuarios where Username ='" + user + "';";
                    var cmd2 = "Select Nombre from usuarios where Username ='" + user + "';";
                    


                    MySqlCommand obtenerCorreo = new MySqlCommand(cmd1, conexion);
                    obtenerCorreo.Parameters.Add("@Name", MySqlDbType.VarChar);
                    MySqlCommand obtenerNombre = new MySqlCommand(cmd2, conexion);

                    string mail;
                    string nombrecliente;
                    conexion.Open();
                    mail = (string)obtenerCorreo.ExecuteScalar();
                    nombrecliente = (string)obtenerNombre.ExecuteScalar();

                    string correo = mail;// cambiar por correo del usuario que realiza la compra
                    string nombre = "WineSV";

                    var fromAddress = new MailAddress("jadeequipo@gmail.com", "Jade");
                    const string fromPassword = "crqghvmfmaywuokz";
                    var toAddress = new MailAddress(correo, nombre);//Dirección de correo y nombre que se muestra				
                    const string subject = "Gracias por su compra";//Asunto del correo
                    string body = "Estimado " + nombrecliente + ", gracias por preferirnos y confiar en nosotros. Es un placer para nosotros que sea nuestro cliente. En el presente correo le enviamos el total a pagar de su compra, que es: " + total2 + ", el deposito debe ser realizado a la cuenta bancaria 00190020961243758952, al realizar el pago enviar el comprobante por este medio o a nuestro numero +503 71289089, por favor el tramite debe ser realizado en lapso menor a 5 dias o su compra sera cancelada, muchas gracias por preferirnos.";
                    //Fin de datos del envío


                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);//Enviar el correo
                    }
                    
                   
              
                }
                else
                    
                    alerta.Text = "<script>Swal.fire('Hubo un problema!', 'No se pudo comprar producto!', 'Error'); </script>";




            }
            else
                alerta.Text = "<script>Swal.fire('Ay!', 'No deje espacios en blanco', 'error') </script>";




        }

        protected void ShoppingCart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
