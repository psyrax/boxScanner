using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace boxScanner
{
    public class BoxDB
    {
        readonly SQLiteAsyncConnection database;
        private Task<Box> boxInfo;

        public BoxDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Box>().Wait();
            database.CreateTableAsync<BoxItem>().Wait();
        }

        public Task<Box> GetBoxAsync(string boxId)
        {
           return database.Table<Box>().Where(s =>s.BoxId == boxId).FirstOrDefaultAsync();
        }
        public Task<List<Box>> GetBoxesAsync()
        {
            return database.Table<Box>().ToListAsync();
        }
        public Task<int> SaveBoxAsync(Box box) {
            if(box.ID != 0)
            {
                return database.UpdateAsync(box);
            }
            else
            {
                return database.InsertAsync(box);
            }
        }

        public Task<List<BoxItem>> GetItemsAsync(string boxId)
        {
            return database.Table<BoxItem>().Where(i => i.BoxId == boxId).ToListAsync();
        }

        public Task<List<BoxItem>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<BoxItem>("SELECT * FROM [BoxItem] WHERE [Done] = 0");
        }

        public Task<BoxItem> GetItemAsync(int id)
        {
            return database.Table<BoxItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(BoxItem item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(BoxItem item)
        {
            return database.DeleteAsync(item);
        }
    }
}
