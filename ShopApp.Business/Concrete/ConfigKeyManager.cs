using ShopApp.Business.Abstract;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Business.Concrete
{
    public class ConfigKeyManager : IConfigKeyService
    {
        private IConfigKeyDal _configKeyDal;

        public ConfigKeyManager(IConfigKeyDal configKeyDal)
        {
            _configKeyDal = configKeyDal;
        }

        public string GetConfigValueByKey(string key)
        {
            return _configKeyDal.GetConfigValueByKey(key);
        }
    }
}
