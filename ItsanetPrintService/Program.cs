using System;
using ItsanetInfraestructure.Service;
using ItsanetInfraestructure.Domain.Entities;
//using System.ServiceProcess;

namespace ItsanetPrintService
{
    public class Program
    {
        public void Servicio() {
            Console.WriteLine("Iniciando programa de impresion!.");

            PrintService obj = new PrintService();
            PrintSpoolRequest model = new PrintSpoolRequest();
            PrintBultoxBultoxEanRequest model_bulto = new PrintBultoxBultoxEanRequest();
            PrintBultoxBultoxRFIDRequest model_bulto_RFID = new PrintBultoxBultoxRFIDRequest();
            PrintLpnVASRequest model_lpn_VAS = new PrintLpnVASRequest();
            try
            {
                model.id_almacen = "01";
                model.codigo_proceso = "PRINTER_LPN";
                obj.ZebraPrint(obj.GetPrintData(model));

                model_bulto.id_almacen = "01";
                model_bulto.codigo_proceso = "PRINTER_BULTO_TEXTIL";
                obj.ZebraPrintBultoxBultoxEan(obj.GetPrintDataBultoxBultoxEan(model_bulto));

                model_bulto_RFID.id_almacen = "01";
                model_bulto_RFID.codigo_proceso = "PRINTER_BULTO_RFID";
                obj.ZebraPrintBultoxBultoxRFID(obj.GetPrintDataBultoxBultoxRFID(model_bulto_RFID));

                model_lpn_VAS.id_almacen = "01";
                model_lpn_VAS.codigo_proceso = "PRINTER_LPN_VAS";
                obj.ZebraPrintLpnVASD(obj.GetPrintDataLpnVAS(model_lpn_VAS));
            }
            catch (Exception ex)
            {
                obj = null;
                model_bulto = null;
                model = null;
                model_bulto_RFID = null;
                throw new Exception(ex.Message);
            }
        }
        static void Main(string[] args)
        {
           
        }
    }
}
