﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemoteHotel.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRoomRepository Rooms { get; }
        IAccountRepository Accounts { get; }
        ICustomerRepository Customers { get; }
        IHotelRepository Hotels { get; }
        IAccessLogRepository AccessLogs { get; }
        IReservationRepository Reservations { get; }
        int Complete();
    }
}