using SampleAppWeb.EntityFramework;
using SampleAppWeb.Uow.Models;

namespace SampleAppWeb.Uow
{
    public interface ITouristRepository
    {
        Task<AdequateShop> Get();
        Task<Tourist> GetById(int touristID);
        Task<Tourist> Insert(TouristAddRequest tourist);
        Task<Tourist> Update(TouristEditRequest tourist);
        Task<Tourist> Delete(int touristID);        
    }
}