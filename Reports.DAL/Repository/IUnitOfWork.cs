using System.Threading.Tasks;

namespace Reports.DAL.Repository
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}