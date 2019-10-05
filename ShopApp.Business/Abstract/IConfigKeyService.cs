using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Business.Abstract
{
    public interface IConfigKeyService
    {
        string GetConfigValueByKey(string key);
    }
}
