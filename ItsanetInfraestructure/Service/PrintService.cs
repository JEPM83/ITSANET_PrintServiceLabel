using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading;
using ItsanetInfraestructure.Domain.DBContext;
using ItsanetInfraestructure.Domain.Entities;
using ItsanetInfraestructure.Interface;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer;
using Zebra.Sdk.Printer.Discovery;

namespace ItsanetInfraestructure.Service
{
    public class PrintService : IPrintSpool
    {
        /*Impresion LPN*/
        public List<PrintSpoolResponse> GetPrintData(PrintSpoolRequest obj)
        {
            DataContextDB printObjects = new DataContextDB();
            List<PrintSpoolResponse> resp = new List<PrintSpoolResponse>();
            try
            {
                resp = printObjects.GetPrintData(obj);
                //Console.WriteLine("Starting printer discovery.");
            }
            catch (Exception ex) {
                resp = null;
                throw new Exception(ex.Message);
            }
            return resp;
        }
        public void ZebraPrint(List<PrintSpoolResponse> printList)
        {
            try
            {
                float cont = 1;
                foreach (PrintSpoolResponse obj in printList)
                {
                    try
                    {
                        cont = obj.Quantity;
                        for (int i = 0; i < cont; i++)
                        {
                            try
                            {
                                Connection connection = new TcpConnection(obj.Printerip, obj.Printerport);
                                connection.Open();
                                ZebraPrinter printer = ZebraPrinterFactory.GetInstance(PrinterLanguage.LINE_PRINT, connection);
                                string[] strZPL = zplFormat(obj);
                                printer.PrintStoredFormat("E:FORMAT3.ZPL", strZPL);
                                Console.WriteLine("Imprimiendo etiqueta en impresora: " + obj.Printerip.ToString());
                                Thread.Sleep(500);
                                PrintPatchRequest objPatch = new PrintPatchRequest();
                                if (i == 0)
                                {
                                    // set print status Yes
                                    objPatch.id_spool = obj.Ide_spool;
                                    objPatch.sprint = "Y";
                                    SetPrintStatus(objPatch);
                                }
                                connection.Close();
                            }
                            catch (ConnectionException ex)
                            {
                                Console.WriteLine("Error al imprimir 1: " + ex.StackTrace.ToString());
                            }
                        }
                    }
                    catch (ConnectionException ex)
                    {
                        Console.WriteLine("Error al imprimir 2: " + ex.StackTrace.ToString());
                    }
                }
            }
            catch (ConnectionException ex)
            {
                Console.WriteLine("Error al imprimir 3: " + ex.StackTrace.ToString());
            }
        }
        private string[] zplFormat(PrintSpoolResponse obj)
        {
            string[] strZPL = new string[33];
            strZPL[0] = "^XA";
            strZPL[1] = "^CFA,40";
            strZPL[2] = "^FO20,20^FD" + obj.codigo_pais + "^FS";
            strZPL[3] = "^CF0,20";
            strZPL[4] = "^FO280,20^FD" + obj.nombre + "^FS";
            strZPL[5] = "^FX Third section with bar code.";
            strZPL[6] = "^BY3,2,200";
            strZPL[7] = "^FO20,100^BC^FD" + obj.Barcode.Trim() + "^FS";
            strZPL[8] = "^XZ";
            return strZPL;
        }
        /*Impresion BultoxBultoxEan*/
        public List<PrintBultoxBultoxEanResponse> GetPrintDataBultoxBultoxEan(PrintBultoxBultoxEanRequest obj)
        {
            DataContextDB printObjects = new DataContextDB();
            List<PrintBultoxBultoxEanResponse> resp = new List<PrintBultoxBultoxEanResponse>();
            try
            {
                resp = printObjects.GetPrintDataBultoxBultoxEan(obj);
                //Console.WriteLine("Starting printer discovery.");
            }
            catch (Exception ex)
            {
                resp = null;
                throw new Exception(ex.Message);
            }
            return resp;
        }
        public void ZebraPrintBultoxBultoxEan(List<PrintBultoxBultoxEanResponse> printList)
        {
            try
            {
                float cont = 1;
                foreach (PrintBultoxBultoxEanResponse obj in printList)
                {
                    try
                    {
                        cont = obj.cantidad;
                        for (int i = 0; i < cont; i++)
                        {
                            try
                            {
                                Connection connection = new TcpConnection(obj.ip_impresora, obj.puerto_impresora);
                                connection.Open();
                                ZebraPrinter printer = ZebraPrinterFactory.GetInstance(PrinterLanguage.LINE_PRINT, connection);
                                string[] strZPL = zplFormatBultoxBultoxEan(obj);
                                printer.PrintStoredFormat("E:FORMAT3.ZPL", strZPL);
                                Console.WriteLine("Imprimiendo etiqueta en impresora: " + obj.ip_impresora.ToString());
                                Thread.Sleep(500);
                                PrintPatchRequest objPatch = new PrintPatchRequest();
                                if (i == 0)
                                {
                                    // set print status Yes
                                    objPatch.id_spool = obj.id_spool;
                                    objPatch.sprint = "Y";
                                    SetPrintStatus(objPatch);
                                }
                                connection.Close();
                            }
                            catch (ConnectionException ex)
                            {
                                Console.WriteLine("Error al imprimir 1: " + ex.StackTrace.ToString());
                            }
                        }
                    }
                    catch (ConnectionException ex)
                    {
                        Console.WriteLine("Error al imprimir 2: " + ex.StackTrace.ToString());
                    }
                }
            }
            catch (ConnectionException ex)
            {
                Console.WriteLine("Error al imprimir 3: " + ex.StackTrace.ToString());
            }
        }
        private string[] zplFormatBultoxBultoxEan(PrintBultoxBultoxEanResponse obj)
        {
            string[] strZPL = new string[33];
            strZPL[0] = "^XA";
            strZPL[1] = "^CFA,30";
            strZPL[2] = "^FO20,20^FDCODIGO / TALLA " + obj.numero_item + " " + obj.talla + "^FS";
            strZPL[3] = "^FO20,50^FDEAN^FS";
            strZPL[4] = "^FO270,50^FD" + obj.codigo_barra + "^FS";
            strZPL[5] = "^^FO20,80^FDIMPORTACION^FS";
            strZPL[6] = "^BY3,2,40";
            strZPL[7] = "^FO270,80^BC^FD" + obj.importacion + "^FS";
            //strZPL[8] = "^FO20,160^FDNUM O/C^FS";
            //strZPL[9] = "^BY3,2,40";
            //strZPL[10] = "^FO270,160^BC^FD" + obj.numero_orden_compra + "^FS";
            strZPL[11] = "^FO20,240^FDQTY CAJAS^FS";
            strZPL[12] = "^FO270,240^FD" + obj.cantidad_bulto + "^FS";
            strZPL[13] = "^FO600,240^FD" + obj.destino + "^FS";
            strZPL[14] = "^BY4,2,70";
            strZPL[15] = "^FO40,280^BC^FD" + obj.codigo_barra.Trim() + "^FS";
            strZPL[16] = "^XZ";
            return strZPL;
        }
        /*Impresion BultoxBultoxRFID*/
        public List<PrintBultoxBultoxRFIDResponse> GetPrintDataBultoxBultoxRFID(PrintBultoxBultoxRFIDRequest obj)
        {
            DataContextDB printObjects = new DataContextDB();
            List<PrintBultoxBultoxRFIDResponse> resp = new List<PrintBultoxBultoxRFIDResponse>();
            try
            {
                resp = printObjects.GetPrintDataBultoxBultoxRFID(obj);
                //Console.WriteLine("Starting printer discovery.");
            }
            catch (Exception ex)
            {
                resp = null;
                throw new Exception(ex.Message);
            }
            return resp;
        }
        public void ZebraPrintBultoxBultoxRFID(List<PrintBultoxBultoxRFIDResponse> printList)
        {
            try
            {
                //int j = 1;
                float cont = 1;
                foreach (PrintBultoxBultoxRFIDResponse obj in printList)
                {
                    try
                    {
                        cont = obj.cantidad;
                        for (int i = 0; i < cont; i++)
                        {
                            try
                            {
                                //string[] pp = zplFormatBultoxBultoxRFID(obj, i);
                                Connection connection = new TcpConnection(obj.ip_impresora, obj.puerto_impresora);
                                connection.Open();
                                ZebraPrinter printer = ZebraPrinterFactory.GetInstance(PrinterLanguage.LINE_PRINT, connection);
                                
                                string[] strZPL = zplFormatBultoxBultoxRFID(obj,i);
                                //j = j * 10;
                                printer.PrintStoredFormat("E:FORMAT3.ZPL", strZPL);
                                Console.WriteLine("Imprimiendo etiqueta en impresora: " + obj.ip_impresora.ToString());
                                Thread.Sleep(500);
                                PrintPatchRequest objPatch = new PrintPatchRequest();
                                if (i == 0)
                                {
                                    // set print status Yes
                                    objPatch.id_spool = obj.id_spool;
                                    objPatch.sprint = "Y";
                                    SetPrintStatus(objPatch);
                                }
                                connection.Close();
                            }
                            catch (ConnectionException ex)
                            {
                                Console.WriteLine("Error al imprimir 1: " + ex.StackTrace.ToString());
                            }
                        }
                    }
                    catch (ConnectionException ex)
                    {
                        Console.WriteLine("Error al imprimir 2: " + ex.StackTrace.ToString());
                    }
                }
            }
            catch (ConnectionException ex)
            {
                Console.WriteLine("Error al imprimir 3: " + ex.StackTrace.ToString());
            }
        }
        private string[] zplFormatBultoxBultoxRFID(PrintBultoxBultoxRFIDResponse obj,int i)
        {
            //string hostgroupid = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string hostgroupid = DateTime.Now.ToString("fffssmmHHdd");
            //string hostgroupid = DateTime.Now.ToString("ddHHmmssfff");
            string valorHex;
            string cia = "9999";
            string item = obj.numero_item;
            string validador = codificacion(obj.numero_item);
            string contador = (i + 1).ToString();
            valorHex = String.Format("{0:X}",BigInteger.Parse(String.Concat(cia,item,validador,obj.curva.Trim(),hostgroupid)));
            valorHex = valorHex.PadLeft(24,'0');
            //valorHex = String.Format("{0:X}", long.Parse(String.Concat(cia, item, validador, contador)));
            string[] strZPL = new string[17];
            strZPL[0] = "^XA";
            strZPL[1] = "^RS8";
            strZPL[2] = "^RFW,H^FD" + valorHex + "^FS";
            strZPL[3] = "^BY1,2,20";
            strZPL[4] = "^FO60,20^A0N,20,20^FDCODIGO INV^FS";
            strZPL[5] = "^FO180,20^A0N,20,20^BC^FD" + obj.numero_item.Trim() + "CB" +  obj.curva.Trim() + "^FS";
            strZPL[6] = "^FO60,80^A0N,20,20^FDIMPORTACION^FS";
            strZPL[7] = "^BY1,2,20";
            strZPL[8] = "^FO180,80^A0N,20,20^BC^FD" + obj.importacion + "^FS";
            //strZPL[9] = "^FO60,130^A0N,20,20^FDNUM O/C^FS";
            //strZPL[10] = "^BY1,2,20";
            //strZPL[11] = "^FO180,130^A0N,20,20^BC^FD" + obj.numero_orden_compra + "^FS";
            strZPL[9] = "^FO60,190^A0N,20,20^FDQTY CAJAS^FS";
            strZPL[10] = "^FO220,190^A0N,20,20^FD" + obj.cantidad_bulto + "^FS";
            strZPL[11] = "^FO370,150^A0N,20,20^FD" + obj.destino + "^FS";
            strZPL[12] = "^FO370,170^A0N,20,20^FD" + String.Concat("CB",obj.curva.Trim()) + "^FS";
            strZPL[13] = "^FO350,190^A0N,20,20^FD" + obj.nota + "^FS";
            strZPL[14] = "^BY3,2,40";
            strZPL[15] = "^FO60,210^A0N,20,20^BC^FD" + obj.codigo_barra.Trim() + "^FS";
            strZPL[16] = "^XZ";
            return strZPL;
        }
        /*Impresion de LPN VAS*/
        public List<PrintLpnVASResponse> GetPrintDataLpnVAS(PrintLpnVASRequest obj)
        {
            DataContextDB printObjects = new DataContextDB();
            List<PrintLpnVASResponse> resp = new List<PrintLpnVASResponse>();
            try
            {
                resp = printObjects.GetPrintDataLpnVAS(obj);
                //Console.WriteLine("Starting printer discovery.");
            }
            catch (Exception ex)
            {
                resp = null;
                throw new Exception(ex.Message);
            }
            return resp;
        }
        public void ZebraPrintLpnVASD(List<PrintLpnVASResponse> printList)
        {
            try
            {
                //int j = 1;
                float cont = 1;
                foreach (PrintLpnVASResponse obj in printList)
                {
                    try
                    {
                        cont = obj.cantidad;
                        for (int i = 0; i < cont; i++)
                        {
                            try
                            {
                                //string[] pp = zplFormatBultoxBultoxRFID(obj, i);
                                Connection connection = new TcpConnection(obj.ip_impresora, obj.puerto_impresora);
                                connection.Open();
                                ZebraPrinter printer = ZebraPrinterFactory.GetInstance(PrinterLanguage.LINE_PRINT, connection);

                                string[] strZPL = zplFormatLpnVAS(obj);
                                //j = j * 10;
                                printer.PrintStoredFormat("E:FORMAT3.ZPL", strZPL);
                                Console.WriteLine("Imprimiendo etiqueta en impresora: " + obj.ip_impresora.ToString());
                                Thread.Sleep(500);
                                PrintPatchRequest objPatch = new PrintPatchRequest();
                                if (i == 0)
                                {
                                    // set print status Yes
                                    objPatch.id_spool = obj.id_spool;
                                    objPatch.sprint = "Y";
                                    SetPrintStatus(objPatch);
                                }
                                connection.Close();
                            }
                            catch (ConnectionException ex)
                            {
                                Console.WriteLine("Error al imprimir 1: " + ex.StackTrace.ToString());
                            }
                        }
                    }
                    catch (ConnectionException ex)
                    {
                        Console.WriteLine("Error al imprimir 2: " + ex.StackTrace.ToString());
                    }
                }
            }
            catch (ConnectionException ex)
            {
                Console.WriteLine("Error al imprimir 3: " + ex.StackTrace.ToString());
            }
        }
        private string[] zplFormatLpnVAS(PrintLpnVASResponse obj)
        {
            string[] strZPL = new string[33];
            strZPL[0] = "^XA";
            strZPL[1] = "^CFA,30";
            strZPL[2] = "^FO20,20^FDCODIGO / TALLA " + obj.factura + " " + obj.cantidad + "^FS";
            strZPL[3] = "^FO20,50^FDEAN^FS";
            strZPL[4] = "^FO270,50^FD" + obj.cita + "^FS";
            strZPL[5] = "^^FO20,80^FDIMPORTACION^FS";
            strZPL[6] = "^BY3,2,40";
            strZPL[7] = "^FO270,80^BC^FD" + obj.codigo_proceso + "^FS";
            strZPL[11] = "^FO20,240^FDQTY CAJAS^FS";
            strZPL[12] = "^FO270,240^FD" + obj.destino + "^FS";
            strZPL[13] = "^FO600,240^FD" + obj.destino + "^FS";
            strZPL[14] = "^BY4,2,70";
            strZPL[15] = "^FO40,280^BC^FD" + obj.line.Trim() + "^FS";
            strZPL[16] = "^XZ";
            return strZPL;
        }
        /*Actualizar Status*/
        public void SetPrintStatus(PrintPatchRequest obj)
        {
            DataContextDB printObjects = new DataContextDB();
            try
            {
                printObjects.SetPrintStatus(obj);
            }
            catch (Exception ex)
            {
                printObjects = null;
                throw new Exception(ex.Message);
            }
        }

        private string codificacion(string item) {
            //item = "41261533";
            string[] valor;
            var stringNumber = item;
            long numericValue;
            int resultado = 0;
            string verificador = null;
            bool isNumber = long.TryParse(stringNumber,out numericValue);
            int[] array = { 2,3,4,5,6,7,2,3};
            if (isNumber == true){
                int i = item.Length;
                int j = 0;
                valor = new string[i];
                while (i > 0) {
                    valor[j] = item.Substring(i - 1,1);
                    i = i - 1;
                    j++;
                }
                for (int x = 0; x < 8; x++) { 
                    resultado = resultado + int.Parse(valor[x].ToString()) * array[x];
                }
                int residuo = resultado % 11;
                if ((11 - residuo) < 10)
                {
                    verificador = (11 - residuo).ToString();
                }
                else if ((11 - residuo) == 11)
                {
                    verificador = "0";
                }
                else if ((11 - residuo) == 10) {
                    verificador = "1";
                }
            }
            return verificador;
        }
    }
}
