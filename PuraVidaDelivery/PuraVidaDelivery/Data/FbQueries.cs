using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PuraVidaDelivery.Models;

namespace PuraVidaDelivery.Data
{
    public class FbQueries
    {
        private static string FbInstance = "https://sistema-de-pedidos-5115c-default-rtdb.firebaseio.com/";
        private static string FbSecret = "a5cd929524137afdb4dd0d0aebb00f17d9b0f2ac";
        private static FirebaseOptions FbOptions = new FirebaseOptions() { AuthTokenAsyncFactory = () => Task.FromResult(FbSecret) };
        private static FirebaseClient FbClient = new FirebaseClient(FbInstance, FbOptions);

        public static async Task<List<Categoria>> GetAllCategorias()
        {
            var categorias = await FbClient.Child("categorias").OnceAsync<Categoria>();
            var result = new List<Categoria>();
            foreach (var categoria in categorias)
            {
                result.Add(categoria.Object);
            }
            return result;
        }

        public static async Task<string> AddUsuario(Usuario usuario)
        {
            var result = await FbClient.Child("usuarios").PostAsync(usuario);
            return result.Key;
        }

        public static async Task<string> AddProveedor(Proveedor proveedor)
        {
            var result = await FbClient.Child("proveedores").PostAsync(proveedor);
            return result.Key;
        }

        public static async Task<string> AddHistorialVenta(HistorialVentas venta)
        {
            var result = await FbClient.Child("historialVentas").PostAsync(venta);
            return result.Key;
        }

        public static async Task<HistorialVentas> GetHistorialVenta(int historialId)
        {
            return await FbClient.Child("historialVentas").Child(historialId.ToString()).OnceSingleAsync<HistorialVentas>();
        }

        public static async Task UpdateHistorialVenta(int historialId, HistorialVentas venta)
        {
            await FbClient.Child("historialVentas").Child(historialId.ToString()).PutAsync(venta);
        }

        public static async Task DeleteHistorialVenta(int historialId)
        {
            await FbClient.Child("historialVentas").Child(historialId.ToString()).DeleteAsync();
        }

        // CRUD methods for historialVentasDetalles
        public static async Task<string> AddHistorialVentaDetalle(HistorialVentasDetalles detalle)
        {
            var result = await FbClient.Child("historialVentasDetalles").PostAsync(detalle);
            return result.Key;
        }

        public static async Task<HistorialVentasDetalles> GetHistorialVentaDetalle(int historialId, int productoId)
        {
            return await FbClient.Child("historialVentasDetalles").Child($"{historialId}_{productoId}").OnceSingleAsync<HistorialVentasDetalles>();
        }

        public static async Task UpdateHistorialVentaDetalle(int historialId, int productoId, HistorialVentasDetalles detalle)
        {
            await FbClient.Child("historialVentasDetalles").Child($"{historialId}_{productoId}").PutAsync(detalle);
        }

        public static async Task DeleteHistorialVentaDetalle(int historialId, int productoId)
        {
            await FbClient.Child("historialVentasDetalles").Child($"{historialId}_{productoId}").DeleteAsync();
        }
    }
}
