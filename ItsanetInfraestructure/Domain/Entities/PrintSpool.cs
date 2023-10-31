using System;
using System.Collections.Generic;
using System.Text;

namespace ItsanetInfraestructure.Domain.Entities
{
    public class PrintSpoolRequest {
        public string _id_almacen;
        public string _codigo_proceso;        
        public string id_almacen { get => _id_almacen; set => _id_almacen = value; }
        public string codigo_proceso { get => _codigo_proceso; set => _codigo_proceso = value; }
    }
    public class PrintSpoolResponse
    {
        private int _ide_spool;
        private string _cod_process;
        private string _codigo_pais;
        private string _nombre;
        private string _barcode;
        private string _sprint;
        private string _printerip;
        private int _printerport;
        private float _quantity;
        public int Ide_spool { get => _ide_spool; set => _ide_spool = value; }
        public string Cod_process { get => _cod_process; set => _cod_process = value; }
        public string codigo_pais { get => _codigo_pais; set => _codigo_pais = value; }
        public string nombre { get => _nombre; set => _nombre = value; }
        public string Barcode { get => _barcode; set => _barcode = value; }
        public string Sprint { get => _sprint; set => _sprint = value; }
        public string Printerip { get => _printerip; set => _printerip = value; }
        public int Printerport { get => _printerport; set => _printerport = value; }
        public float Quantity { get => _quantity; set => _quantity = value; }
        
    }
    public class PrintBultoxBultoxEanRequest {
        public string id_almacen { get; set; }
        public string codigo_proceso { get; set; }
    }
    public class PrintBultoxBultoxEanResponse { 
        public int id_spool { get; set; }
        public string codigo_proceso { get; set; }
        public string numero_item { get; set; }
        public string talla { get; set; }
        public string codigo_barra { get; set; }
        public float cantidad_bulto { get; set; }
        public float cantidad { get; set; }
        public string importacion { get; set; }
        public string numero_orden_compra { get; set; } //DOCUMENTO
        public string destino { get; set; }
        public string ip_impresora { get; set; }
        public int puerto_impresora { get; set; }
        public string estado_impresion { get; set; }
    }
    public class PrintBultoxBultoxRFIDRequest
    {
        public string id_almacen { get; set; }
        public string codigo_proceso { get; set; }
    }
    public class PrintBultoxBultoxRFIDResponse
    {
        public int id_spool { get; set; }
        public string codigo_proceso { get; set; }
        public string numero_item { get; set; }
        public string talla { get; set; }
        public string codigo_barra { get; set; }
        public float cantidad_bulto { get; set; }
        public float cantidad { get; set; }
        public string importacion { get; set; }
        public string numero_orden_compra { get; set; } //DOCUMENTO
        public string destino { get; set; }
        public string ip_impresora { get; set; }
        public int puerto_impresora { get; set; }
        public string estado_impresion { get; set; }
        public string nota { get; set; }
        public string curva { get; set; }
    }
    public class PrintLpnVASRequest {
        public string id_almacen { get; set; }
        public string codigo_proceso { get; set; }
    }
    public class PrintLpnVASResponse
    {
        public int id_spool { get; set; }
        public string id_almacen { get; set; }
        public string codigo_proceso { get; set; }
        public string numero_orden_pedido { get; set; }
        public string numero_lote { get; set; }
        public float cantidad { get; set; }
        public float uxc { get; set; }
        public string ip_impresora { get; set; }
        public int puerto_impresora { get; set; }
        public string estado_impresion { get; set; }
        public string linea { get; set; } //attributte1
        public string cita { get; set; } //attributte2
        public string factura { get; set; } //documento
        public string destino { get; set; }
        public string lpn { get; set; } //BARCODE
        public string familia { get; set; } //MODELO
        public string? destino_cod { get; set; } //NOTA
        public string? destino_des { get; set; } //CURVA
    }

    public class PrintPatchRequest { 
        public int id_spool { get; set; }
        public string sprint { get; set; }
    }
}
