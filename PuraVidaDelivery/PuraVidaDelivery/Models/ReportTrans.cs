using System;
namespace PuraVidaDelivery.Models
{
    public class ReportesTransacciones
    {
        public int ReporteId { get; set; }
        public int ClienteId { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public int ProveedorId { get; set; }
        public DateTime FechaReporte { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}

