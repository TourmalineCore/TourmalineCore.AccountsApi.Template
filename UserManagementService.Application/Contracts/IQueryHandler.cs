using System.Threading.Tasks;

namespace UserManagementService.Application.Contracts
{
    public interface IQueryHandler<in Tin, Tout>
    {
        Task<Tout> Handle(Tin query);
    }
}
