using DiceMaster.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceMaster.data
{
    class DiceRollerDatabase
    {
        public class TodoItemDatabase
        {
            static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
            {
                return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            });

            static SQLiteAsyncConnection Database => lazyInitializer.Value;
            static bool initialized = false;

            public TodoItemDatabase()
            {
                InitializeAsync().SafeFireAndForget(false);
            }

            async Task InitializeAsync()
            {
                if (!initialized)
                {
                    if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(EntireRoll).Name))
                    {
                        await Database.CreateTablesAsync(CreateFlags.None, typeof(EntireRoll)).ConfigureAwait(false);
                    }
                    initialized = true;
                }
            }

            public Task<List<EntireRoll>> GetItemsAsync()
            {
                return Database.Table<EntireRoll>().ToListAsync();
            }

            public Task<List<EntireRoll>> GetItemsNotDoneAsync()
            {
                return Database.QueryAsync<EntireRoll>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
            }

            public Task<EntireRoll> GetItemAsync(int id)
            {
                return Database.Table<EntireRoll>().Where(i => i.id == id).FirstOrDefaultAsync();
            }

            public Task<int> SaveItemAsync(EntireRoll item)
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

            public Task<int> DeleteItemAsync(EntireRoll item)
            {
                return Database.DeleteAsync(item);
            }
        }
    }
}
