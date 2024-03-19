using System;
namespace PuraVidaDelivery.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
        public int ProveedorId { get; set; }
        public string NombreProducto { get; set; }
        public int Stock { get; set; }
        public string RutaImagen { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}

