﻿using LoadDwVenta.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDWVentas.Data.Interfaces
{
    public interface IDimShipper
    {
        Task<OperationResult> LoadShippers();
    }
}