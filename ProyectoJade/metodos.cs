using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Data;
using System.Transactions;
using System.IO;
using System.Diagnostics;

namespace ProyectoJade
{
    public class metodos
    {
        public static MySqlConnection conexion = new MySqlConnection("Server= 127.0.0.1; database=jadeptc; Uid=root; pwd=;");
        public const string CartSessionKey = "CartId";


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
        public const string initVector = "Jade$#j1032@jade";
        // This constant is used to determine the keysize of the encryption algorithm
        public const int keysize = 256;
        //Encrypt
        public static string EncryptString(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        //Hacer hash de un texto;
        public static string Hash_SHA256(string text)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(text));
                foreach (Byte b in result)
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }


        public static int login(string username, string password)
        {
            conexion.Open();
            int retorno = 0;
            string hashedPassword = EncryptString(password, initVector);
            string cmd = String.Format("SELECT Id FROM usuarios WHERE Username = '{0}' AND Password = '{1}'", username, hashedPassword);

            MySqlCommand comando = new MySqlCommand(cmd, conexion);
            if (comando.ExecuteScalar() == null)
            {
                retorno = 0;
            }
            else
                retorno = (int)comando.ExecuteScalar();

            conexion.Close();
            return retorno;
        }

        public static int Sign_Up(string username, string password, string confirmPassword, string correo, string nombre, string apellido)
        {
            int retorno = 0;
            int valor = 0;
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand(String.Format("SELECT Id FROM usuarios WHERE Username = '{0}';", username), conexion); //Realizamos una selecion de la tabla usuarios.
            //valor =  Convert.ToInt32(cmd.ExecuteScalar()) ?? 0;
            if (cmd.ExecuteScalar() == null)
            {
                valor = 0;
            }
            else
            {
                valor = (int)cmd.ExecuteScalar();
            }

            if (valor == 0)
            {
                if (password == confirmPassword)
                {
                    string hashedPassword = EncryptString(password, initVector);
                    MySqlCommand comando = new MySqlCommand(String.Format("INSERT INTO usuarios (Nombre, Apellido, Correo, Username, Password, Admin) VALUES ('{2}', '{0}','{1}', '{3}', '{4}', FALSE)", nombre, apellido, correo, username, hashedPassword), conexion);
                    retorno = comando.ExecuteNonQuery();
                }

            }
            conexion.Close();
            return retorno;
        }

        public static int Check_Admin(int id)
        {
            conexion.Open();
            int userType = 0;
            MySqlCommand cmd = new MySqlCommand(String.Format("SELECT Admin FROM usuarios WHERE Id = {0};", id), conexion); //Realizamos una selecion de la tabla usuarios.

            if (cmd.ExecuteScalar() == null)
            {
                userType = 0;
            }
            else
                userType = Convert.ToInt32(cmd.ExecuteScalar());
            conexion.Close();
            return userType;
        }

