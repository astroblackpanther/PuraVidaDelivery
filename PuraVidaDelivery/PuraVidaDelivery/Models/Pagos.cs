using System;
namespace PuraVidaDelivery.Models
{
    public class Pagos
    {
        public int PagosId { get; set; }
        public int ClienteId { get; set; }
        public string TipoPago { get; set; }
        public long NumeroTarjeta { get; set; }
        public string VencimientoTarjeta { get; set; }
        public int CodigoTarjeta { get; set; }
    }
}

