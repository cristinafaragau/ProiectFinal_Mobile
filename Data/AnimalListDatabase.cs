using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using ProiectFinal_Mobile.Models;
using SQLite;

namespace ProiectFinal_Mobile.Data
{
    public class AnimalListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public AnimalListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<AnimalList>().Wait();
            _database.CreateTableAsync<Breed>().Wait();
            _database.CreateTableAsync<ListBreed>().Wait();
            _database.CreateTableAsync<RoomList>().Wait();
        }
        //room list ------------

        public Task<List<RoomList>> GetRoomListsAsync()
        {
            return _database.Table<RoomList>().ToListAsync();
        }
        public Task<RoomList> GetRoomListAsync(int id)
        {
            return _database.Table<RoomList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveRoomListAsync(RoomList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteRoomListAsync(RoomList slist)
        {
            return _database.DeleteAsync(slist);
        }

        //----------------room list
        public Task<int> SaveBreedAsync(Breed breed)
        {
            if (breed.ID != 0)
            {
                return _database.UpdateAsync(breed);
            }
            else
            {
                return _database.InsertAsync(breed);
            }
        }
        public Task<int> DeleteBreedAsync(Breed breed)
        {
            return _database.DeleteAsync(breed);
        }
        public Task<List<Breed>> GetBreedsAsync()
        {
            return _database.Table<Breed>().ToListAsync();
        }
public Task<List<AnimalList>> GetAnimalListsAsync()
        {
            return _database.Table<AnimalList>().ToListAsync();
        }
        public Task<AnimalList> GetAnimalListAsync(int id)
        {
            return _database.Table<AnimalList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveAnimalListAsync(AnimalList alist)
        {
            if (alist.ID != 0)
            {
                return _database.UpdateAsync(alist);
            }
            else
            {
                return _database.InsertAsync(alist);
            }
        }
        public Task<int> SaveListBreedAsync(ListBreed listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }

        public Task<List<ListBreed>> GetListBreeds()
        {
            return _database.QueryAsync<ListBreed>("select * from ListBreed");
        }
        public Task<List<Breed>> GetListBreedsAsync(int shoplistid)
        {
            return _database.QueryAsync<Breed>(
            "select P.ID, P.Name from Breed P"
            + " inner join ListBreed LP"
            + " on P.ID = LP.BreedID where LP.AnimalListID = ?",
            shoplistid);
        }
        public Task<int> DeleteAnimalListAsync(AnimalList alist)
        {
            return _database.DeleteAsync(alist);
        }
        public Task<int> DeleteListBreedAsync(ListBreed lbreed)
        {
            return _database.DeleteAsync(lbreed);
        }
    }
}
