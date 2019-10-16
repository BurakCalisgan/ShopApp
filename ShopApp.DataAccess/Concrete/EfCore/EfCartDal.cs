﻿using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public class EfCartDal : EfCoreGenericRepository<Cart, ShopContext>, ICartDal
    {
        public Cart GetCartByUserId(string userId)
        {
            using (ShopContext context = new ShopContext())
            {
                return context.Carts
                              .Include(i => i.CartItems)
                              .ThenInclude(i => i.Product)
                              .FirstOrDefault(i => i.UserId == userId);
            } 
        }
    }
}