        public static int Check_Admin(string username)
        {
            conexion.Open();
            int userType = 0;
            MySqlCommand cmd = new MySqlCommand(String.Format("SELECT Admin FROM usuarios WHERE Username = '{0}';", username), conexion); //Realizamos una selecion de la tabla usuarios.

            if (cmd.ExecuteScalar() == null)
            {
                userType = 0;
            }
            else
                userType = Convert.ToInt32(cmd.ExecuteScalar());

            conexion.Close();
            return userType;
        }
        //------------------------------------ PRODUCTS ------------------------------------//
        public static int Add_Product(string product, double price, int quantity, string image, string tipo, string desproduct, int S, int M, int L, int XL)
        {
            conexion.Open();
           
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand("INSERT INTO productos (Name, Price, Quantity, Image, id_categ, descripcion, S, M, L, XL ) VALUES (@product, @price, @quantity, @image, @tipo, @desproduct, @talla_s, @talla_m, @talla_l, @talla_xl);", conexion);
            comando.Parameters.AddWithValue("@product", product);
            comando.Parameters.AddWithValue("@price", price);
            comando.Parameters.AddWithValue("@quantity", quantity);
            comando.Parameters.AddWithValue("@desproduct", desproduct);
            comando.Parameters.AddWithValue("@image", image);
            comando.Parameters.AddWithValue("@tipo", tipo);
            comando.Parameters.AddWithValue("@talla_s", S);
            comando.Parameters.AddWithValue("@talla_m", M);
            comando.Parameters.AddWithValue("@talla_l", L);
            comando.Parameters.AddWithValue("@talla_xl", XL);
            comando.Prepare();
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
        public static int Add_Producteng(string product, double price, int quantity, string image, string tipo, string desproduct)
        {
            conexion.Open();
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand("INSERT INTO productoseng (Name, Price, Quantity, Image, id_categ, description ) VALUES (@product, @price, @quantity, @image, @tipo, @desproduct);", conexion);
            comando.Parameters.AddWithValue("@product", product);
            comando.Parameters.AddWithValue("@price", price);
            comando.Parameters.AddWithValue("@quantity", quantity);
            comando.Parameters.AddWithValue("@image", image);
            comando.Parameters.AddWithValue("@tipo", tipo);
            comando.Parameters.AddWithValue("@desproduct", desproduct);
            comando.Prepare();
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;
        }
        public static List<categorias> Combo()
        {
            List<categorias> _lista = new List<categorias>();
            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT id_categoria, nombre_categ FROM genero"), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                categorias pcategorias = new categorias();
                pcategorias.id_categoria = _reader.GetInt32(0);
                pcategorias.nombre_categ = _reader.GetString(1);
                _lista.Add(pcategorias);
            }
            return _lista;
        }
        public static usuarios Search_Usuarios(int id)
        {
            usuarios usuario = new usuarios();
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuarios WHERE Id = @id;", conexion);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario.Id = reader.GetInt32(0);
                usuario.Nombre = reader.GetString(1);
                usuario.Apellido = reader.GetString(2);
                usuario.Username = reader.GetString(3);
                usuario.Password = reader.GetString(4);
                usuario.Correo = reader.GetString(5);
                usuario.Admin = reader.GetString(6);

            }
            conexion.Close();
            return usuario;
        }
        public static Product Search_Product(int id)
        {
            Product product = new Product();
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM productos WHERE Id = @id;", conexion);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                product.Id = reader.GetInt32(0);
                product.Name = reader.GetString(1);
                product.descripcion = reader.GetString(2);
                product.Price = reader.GetDouble(3);
                product.Quantity = reader.GetInt32(4);
                product.Image = reader.GetString(5);
                product.tipo = reader.GetString(6);
            }
            conexion.Close();
            return product;
        }
        public static DataTable Fetch_Productseng(bool imgElement)
        {
            MySqlDataAdapter DA = new MySqlDataAdapter();
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM productoseng Where Quantity>0", conexion);
            DA.SelectCommand = cmd;
            DataTable DT = new DataTable();

            DA.Fill(DT);

            if (imgElement)
            {
                foreach (DataRow row in DT.Rows)
                {
                    row["Image"] = "<img width='100px' class='thumbnail' src='./images/" + row["Image"] + "' />";
                }
            }
            conexion.Close();
            return DT;
        }
        public static DataTable Fetch_Products(bool imgElement)
        {
            MySqlDataAdapter DA = new MySqlDataAdapter();
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM productos Where Quantity  > 0;", conexion);
            DA.SelectCommand = cmd;
            DataTable DT = new DataTable();

            DA.Fill(DT);

            if (imgElement)
            {
                foreach (DataRow row in DT.Rows)
                {
                    row["Image"] = "<img width='100px' class='thumbnail' src='./images/" + row["Image"] + "' />";
                }
            }
            conexion.Close();
            return DT;
        }
        public static DataTable Fetch_camisas_h(bool imgElement)
        {
            MySqlDataAdapter DA = new MySqlDataAdapter();
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM productos Where id_categ = 1 AND Quantity > 0", conexion);
            DA.SelectCommand = cmd;
            DataTable DT = new DataTable();
            DA.Fill(DT);

            if (imgElement)
            {
                foreach (DataRow row in DT.Rows)
                {
                    row["Image"] = "<img width='100px' class='thumbnail' src='./images/" + row["Image"] + "' />";
                }
            }
            conexion.Close();
            return DT;
        }
        public static DataTable Fetch_camisas_m(bool imgElement)
        {
            conexion.Open();
            MySqlDataAdapter DA = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM productos where id_categ = 2 AND Quantity > 0", conexion);
            DA.SelectCommand = cmd;
            DataTable DT = new DataTable();

            DA.Fill(DT);

            if (imgElement)
            {
                foreach (DataRow row in DT.Rows)
                {
                    row["Image"] = "<img width='100px' class='thumbnail' src='./images/" + row["Image"] + "' />";
                }
            }
            conexion.Close();
            return DT;
        }
        public static DataTable Fetch_pantalones_h(bool imgElement)
        {
            conexion.Open();
            MySqlDataAdapter DA = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM productos where id_categ = 3 AND Quantity > 0", conexion);
            DA.SelectCommand = cmd;
            DataTable DT = new DataTable();

            DA.Fill(DT);

            if (imgElement)
            {
                foreach (DataRow row in DT.Rows)
                {
                    row["Image"] = "<img width='100px' class='thumbnail' src='./images/" + row["Image"] + "' />";
                }
            }
            conexion.Close();
            return DT;
        }
        public static DataTable Fetch_pantalones_m(bool imgElement)
        {
            conexion.Open();
            MySqlDataAdapter DA = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM productos where id_categ = 4 AND Quantity > 0", conexion);
            DA.SelectCommand = cmd;
            DataTable DT = new DataTable();

            DA.Fill(DT);

            if (imgElement)
            {
                foreach (DataRow row in DT.Rows)
                {
                    row["Image"] = "<img width='100px' class='thumbnail' src='./images/" + row["Image"] + "' />";
                }
            }
            conexion.Close();
            return DT;
        }
        public static DataTable Fetch_trajes(bool imgElement)
        {
            conexion.Open();
            MySqlDataAdapter DA = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM productos where id_categ = 5 AND Quantity > 0", conexion);
            DA.SelectCommand = cmd;
            DataTable DT = new DataTable();

            DA.Fill(DT);

            if (imgElement)
            {
                foreach (DataRow row in DT.Rows)
                {
                    row["Image"] = "<img width='100px' class='thumbnail' src='./images/" + row["Image"] + "' />";
                }
            }
            conexion.Close();
            return DT;
        }
        public static DataTable Fetch_vestidos(bool imgElement)
        {
            conexion.Open();
            MySqlDataAdapter DA = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM productos where id_categ = 6 AND Quantity > 0", conexion);
            DA.SelectCommand = cmd;
            DataTable DT = new DataTable();

            DA.Fill(DT);

            if (imgElement)
            {
                foreach (DataRow row in DT.Rows)
                {
                    row["Image"] = "<img width='100px' class='thumbnail' src='./images/" + row["Image"] + "' />";
                }
            }
            conexion.Close();
            return DT;
        }
        public static DataTable Fetch_zapatos_h(bool imgElement)
        {
            conexion.Open();
            MySqlDataAdapter DA = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM productos where id_categ = 7 AND Quantity > 0", conexion);
            DA.SelectCommand = cmd;
            DataTable DT = new DataTable();

            DA.Fill(DT);

            if (imgElement)
            {
                foreach (DataRow row in DT.Rows)
                {
                    row["Image"] = "<img width='100px' class='thumbnail' src='./images/" + row["Image"] + "' />";
                }
            }
            conexion.Close();
            return DT;
        }
        public static DataTable Fetch_zapatos_m(bool imgElement)
        {
            conexion.Open();
            MySqlDataAdapter DA = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM productos where id_categ = 8 AND Quantity > 0", conexion);
            DA.SelectCommand = cmd;
            DataTable DT = new DataTable();

            DA.Fill(DT);

            if (imgElement)
            {
                foreach (DataRow row in DT.Rows)
                {
                    row["Image"] = "<img width='100px' class='thumbnail' src='./images/" + row["Image"] + "' />";
                }
            }
            conexion.Close();
            return DT;
        }
        public static DataTable Fetch_accesorios_h(bool imgElement)
        {
            conexion.Open();
            MySqlDataAdapter DA = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM productos where id_categ = 9 AND Quantity > 0", conexion);
            DA.SelectCommand = cmd;
            DataTable DT = new DataTable();

            DA.Fill(DT);

            if (imgElement)
            {
                foreach (DataRow row in DT.Rows)
                {
                    row["Image"] = "<img width='100px' class='thumbnail' src='./images/" + row["Image"] + "' />";
                }
            }
            conexion.Close();
            return DT;
        }
        public static DataTable Fetch_accesorios_m(bool imgElement)
        {
            conexion.Open();
            MySqlDataAdapter DA = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM productos where id_categ = 10 AND Quantity > 0", conexion);
            DA.SelectCommand = cmd;
            DataTable DT = new DataTable();

            DA.Fill(DT);

            if (imgElement)
            {
                foreach (DataRow row in DT.Rows)
                {
                    row["Image"] = "<img width='100px' class='thumbnail' src='./images/" + row["Image"] + "' />";
                }
            }
            conexion.Close();
            return DT;
        }
        public static DataTable Fetch_Usuarios(bool imgElement)
        {
            MySqlDataAdapter DA = new MySqlDataAdapter();
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuarios;", conexion);
            DA.SelectCommand = cmd;
            DataTable DT = new DataTable();

            DA.Fill(DT);



            conexion.Close();
            return DT;
        }
        public static int Update_Product(int id, string producto, double price, int quantity, int tipo)
        {
            conexion.Open();
            int retorno = 0;
            string query = "UPDATE productos SET ";
            query += "Name = @name, ";
            query += "Price = @price, ";
            query += "Quantity = @quantity ";
            query += "id_categ = @tipo ";
            query += "WHERE Id = @id;";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@name", producto);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@tipo", tipo);
            retorno = cmd.ExecuteNonQuery();

            conexion.Close();
            return retorno;
        }
        public static int Update_Product(int id, string producto, double price, int quantity, string image, int tipo)
        {
            conexion.Open();
            int retorno = 0;
            string query = "UPDATE productos SET ";
            query += "Name = @name, ";
            query += "Price = @price, ";
            query += "Quantity = @quantity, ";
            query += "Image = @image ";
            query += "id_categ = @tipo ";
            query += "WHERE Id = @id;";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@name", producto);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@image", image);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@tipo", tipo);
            retorno = cmd.ExecuteNonQuery();

            conexion.Close();
            return retorno;
        }

        public static int Delete_Product(int id)
        {
            int retorno = 0;
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM productos WHERE Id = @id", conexion);
            cmd.Parameters.AddWithValue("@id", id);
            retorno = cmd.ExecuteNonQuery();

            conexion.Close();
            return retorno;
        }
        public static int Delete_Usuarios(int id)
        {
            int retorno = 0;
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM usuarios WHERE Id = @id", conexion);
            cmd.Parameters.AddWithValue("@id", id);
            retorno = cmd.ExecuteNonQuery();

            conexion.Close();
            return retorno;
        }

        //------------------------------------ END OF PRODUCTS ------------------------------------//

        // SHOPPING CART
        public static string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public static void SetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name.ToString();
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
        }

        public static int AddToCart(int productId, string cartId, int userId)
        {
            int retorno = 0;
            conexion.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM cart WHERE ProductID = @prodId AND UserID = @userId;", conexion);
            cmd.Parameters.AddWithValue("@prodId", productId);
            cmd.Parameters.AddWithValue("@userId", userId);
            //cmd.Parameters.AddWithValue("@cartId", cartId);
            cmd.Prepare();

            if (cmd.ExecuteScalar() == null)
            {
                MySqlCommand insertCmd = new MySqlCommand("INSERT INTO cart (ProductId, UserId, Quantity, UnitPrice, CartId) VALUES ( @prodId, @userId, 1, (SELECT Price FROM productos  WHERE Id = @prodId), @cartId);", conexion);
                insertCmd.Parameters.AddWithValue("@prodId", productId);
                insertCmd.Parameters.AddWithValue("@userId", userId);
                insertCmd.Parameters.AddWithValue("@cartId", cartId);
                insertCmd.Prepare();

                retorno = insertCmd.ExecuteNonQuery();

            }
            else
            {
                MySqlCommand updateCmd = new MySqlCommand("UPDATE cart SET Quantity = Quantity + 1 WHERE ProductID = @prodId AND UserID = @userId", conexion);
                updateCmd.Parameters.AddWithValue("@prodId", productId);
                updateCmd.Parameters.AddWithValue("@userId", userId);
                //updateCmd.Parameters.AddWithValue("@cartId", cartId);
                updateCmd.Prepare();

                retorno = updateCmd.ExecuteNonQuery();
            }
            conexion.Close();
            return retorno;
        }
        public static DataTable Fetch_Cart(int userId)
        {
            try
            {
                conexion.Open();
            }
            catch (Exception e)
            {

            }

            MySqlDataAdapter DA = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT cart.*, productos.Name, productos.Image FROM cart INNER JOIN productos ON cart.ProductID = productos.Id WHERE userID = @userId;", conexion);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Prepare();
            DA.SelectCommand = cmd;
            DataTable DT = new DataTable();

            DA.Fill(DT);


            foreach (DataRow row in DT.Rows)
            {
                row["Image"] = "<img width='100px' class='thumbnail' src='./images/" + row["Image"] + "' />";
            }

            conexion.Close();
            return DT;
        }

        public static int Delete_From_Cart(int productId, int userId)
        {
            int retorno = 0;
            conexion.Open();

            MySqlCommand cmd = new MySqlCommand("DELETE FROM cart WHERE ProductID = @productID AND @userId;", conexion);
            cmd.Parameters.AddWithValue("@productId", productId);
            cmd.Parameters.AddWithValue("@userId", userId);

            retorno = cmd.ExecuteNonQuery();

            conexion.Close();
            return retorno;
        }

        public static double Cart_Total(int userId)
        {
            conexion.Open();
            double total = 0;
            MySqlCommand cmd = new MySqlCommand("SELECT SUM(cart.quantity * cart.UnitPrice) FROM cart WHERE UserId = @userid ", conexion);
            cmd.Parameters.AddWithValue("@userid", userId);
            cmd.Prepare();
            if (!double.TryParse(cmd.ExecuteScalar().ToString(), out total))
            {
                conexion.Close();
                return 0;
            }
            conexion.Close();
            return total;
        }
        public static int Check_Out(int userId, string dep, string ciudad, string ncasa, string pref, string ncont)
        {

            conexion.Open();
            int retorno = 1;

            string strFileName;
            string strFilePath;
            string strFolder;

            List<CartItem> items = new List<CartItem>();
            Guid QRText = Guid.NewGuid();

            MySqlCommand readCmd = new MySqlCommand("SELECT * FROM cart WHERE UserId = @userId", conexion);
            readCmd.Parameters.AddWithValue("@userId", userId);

            MySqlDataReader reader = readCmd.ExecuteReader();
            double totalPurchase = 0;
            if (!reader.HasRows)
            {
                conexion.Close();
                return 0;
            }
            int purchasedItems = 0;
            while (reader.Read())
            {
                CartItem item = new CartItem();
                item.ItemId = reader.GetInt32(0);
                item.ProductID = reader.GetInt32(1);
                item.UserId = reader.GetInt32(2);
                item.Quantity = reader.GetInt32(3);
                item.UnitPrice = reader.GetDouble(4);
                item.CartId = reader.GetString(5);

                totalPurchase += item.UnitPrice * item.Quantity;
                purchasedItems += item.Quantity;

                items.Add(item);
            }
            conexion.Close();


            try
            {

                //Generar la venta y actualizar productos;
                using (TransactionScope scope = new TransactionScope())
                {
                    conexion.Open();
                    //Insertar Venta
                    MySqlCommand saleCmd = new MySqlCommand("INSERT INTO sales (UserId, Total, Items, Date, dep, ciudad, ncasa, preferencia, ncontacto) VALUES (@userId, @total, @items, NOW(), @dep, @ciudad, @casa, @pref, @cont );", conexion);
                    saleCmd.Parameters.AddWithValue("@userId", userId);
                    saleCmd.Parameters.AddWithValue("@total", totalPurchase);
                    saleCmd.Parameters.AddWithValue("@items", purchasedItems);
                    saleCmd.Parameters.AddWithValue("@dep", dep);
                    saleCmd.Parameters.AddWithValue("@ciudad", ciudad);
                    saleCmd.Parameters.AddWithValue("@casa", ncasa);
                    saleCmd.Parameters.AddWithValue("@pref", pref);
                    saleCmd.Parameters.AddWithValue("@cont", ncont);

                    int guardado = (int)saleCmd.ExecuteNonQuery();
                    if (guardado != 0)
                    {

                        int saleID = Convert.ToInt32(saleCmd.LastInsertedId);

                        //Insertar los detalles de la venta de cada producto y actualizar el inventario
                        MySqlCommand checkInventory = new MySqlCommand("SELECT Quantity FROM productos WHERE Id = @itemId;", conexion);
                        checkInventory.Parameters.AddWithValue("@itemId", 0);

                        MySqlCommand insertSalesDetails = new MySqlCommand("INSERT INTO sales_details (SalesId, ItemId, Quantity, UnitPrice, TotalPrice) " +
                        "VALUES (@salesID, @itemId, @qty, @unitPrice, @totalPrice);", conexion);

                        MySqlCommand updateInventory = new MySqlCommand("UPDATE productos SET Quantity = (Quantity - @itemsSold) WHERE Id = @itemId;", conexion);

                        MySqlCommand deleteCartItem = new MySqlCommand("DELETE FROM cart WHERE Id = @entryId;", conexion);
                        deleteCartItem.Parameters.AddWithValue("@entryId", 0);

                        updateInventory.Parameters.AddWithValue("@itemsSold", 0);
                        updateInventory.Parameters.AddWithValue("@itemId", 0);
                        insertSalesDetails.Parameters.AddWithValue("@salesId", 0);
                        insertSalesDetails.Parameters.AddWithValue("@itemId", 0);
                        insertSalesDetails.Parameters.AddWithValue("@qty", 0);
                        insertSalesDetails.Parameters.AddWithValue("@unitPrice", 0.0);
                        insertSalesDetails.Parameters.AddWithValue("@totalPrice", 0.0);

                        checkInventory.Prepare();
                        updateInventory.Prepare();
                        insertSalesDetails.Prepare();
                        deleteCartItem.Prepare();

                        int currentInventory = 0;
                        int newInventory = 0;
                        object inventoryObject;
                        int detailAdded = 0;
                        foreach (CartItem item in items)
                        {
                            //Verificar que haya suficientes existencia del item
                            checkInventory.Parameters[0].Value = item.ProductID;
                            inventoryObject = checkInventory.ExecuteScalar();
                            if (inventoryObject.Equals(DBNull.Value))
                            {
                                conexion.Close();
                                return 0;
                            }

                            currentInventory = Convert.ToInt32(inventoryObject);
                            newInventory = currentInventory - item.Quantity;

                            if (newInventory < 0)
                            {
                                conexion.Close();
                                return 0;
                            }

                            //Insertar en la tabla de detalles de ventas 
                            insertSalesDetails.Parameters[0].Value = saleID;
                            insertSalesDetails.Parameters[1].Value = item.ProductID;
                            insertSalesDetails.Parameters[2].Value = item.Quantity;
                            insertSalesDetails.Parameters[3].Value = item.UnitPrice;
                            insertSalesDetails.Parameters[4].Value = item.UnitPrice * item.Quantity;

                            detailAdded = insertSalesDetails.ExecuteNonQuery();

                            if (detailAdded != 1)
                            {
                                conexion.Close();
                                return 0;
                            }


                            //Actualizar las existencias del producto
                            updateInventory.Parameters[0].Value = item.Quantity;
                            updateInventory.Parameters[1].Value = item.ProductID;

                            if (updateInventory.ExecuteNonQuery() != 1)
                            {
                                conexion.Close();
                                return 0;
                            }


                            deleteCartItem.Parameters[0].Value = item.ItemId;

                            if (deleteCartItem.ExecuteNonQuery() != 1)
                            {
                                conexion.Close();
                                return 0;
                            }

                        }
                        retorno = 1;
                        scope.Complete();
                    }
                    else
                    {
                        return 0;
                    }

                }

            }
            catch (Exception e)
            {
                conexion.Close();
                retorno = 0;
                Debug.Fail(e.Message);
                throw e;
            }

            conexion.Close();
            return retorno;
        }
        public static DataTable Get_Sales()
        {
            conexion.Open();
            MySqlDataAdapter DA = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT sales_details.Id, sales_details.SalesId as 'Id Venta', productos.Name as 'Producto', sales_details.Quantity as 'Cantidad', sales_details.UnitPrice as 'Precio Unidad', " +
            "sales_details.TotalPrice as 'Total',  DATE_FORMAT(sales.Date, '%d/%c/%Y') as 'Fecha', usuarios.Username as 'Comprador', sales.dep as 'departamento', sales.ciudad as 'ciudad', sales.ncasa as 'detalles de vivienda', sales.ncontacto as 'contacto', sales.preferencia as 'punto de referencia' FROM sales_details " +
            "INNER JOIN productos ON sales_details.ItemId = productos.Id INNER JOIN sales ON sales.Id = sales_details.SalesId INNER JOIN usuarios ON sales.UserId = usuarios.Id ORDER BY sales_details.SalesId; ", conexion);
            DA.SelectCommand = cmd;
            DataTable DT = new DataTable();

            DA.Fill(DT);

            conexion.Close();
            return DT;
        }

    }
}