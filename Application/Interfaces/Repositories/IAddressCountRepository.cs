namespace Application.Interfaces.Repositories
{
    public interface IAddressCountRepository
    {
        Task UpdateCount(int GovernorateId);
    }
}
