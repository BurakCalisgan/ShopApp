using ShopApp.Business.Abstract;
using ShopApp.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartDal _cartDal;
        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public void InitializeCart(string userId)
        {
            _cartDal.Create(new Entities.Cart()
            {
                UserId = userId
            });
        }
    }
}
