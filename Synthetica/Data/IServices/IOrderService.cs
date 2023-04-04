﻿using System;
using Synthetica.Models;

namespace Synthetica.Data.IServices
{
	public interface IOrderService
	{
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}

