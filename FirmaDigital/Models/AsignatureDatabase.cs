using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FirmaDigital.Models
{
    public class SignatureDatabase
    {
        readonly SQLiteAsyncConnection database;

        public SignatureDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Signature>().Wait();
        }

        public Task<List<Signature>> GetSignaturesAsync()
        {
            return database.Table<Signature>().ToListAsync();
        }

        public Task<int> SaveSignatureAsync(Signature signature)
        {
            if (signature.Id != 0)
            {
                return database.UpdateAsync(signature);
            }
            else
            {
                return database.InsertAsync(signature);
            }
        }
    }

}
