﻿using SOS.Core.DataAccess;
using SOS.DataObjects.Entities.SosSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.DataAccess.DapperDal.ContactDal
{
    public interface IContactService : IGenericRepository<Contact>
    {
    }
}
