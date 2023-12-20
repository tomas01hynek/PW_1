﻿using System;
using Microsoft.AspNetCore.Http;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IOrderCartService
    {
        double AddOrderItemsToSession(int? productId, ISession session);
        bool ApproveOrderInSession(int userId, ISession session);
    }
}

