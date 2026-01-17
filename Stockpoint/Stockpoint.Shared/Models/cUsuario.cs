// En AppStockul.Shared.Models
using Stockpoint.Shared.Pages;
using System.Text.Json.Serialization;

namespace Stockpoint.Shared.Models
{
    public partial class vwtblCompraDetallada
    {
        public int idCompra { get; set; }
        public int idProveedor { get; set; }
        public string Proveedor { get; set; }
        public System.DateTime Fecha { get; set; }
        public Nullable<decimal> PrecioTotal { get; set; }
        public int idTipoPago { get; set; }
        public string TipoPago { get; set; }
        public string DiccionarioOriginal { get; set; }
        public string ProductosConCantidad { get; set; }
    }
    public class VentaResponse
    {
        public List<vwVenta> Ventas { get; set; }
        public List<cElemento> Elementos { get; set; }
        public List<vwtblCompraDetallada> Compra { get; set; }
        

    }
    public partial class vwVenta
    {
        public int idVenta { get; set; }
        public int idCliente { get; set; }
        public string Cliente { get; set; }
        public System.DateTime Fecha { get; set; }
        public double? Importe { get; set; }
        public string Nombre { get; set; }
        public double? Pago { get; set; }
        public string TipodePago { get; set; }
        public int IdTipoPago { get; set; }
        public double? Saldo { get; set; }
        public string Estatus { get; set; }
    }

    public class ProductoDTO
    {
        public double? PrecioPublico { get; set; }
        public string Productos { get; set; }
        public double? Precio { get; set; }
        public string Codigo { get; set; }
        public string Unidad { get; set; }
        public string Descripcion { get; set; }
        public int? PiezasXcaja { get; set; }
        public double? CostoXCaja { get; set; }  // Asegúrate que es string
        public int idUnidad { get; set; }
        public int? CantidadMinima { get; set; }
        public int? Existencia { get; set; }
        public int Id_Catalogo { get; set; }
        public string Expr1 { get; set; }
        public int? PiezasXPaquete { get; set; }
        public int idProducto { get; set; }
    }
    public partial class vwProducto
    {
        public string Productos { get; set; }
        public double? Precio { get; set; }
        public string Codigo { get; set; }
        public string Unidad { get; set; }
        public string Descripcion { get; set; }
        public int PiezasXcaja { get; set; }
        public double? CostoXCaja { get; set; }
        public Nullable<int> idUnidad { get; set; }
        public int CantidadMinima { get; set; }
        public int? Existencia { get; set; }
        public int idCategoria { get; set; }
        public int PiezasXPaquete { get; set; }
        public int idProducto { get; set; }
        public string Categoria { get; set; }
        public string Imagen { get; set; }
        public string Estatus { get; set; }
        public Nullable<int> idEstatus { get; set; }
        public int cantidad { get; set; }
    }
    public class cResul
    {
        [JsonPropertyName("idResultado")]
        public int idResultado { get; set; }

        [JsonPropertyName("idUsuario")]
        public int idUsuario { get; set; }

        [JsonPropertyName("modulo")]
        public string modulo { get; set; }

        [JsonPropertyName("metodos")]
        public string metodos { get; set; }

        [JsonPropertyName("Id_Catalogo")]
        public int Id_Catalogo { get; set; }
        
        // Asegúrate que coincida con el backend
        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("Estatus")]
        public string Estatus { get; set; }

        [JsonPropertyName("mensaje")]
        public string mensaje { get; set; }

        [JsonPropertyName("mensajeDeSistema")]
        public string mensajeDeSistema { get; set; } // Faltaba esta propiedad

        [JsonPropertyName("Token")]
        public string Token { get; set; }
        // ← Aplicas el convertidor aquí

