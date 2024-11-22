using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWVentas.Data.Entities.DwVentas
{
    public partial class FactOrder
    {
        public int OrderId { get; set; }

        public string CustomerId { get; set; }

        public int? EmployeeId { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? ShipVia { get; set; }

        public string ShipCity { get; set; }

        public string ShipCountry { get; set; }

        public decimal? TotalVentas { get; set; }

        public int? CantidadVentas { get; set; }

        public virtual DimCustomer Customer { get; set; }

        public virtual DimEmployee Employee { get; set; }

        public virtual DimShipper ShipViaNavigation { get; set; }
    