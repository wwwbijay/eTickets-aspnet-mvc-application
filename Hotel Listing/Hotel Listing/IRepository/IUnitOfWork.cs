using Hotel_Listing.Data;
using System;
using System.Threading.Tasks;

namespace Hotel_Listing.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Hotel> Hotels { get; }
        Task Save();
    }
}
