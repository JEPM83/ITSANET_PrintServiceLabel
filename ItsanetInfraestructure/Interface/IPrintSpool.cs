using System;
using System.Collections.Generic;
using System.Text;
using ItsanetInfraestructure.Domain.Entities;

namespace ItsanetInfraestructure.Interface
{
    public interface IPrintSpool
    {
        public List<PrintSpoolResponse> GetPrintData(PrintSpoolRequest obj);
        public List<PrintBultoxBultoxEanResponse> GetPrintDataBultoxBultoxEan(PrintBultoxBultoxEanRequest obj);
        public void SetPrintStatus(PrintPatchRequest obj);
    }
}
