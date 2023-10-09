using System;
using System.Collections.Generic;
using System.Text;

namespace ItsanetInfraestructure.Domain.DBContext
{
    static class ObjectsDA
    {
        /*Lista de cola de impresion*/
        public static string PrintDataService = "SP_PRINTER_WEB_GET_LIST_PRINTSPOOL";
        /*Actualizar estatus de la cola de impresion*/
        public static string PatchPrintService = "SP_PRINTER_WEB_PATCH_PRINTSPOOL";
    }
}
