using AtividadeAvaliativa.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAvaliativa.Repositorios
{
    public class CheckinRepositorio
    {
        public CheckinRepositorio()
        {

        }

        SQLiteAsyncConnection _dataBase;
        static string dataBaseFileName = "aulaDb.db3";

        SQLite.SQLiteOpenFlags flags = SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache;

        static string dataBasePath = Path.Combine(FileSystem.AppDataDirectory,dataBaseFileName);

        public async Task Init()
        {
            if (_dataBase is not null)
            {
                return;
            }

            _dataBase = new SQLiteAsyncConnection(dataBasePath, flags);

            await _dataBase.CreateTableAsync<Cliente>();
        }

        public async Task<List<Cliente>> GetClientes()
        {
            await Init();

            return await _dataBase.Table<Cliente>().ToListAsync();
        }

        public async Task<Cliente> GetCliente(string cpf)
        {
            await Init();
            return await _dataBase.Table<Cliente>().Where(c => c.CPF == cpf).FirstOrDefaultAsync();
        }

        public async Task<int> SaveCliente(Cliente cliente)
        {
            await Init();

            return await _dataBase.InsertAsync(cliente);
        }

        public async Task<int> DeleteCliente(Cliente cliente)
        {
            await Init();
            return await _dataBase.DeleteAsync(cliente);
        }
    }
}