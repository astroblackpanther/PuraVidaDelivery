using System;
namespace PuraVidaDelivery.Models
{
    public class Entregas
    {
        public int EntregasId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
    }
}

