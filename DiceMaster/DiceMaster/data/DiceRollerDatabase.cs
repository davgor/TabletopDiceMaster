using DiceMaster.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceMaster.data
{
    public class DiceRollerDatabase
    {
        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
            {
                return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            });

            public DiceRollerDatabase()
            {
                InitializeAsync().SafeFireAndForget(false);
            }

            async Task InitializeAsync()
            {
                if (!initialized)
                {
                    if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(SQLiteEntireRoll).Name))
                    {
                        await Database.CreateTablesAsync(CreateFlags.None, typeof(SQLiteEntireRoll)).ConfigureAwait(false);
                    }
                    initialized = true;
                }
            }

            public Task<List<SQLiteEntireRoll>> GetItemsAsync()
            {
                return Database.Table<SQLiteEntireRoll>().ToListAsync();
            }

            public Task<List<SQLiteEntireRoll>> GetFavorites()
            {
                return Database.QueryAsync<SQLiteEntireRoll>("SELECT * FROM [EntireRoll] WHERE [favorite] = true");
            }

            public Task<SQLiteEntireRoll> GetItemAsync(int id)
            {
                return Database.Table<SQLiteEntireRoll>().Where(i => i.id == id).FirstOrDefaultAsync();
            }

            public Task<int> SaveItemAsync(SQLiteEntireRoll item)
            {
                if (item.id != 0)
                {
                    return Database.UpdateAsync(item);
                }
                else
                {
                    return Database.InsertAsync(item);
                }
            }

            public Task<int> DeleteItemAsync(SQLiteEntireRoll item)
            {
                return Database.DeleteAsync(item);
            }
        }
}
