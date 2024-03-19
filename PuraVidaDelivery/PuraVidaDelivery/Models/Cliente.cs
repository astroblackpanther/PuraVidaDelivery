using System;
namespace PuraVidaDelivery.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public string Apellido1Cliente { get; set; }
        public string Apellido2Cliente { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string CorreoCliente { get; set; }
    }
}

