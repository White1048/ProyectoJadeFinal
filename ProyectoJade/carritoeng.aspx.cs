using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ProyectoJade
{
    public partial class carritoeng : System.Web.UI.Page
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
            if (TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" && TextBox5.Text != "")
            {
                string total2 = Total.Text;
                string dep = Product.Text;
                string ciudad = TextBox2.Text;
                string ncasa = TextBox3.Text;
                string pref = TextBox4.Text;
                string ncont = TextBox5.Text;
                int checkedOut = metodos.Check_Out(userId, dep, ciudad, ncasa, pref, ncont);



                if (checkedOut != 0)
                {
                    alerta.Text = "<script>Swal.fire('Successful purchase!', 'Thanks for choosing us!', 'success'); </script>";

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
                    const string subject = "Thanks for your purchase";//Asunto del correo
                    string body = "Dear " + nombrecliente + ", thank you for preferring and trusting us. It is a pleasure for us that you are our client. In this email we send you the total to pay for your purchase, which is: " + total2 + ", the deposit must be made to the bank account 00190020961243758952, when making the payment send the receipt by this means or to our number +503 71289089 Please, the process must be done in less than 5 days or your purchase will be cancelled, thank you very much for choosing us.";
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
                    alerta.Text = "<script>Swal.fire('There was a problem!', 'Product could not be purchased!', 'error'); </script>";

            }
        }
    }
}