﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AkademiPlusApi.EntityLayer.Concrete;

namespace AkademiPlusApi.BusinessLayer.Abstract
{
    public interface ICustomerService:IGenericService<Customer>
    {
        int TGetCustomerCounts();
    }
}
