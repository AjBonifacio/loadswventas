using LoadDwVenta.Data.Core;
using LoadDWVentas.Data.Entities.DwVentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWVentas.Data.Services
{
    public class DimShipperService : IDimShipperService
    {
        private readonly DwhVentasContext dwhVentasContext;
        private readonly NorthwindContext northwindContext;

        public DimShipperService(DwhVentasContext dwhVentasContext, NorthwindContext northwindContext)
        {
            this.dwhVentasContext = dwhVentasContext;
            this.northwindContext = northwindContext;
        }

        public async Task<OperationResult> LoadShippers()
        {
            OperationResult operation = new OperationResult();
            try
            {
                var shippers = northwindContext.Shippers.Select(ship => new DimShipper()
                {
                    ShipperId = ship.ShipperId,
                    CompanyName = ship.CompanyName,
                    Phone = ship.Phone
                }).ToList();

                await dwhVentasContext.DimShippers.AddRangeAsync(shippers);
                await dwhVentasContext.SaveChangesAsync();
                operation.Success = true;
            }
            catch (Exception)
            {
                operation.Success = false;
                operation.Message = $"Error cargando la dimesion de shippers";
            }

            return operation;
        }
    }
}
