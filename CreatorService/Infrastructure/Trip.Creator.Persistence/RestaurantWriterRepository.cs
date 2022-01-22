﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Creator.Application.Contracts.Persistance;
using Trip.Creator.Domain.Entities;
using Trip.Creator.Persistance.Base;
using Trip.Creator.Persistence.Base;

namespace Trip.Creator.Persistence
{
    public class RestaurantWriterRepository : BaseWriterRepository<Restaurant>, IRestaurantWriterRepository
    {
        public RestaurantWriterRepository(CreatorWriterDbContext profileWriterDbContext) : base(profileWriterDbContext)
        {

        }

    }
}
