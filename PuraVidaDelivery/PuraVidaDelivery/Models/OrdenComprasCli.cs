using System;
namespace PuraVidaDelivery.Models
{
    public class OrdenesComprasClientes
    {
        public int OrdenId { get; set; }
        public int ClienteId { get; set; }
        public int ProveedorId { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}

