using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoJade
{
    public class usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }
        public string Admin { get; set; }
    }
}