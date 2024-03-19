using System;
namespace PuraVidaDelivery.Models
{
    public class OrdenesComprasDetalles
    {
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}

