﻿using DiceMaster.models;
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
                return Database.QueryAsync<SQLiteEntireRoll>("SELECT * FROM [SQLiteEntireRoll] ORDER BY date DESC");
            }

            public Task<List<SQLiteEntireRoll>> GetFavorites()
            {
                return Database.QueryAsync<SQLiteEntireRoll>("SELECT * FROM [SQLiteEntireRoll] WHERE [favorite] = true ORDER BY date DESC");
            }
            public Task<SQLiteEntireRoll> GetItemAsync(int id)
            {
                return Database.Table<SQLiteEntireRoll>().Where(i => i.id == id).OrderBy(i => i.date).FirstOrDefaultAsync();
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
        public Task<List<SQLiteEntireRoll>> NameSearch(string item)
        {
            return Database.QueryAsync<SQLiteEntireRoll>("SELECT * FROM [SQLiteEntireRoll] WHERE name = '" + item + "'");
        }

        public Task<List<SQLiteEntireRoll>> DeleteItemAsync(SQLiteEntireRoll item)
        {
            return Database.QueryAsync<SQLiteEntireRoll>("DELETE FROM [SQLiteEntireRoll] WHERE name = '" + item.Name + "'");
        }
        public Task<List<SQLiteEntireRoll>> DeleteItemAsyncName(string item)
        {
            return Database.QueryAsync<SQLiteEntireRoll>("DELETE FROM [SQLiteEntireRoll] WHERE name = '" + item + "'");
        }

    }
}
