using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWVentas.Data.Entities.DwVentas
{
    public partial class FactClientesAtendido
    {
        public int ClienteAtentidoId { get; set; }

        public int EmployeeKey { get; set; }

        public int TotalClientes { get; set; }
    }
}
