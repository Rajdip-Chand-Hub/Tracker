using DataModel.Model;

namespace DataAccess.Service.Interface
{
    public interface IUserService
    {
        bool Login(Users user);
    }
}