        [JsonPropertyName("fecha")]
        public DateTime? fecha { get; set; }
        public int? Pagina { get; set; }
        public int? RegistrosPorPagina { get; set; }
       
    }

    public partial class tblProducto
    {

        
        public int idProducto { get; set; }
        public int idUnidad { get; set; }
        public int piezasXcaja { get; set; }
        public int piezasXpaquete { get; set; }
        public int cantidadMinima { get; set; }
        public int existencia { get; set; }
        public decimal costoXcaja { get; set; }
        public decimal PrecioPublico { get; set; }
        public string Producto { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
        public int codigoDeBarras { get; set; }

        
        
    }
    public class cElemento
    {
        public int id { get; set; }
        public string Catalogo { get; set; }
        public string Valor { get; set; }
        public string Texto { get; set; }

        public string idOrigen { get; set; }

        public string ValorDefault { get; set; }
        public List<cElemento> Elementos { get; set; }
        public List<cElemento> SubEelementos { get; set; }
        public List<tblCatalogo> catalogos { get; set; }
        public string Pantalla { get; set; }
        public string Token { get; set; }

        public cResul R { get; set; }
    }
    public class tblCatalogo{
        public int Id_Catalogo { get; set; }
        public Nullable<int> IdOrigen { get; set; }
        public int Orden { get; set; }
        public string Catalogo { get; set; }
        public string Valor { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> ValorDefault { get; set; }
    }
    public class MenuItem
    {
        public string Descripcion { get; set; }
        public int idPermisoPorPantalla { get; set; }
        public int idPantalla { get; set; }
        public int idOrigen { get; set; }
        public int Orden { get; set; }
        public string Rol { get; set; }
        public string Pantalla { get; set; }
        public string ToolTip { get; set; }
        public string url { get; set; }
        public string urlMovil { get; set; }
        public string Clase { get; set; }
        public string MsgGuardar { get; set; }
        public string MsgEliminar { get; set; }
        public string PreguntaEliminar { get; set; }
        public List<MenuItem> SubMenu { get; set; } = new List<MenuItem>();
    }
    public partial class vwUsuario
    {
        public int idUsuario { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string ClaveAcceso { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public int idRol { get; set; }
        public int idEstatus { get; set; }
        public string Token { get; set; }
        public string Rol { get; set; }
        public string Estatus { get; set; }
    }
   
    public class cUsuario
    {
        // Cambia a int para coincidir con el backend
        public int idUsuario { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string ClaveAcceso { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        // Cambia a int para coincidir con el backend
        public int idRol { get; set; }
        public int idEstatus { get; set; }
        public string Token { get; set; }
        public cResul R { get; set; } = new cResul(); // Inicializa aquí

    }
    // En tu proyecto Shared/Models/ResponseModel.cs
    public partial class vwResultado
    {
        public int idResultado { get; set; }
        public string modulo { get; set; }
        public string metodos { get; set; }
        public string fechaString { get; set; } // Campo para recibir el valor crudo

        [JsonConverter(typeof(JsonDotNetDateConverter))]// Ignorar esta propiedad al serializar
        public DateTime fecha { get; set; } // Campo para almacenar el valor convertido

        //[JsonConverter(typeof(DateTimeToBackendFormatConverter))]
        //public DateTime FechaInicio { get; set; } = DateTime.Now.AddMonths(-1);

        //[JsonConverter(typeof(DateTimeToBackendFormatConverter))]
        //public DateTime FechaFin { get; set; } = DateTime.Now;

        public string Usuario { get; set; }
        public string Estatus { get; set; }
        public string mensaje { get; set; }
        public string mensajeDeSistema { get; set; }
        public int idEstatus { get; set; }
        public int idUsuario { get; set; }
    }
    public class BitacoraRequest
    {
        public string FechaInicial { get; set; }
        public string FechaFinal { get; set; }
        public string modulo { get; set; }
        public string Usuario { get; set; }
        public string metodos { get; set; }
        public string Estatus { get; set; }
        public RequestMetadata R { get; set; }
    }

    public class RequestMetadata
    {
        public string modulo { get; set; }
        public string metodos { get; set; }
        public string Token { get; set; }
    }

    public class Rol
    {
        public int idRol { get; set; }
        public string Texto { get; set; }
        public int TienePermiso { get; set; }
        public bool PermisoActivo
        {
            get => TienePermiso == 1;
            set => TienePermiso = value ? 1 : 0;
        }
        public List<Rol> Permisos { get; set; } = new List<Rol>();
        
        
    }
    public class vwPantallas
    {
        public int idPantalla { get; set; }
        public int Orden { get; set; }
        public string Pantalla { get; set; }
        public string url { get; set; }
        public string Clase { get; set; }
        public string ToolTip { get; set; }
        public string Descripcion { get; set; }
        public string MsgGuardar { get; set; }
        public string MsgEliminar { get; set; }
        public string PreguntaEliminar { get; set; }
        public int  idOrigen { get; set; }
        public int idEstatus { get; set; }
        public string Estatus { get; set; }
        public string urlMovil { get; set; }
        public int Estatusi { get; set; }
        public int idRol { get; set; }
        public List<vwPantallas> SubMenu { get; set; }
    }

}