using System;
using DVDRentalAPI.Core.Model;

namespace DVDRentalAPI.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DVDRentalContext Context { get; }

        IActorRepository Actors { get; }
        IAddressRepository Addresses { get; }
        ICityRepository Cities { get; }
        ICountryRepository Countries { get; }
        IDirectorRepository Directors { get; }
        IGenreRepository Genres { get; }
        IInventoryRepository Inventory { get; }
        ILanguageRepository Languages { get; }
        IMediaRepository Media { get; }
        IMovieRepository Movies { get; }
        IMovieActorRepository MovieActors { get; }
        IProducerRepository Producers { get; }
        IRentalHistoryRepository RentalHistory { get; }
        IRoleRepository Roles { get; }
        IStateRepository States { get; }
        IStoreRepository Stores { get; }
        IUserRepository Users { get; }
        IWriterRepository Writers { get; }

        bool Commit();
    }
}
