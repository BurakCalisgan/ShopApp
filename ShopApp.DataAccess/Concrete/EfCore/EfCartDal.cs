using Microsoft.EntityFrameworkCore;
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
        public override void Update(Cart entity)
        {
            using (ShopContext context = new ShopContext())
            {
                context.Carts.Update(entity);
                context.SaveChanges();

            }

        }

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

        public void DeleteFromCart(int cartId, int productId)
        {
            using (ShopContext context = new ShopContext())
            {
                var cmd = @"delete from CartItem where CartId=@p0 and ProductId=@p1";
                context.Database.ExecuteSqlCommand(cmd, cartId, productId);
            }
        }
    }
}
