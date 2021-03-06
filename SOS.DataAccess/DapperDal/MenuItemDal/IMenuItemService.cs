﻿using SOS.Core.DataAccess;
using SOS.DataObjects.Entities.RestaurantSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.DapperDal.MenuItemDal
{
    public interface IMenuItemService : IGenericRepository<MenuItem>
    {
        MenuItem GetWithCategory(int id);
    }
}
