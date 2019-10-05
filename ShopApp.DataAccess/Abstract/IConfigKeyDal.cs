using ShopApp.Entities;

namespace ShopApp.DataAccess.Abstract
{
    public interface IConfigKeyDal : IRepository<ConfigKey>
    {
        string GetConfigValueByKey(string key);
    }
}
