using LoadDwVenta.Data.Core;
using LoadDWVentas.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWVentas.Data.Services
{
    public class DimCategory : IDimCategory
    {
        private readonly DwhVentasContext dwhVentasContext;
        private readonly NorthwindContext northwindContext;
        public DimCategoryService(DwhVentasContext dwhVentasContext, NorthwindContext northwindContext)
        {
            this.dwhVentasContext = dwhVentasContext;
            this.northwindContext = northwindContext;
        }

        public async Task<OperationResult> LoadCategory()
        {
            OperationResult operation = new OperationResult();
            try
            {
                var categories = northwindContext.Categories.Select(emp => new DimCategory()
                {
                    CategoryId = emp.CategoryId,
                    CategoryName = emp.CategoryName,
                    Description = emp.Description

                }).ToList();
                await dwhVentasContext.DimCategories.AddRangeAsync(categories);
                await dwhVentasContext.SaveChangesAsync();
                operation.Success = true;

            }
            catch (Exception)
            {
                operation.Success = false;
                operation.Message = $"Error cargando la dimesion de categorias";
            }

            return operation;
        }
    }
}
