using System;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Repository.Interfaces;

namespace DVDRentalAPI.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public DVDRentalContext Context { get; }

        public IActorRepository Actors { get; }
        public IAddressRepository Addresses { get; }
        public ICityRepository Cities { get; }
        public ICountryRepository Countries { get; }
        public IDirectorRepository Directors { get; }
        public IGenreRepository Genres { get; }
        public IInventoryRepository Inventory { get; }
        public ILanguageRepository Languages { get; }
        public IMediaRepository Media { get; }
        public IMovieRepository Movies { get; }
        public IMovieActorRepository MovieActors { get; }
        public IProducerRepository Producers { get; }
        public IRentalHistoryRepository RentalHistory { get; }
        public IRoleRepository Roles { get; }
        public IStateRepository States { get; }
        public IStoreRepository Stores { get; }
        public IUserRepository Users { get; }
        public IWriterRepository Writers { get; }
        public IMovieThumbRepository MovieThumbs { get; }

        public UnitOfWork(DVDRentalContext context)
        {
            Context = context;
            Actors = new ActorRepository(Context);
            Addresses = new AddressRepository(Context);
            Cities = new CityRepository(Context);
            Countries = new CountryRepository(Context);
            Directors = new DirectorRepository(Context);
            Genres = new GenreRepository(Context);
            Inventory = new InventoryRepository(Context);
            Languages = new LanguageRepository(Context);
            Media = new MediaRepository(Context);
            Movies = new MovieRepository(Context);
            MovieActors = new MovieActorRepository(Context);
            Producers = new ProducerRepository(Context);
            RentalHistory = new RentalHistoryRepository(Context);
            Roles = new RoleRepository(Context);
            States = new StateRepository(Context);
            Stores = new StoreRepository(Context);
            Users = new UserRepository(Context);
            Writers = new WriterRepository(Context);
            MovieThumbs = new MovieThumbRepository(Context);
        }

        public bool Commit()
        {
            return Context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
