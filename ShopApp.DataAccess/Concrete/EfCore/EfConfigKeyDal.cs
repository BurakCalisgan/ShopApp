using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public class EfConfigKeyDal : EfCoreGenericRepository<ConfigKey, ShopContext>, IConfigKeyDal
    {
        public string GetConfigValueByKey(string key)
        {
            using (var context = new ShopContext())
            {
                var configKey = context.ConfigKeys
                        .Where(i => i.Key == key)
                        .FirstOrDefault();

                return configKey.Value;
            }
        }
    }
}