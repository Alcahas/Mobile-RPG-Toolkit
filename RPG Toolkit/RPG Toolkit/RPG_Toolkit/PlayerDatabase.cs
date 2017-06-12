using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Toolkit
{
    public class PlayerDatabase
    {
        readonly SQLiteAsyncConnection database;

        public PlayerDatabase(string dDPath)
        {
            database = new SQLiteAsyncConnection(dDPath);
            database.CreateTableAsync<Players>().Wait();
        }

        public Task<List<Players>>GetPlayersAsync()
        {
            return database.Table<Players>().ToListAsync();
        }

        public Task<Players>GetPlayersAsync(int id)
        {
            return database.Table<Players>().Where(i => i.PlID == id).FirstOrDefaultAsync();

        }

        public Task<int> SavePlayerAsync(Players player)
        {
          if (player.PlID == 0)
            {
                return database.UpdateAsync(player);
            }
          else
          {
                return database.InsertAsync(player);
          }
        }

        public Task<int> DeletePlayerAsync(Players player)
        {
            return database.DeleteAsync(player);
        }

    }
}
