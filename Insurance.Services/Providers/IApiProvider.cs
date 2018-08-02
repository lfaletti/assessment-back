using System.Threading.Tasks;

namespace Insurance.Services.Providers
{
    public interface IApiProvider<T, TCollection>
    {
        Task<TCollection> GetAllAsync();
    }
}