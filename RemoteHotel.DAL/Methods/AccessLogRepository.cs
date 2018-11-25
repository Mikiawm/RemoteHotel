using RemoteHotel.DAL.Interfaces;
using RemoteHotel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RemoteHotel.DAL.Methods
{
    public class AccessLogRepository : Repository<AccessLog>, IAccessLogRepository
    {
        public AccessLogRepository(DbContext context) : base(context)
        {
        }
    }
}