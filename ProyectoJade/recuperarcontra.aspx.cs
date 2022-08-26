using System;
using System.Collections.Generic;
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
    public partial class recuperarcontra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (txtcuenta.Text != "")
            {
                try
                {

                    string user = txtcuenta.Text;
                    MySqlConnection conexion = new MySqlConnection("Server=127.0.0.1; database=jadeptc; Uid=root; pwd=;");
                    var cmd = "Select Password from usuarios where Username='" + user + "';";
                    var cmd1 = "Select Correo from usuarios where Username ='" + user + "';";
                    var cmd2 = "Select Nombre from usuarios where Username ='" + user + "';";


                    MySqlCommand obtenerContra = new MySqlCommand(cmd, conexion);
                    obtenerContra.Parameters.Add("@Name", MySqlDbType.VarChar);
                    MySqlCommand obtenerCorreo = new MySqlCommand(cmd1, conexion);
                    obtenerCorreo.Parameters.Add("@Name", MySqlDbType.VarChar);
                    MySqlCommand obtenerNombre = new MySqlCommand(cmd2, conexion);

                    string mail;
                    string contra;
                    string nombrecliente;
                    string contraDesencriptada;
                    conexion.Open();
                    mail = (string)obtenerCorreo.ExecuteScalar();
                    contra = (string)obtenerContra.ExecuteScalar();
                    nombrecliente = (string)obtenerNombre.ExecuteScalar();
                    contraDesencriptada = DecryptString(contra, initVector);

                    string correo = mail;// cambiar por correo del usuario que realiza la compra
                    string nombre = "WineSV";

                    var fromAddress = new MailAddress("jadeequipo@gmail.com", "WineSV");
                    const string fromPassword = "crqghvmfmaywuokz";
                    var toAddress = new MailAddress(correo, nombre);//Dirección de correo y nombre que se muestra				
                    const string subject = "Recuperar contraseña";//Asunto del correo
                    string body = "Estimado " + nombrecliente + ", gracias por preferirnos y confiar en nosotros. Es un placer para nosotros que sea nuestro cliente, y no queremos que sufra inconvenientes. En el presente correo le enviamos la contraseña que solicitó. Muchas gracias por ser nuestro cliente. Contraseña: " + contraDesencriptada + "";
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

                alertas.Text = "<script>Swal.fire('El correo enviado con éxito', 'Contraseña recuperada', 'success');</script>";
            }
                        catch
            {
                alertas.Text = "<script>Swal.fire('Algo salió mal', 'Revisa tu usuario.', 'error');</script>";
            }
        }
                else
                {
                    alertas.Text = "<script>Swal.fire('Error', 'No deje espacios en blanco.', 'error');</script>";
                }
}
        private const string initVector = "SHA256";
        // This constant is used to determine the keysize of the encryption algorithm
        private const int keysize = 256;

        public static string DecryptString(string cipherText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

    }
}