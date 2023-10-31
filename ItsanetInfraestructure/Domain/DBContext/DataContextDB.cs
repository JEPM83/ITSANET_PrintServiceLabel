using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using ItsanetInfraestructure.Domain.Entities;
using ItsanetInfraestructure.Interface;
using System.Data;
using System.Data.SqlClient;

namespace ItsanetInfraestructure.Domain.DBContext
{
    public class DataContextDB:IPrintSpool
    {
        protected string cnxStringCRM = ConfigurationManager.ConnectionStrings["conexionCRM"].ToString();

        public List<PrintSpoolResponse> GetPrintData(PrintSpoolRequest obj)
        {
            var printListDetail = new List<PrintSpoolResponse>();
            try
            {

                using (SqlConnection conn = new SqlConnection(cnxStringCRM))
                using (SqlCommand cmd = new SqlCommand(ObjectsDA.PrintDataService, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id_almacen", SqlDbType.NVarChar).Value = obj.id_almacen;
                    cmd.Parameters.Add("@codigo_proceso", SqlDbType.NVarChar).Value = obj.codigo_proceso;
                    conn.Open();
                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        var printDetail = new PrintSpoolResponse();
                        printDetail.Ide_spool = int.Parse(sqlReader["id_spool"].ToString());
                        printDetail.Cod_process = sqlReader["codigo_proceso"].ToString();
                        printDetail.codigo_pais = sqlReader["codigo_pais"].ToString();
                        printDetail.nombre = sqlReader["nombre"].ToString();
                        printDetail.Barcode = sqlReader["codigo_barra"].ToString();
                        printDetail.Sprint = sqlReader["estado_impresion"].ToString();
                        printDetail.Printerip = sqlReader["ip_impresora"].ToString();
                        printDetail.Printerport = int.Parse(sqlReader["puerto_impresora"].ToString());
                        printDetail.Quantity = float.Parse(sqlReader["cantidad"].ToString());
                        //
                        printListDetail.Add(printDetail);
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            return printListDetail;
        }
        public List<PrintBultoxBultoxEanResponse> GetPrintDataBultoxBultoxEan(PrintBultoxBultoxEanRequest obj)
        {
            var printListDetail = new List<PrintBultoxBultoxEanResponse>();
            try
            {

                using (SqlConnection conn = new SqlConnection(cnxStringCRM))
                using (SqlCommand cmd = new SqlCommand(ObjectsDA.PrintDataService, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id_almacen", SqlDbType.NVarChar).Value = obj.id_almacen;
                    cmd.Parameters.Add("@codigo_proceso", SqlDbType.NVarChar).Value = obj.codigo_proceso;
                    conn.Open();
                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        var printDetail = new PrintBultoxBultoxEanResponse();
                        printDetail.id_spool = int.Parse(sqlReader["id_spool"].ToString());
                        printDetail.codigo_proceso = sqlReader["codigo_proceso"].ToString();
                        printDetail.numero_item = sqlReader["numero_item"].ToString();
                        printDetail.talla = sqlReader["talla"].ToString();
                        printDetail.codigo_barra = sqlReader["codigo_barra"].ToString();
                        printDetail.cantidad_bulto = float.Parse(sqlReader["cantidad_bulto"].ToString());
                        printDetail.cantidad = float.Parse(sqlReader["cantidad"].ToString());
                        printDetail.importacion = sqlReader["importacion"].ToString();
                        printDetail.numero_orden_compra = sqlReader["numero_orden_compra"].ToString();
                        printDetail.destino = sqlReader["destino"].ToString();
                        printDetail.ip_impresora = sqlReader["ip_impresora"].ToString();
                        printDetail.puerto_impresora = int.Parse(sqlReader["puerto_impresora"].ToString());
                        printDetail.estado_impresion = sqlReader["estado_impresion"].ToString();
                        //
                        printListDetail.Add(printDetail);
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            return printListDetail;
        }
        public List<PrintBultoxBultoxRFIDResponse> GetPrintDataBultoxBultoxRFID(PrintBultoxBultoxRFIDRequest obj)
        {
            var printListDetail = new List<PrintBultoxBultoxRFIDResponse>();
            try
            {

                using (SqlConnection conn = new SqlConnection(cnxStringCRM))
                using (SqlCommand cmd = new SqlCommand(ObjectsDA.PrintDataService, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id_almacen", SqlDbType.NVarChar).Value = obj.id_almacen;
                    cmd.Parameters.Add("@codigo_proceso", SqlDbType.NVarChar).Value = obj.codigo_proceso;
                    conn.Open();
                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        var printDetail = new PrintBultoxBultoxRFIDResponse();
                        printDetail.id_spool = int.Parse(sqlReader["id_spool"].ToString());
                        printDetail.codigo_proceso = sqlReader["codigo_proceso"].ToString();
                        printDetail.numero_item = sqlReader["numero_item"].ToString();
                        printDetail.talla = sqlReader["talla"].ToString();
                        printDetail.codigo_barra = sqlReader["codigo_barra"].ToString();
                        printDetail.cantidad_bulto = float.Parse(sqlReader["cantidad_bulto"].ToString());
                        printDetail.cantidad = float.Parse(sqlReader["cantidad"].ToString());
                        printDetail.importacion = sqlReader["importacion"].ToString();
                        printDetail.numero_orden_compra = sqlReader["numero_orden_compra"].ToString();
                        printDetail.destino = sqlReader["destino"].ToString();
                        printDetail.ip_impresora = sqlReader["ip_impresora"].ToString();
                        printDetail.puerto_impresora = int.Parse(sqlReader["puerto_impresora"].ToString());
                        printDetail.estado_impresion = sqlReader["estado_impresion"].ToString();
                        printDetail.nota = sqlReader["nota"].ToString();
                        printDetail.curva = sqlReader["curva"].ToString();
                        //
                        printListDetail.Add(printDetail);
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            return printListDetail;
        }
        public List<PrintLpnVASResponse> GetPrintDataLpnVAS(PrintLpnVASRequest obj)
        {
            var printListDetail = new List<PrintLpnVASResponse>();
            try
            {

                using (SqlConnection conn = new SqlConnection(cnxStringCRM))
                using (SqlCommand cmd = new SqlCommand(ObjectsDA.PrintDataService, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id_almacen", SqlDbType.NVarChar).Value = obj.id_almacen;
                    cmd.Parameters.Add("@codigo_proceso", SqlDbType.NVarChar).Value = obj.codigo_proceso;
                    conn.Open();
                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        var printDetail = new PrintLpnVASResponse();
                        printDetail.id_spool = int.Parse(sqlReader["id_spool"].ToString());
                        printDetail.id_almacen = sqlReader["codigo_proceso"].ToString();
                        printDetail.codigo_proceso = sqlReader["codigo_proceso"].ToString();
                        printDetail.numero_orden_pedido = sqlReader["numero_orden_pedido"].ToString();
                        printDetail.numero_lote = sqlReader["numero_lote"].ToString();
                        printDetail.cantidad = float.Parse(sqlReader["cantidad"].ToString());
                        printDetail.uxc = float.Parse(sqlReader["uxc"].ToString());
                        printDetail.ip_impresora =  sqlReader["ip_impresora"].ToString();
                        printDetail.puerto_impresora = int.Parse(sqlReader["puerto_impresora"].ToString());
                        printDetail.estado_impresion = sqlReader["estado_impresion"].ToString();
                        printDetail.linea = sqlReader["linea"].ToString();
                        printDetail.cita = sqlReader["cita"].ToString();
                        printDetail.factura = sqlReader["factura"].ToString();
                        printDetail.destino = sqlReader["destino"].ToString();
                        printDetail.lpn = sqlReader["lpn"].ToString();
                        printDetail.familia = sqlReader["modelo"].ToString();
                        printDetail.destino_cod = sqlReader["destino_cod"].ToString();
                        printDetail.destino_des = sqlReader["destino_des"].ToString();
                        //
                        printListDetail.Add(printDetail);
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            return printListDetail;
        }
        public void SetPrintStatus(PrintPatchRequest obj)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(cnxStringCRM))
                using (SqlCommand cmd = new SqlCommand(ObjectsDA.PatchPrintService, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id_spool", SqlDbType.Int).Value = obj.id_spool;
                    cmd.Parameters.Add("@sprint", SqlDbType.Char).Value = obj.sprint;
                    conn.Open();
                    int srow = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
