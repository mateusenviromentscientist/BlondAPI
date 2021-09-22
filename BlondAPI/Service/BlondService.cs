using BlondAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlondAPI.Service
{
    public class BlondService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<ViewModelBlond> _blondData = null;
        private readonly DatabaseSettings databaseSettings;
        
        public BlondService(IOptionsMonitor<DatabaseSettings> optionsMonitor)
        {
            databaseSettings = optionsMonitor.CurrentValue;
            _mongoClient = new MongoClient(databaseSettings.ConnectionString);
            _database = _mongoClient.GetDatabase(databaseSettings.DatabaseName);
            _blondData = _database.GetCollection<ViewModelBlond>(databaseSettings.ClientesCollectionName);
        }
        public List<ViewModelBlond> Get()
        {
            return _blondData.Find(FilterDefinition<ViewModelBlond>.Empty).ToList();
        }
        public ViewModelBlond GetById(string id)
        {
            return _blondData.Find<ViewModelBlond>(blond => blond.Id == id).FirstOrDefault();
        }
        public ViewModelBlond Create(ViewModelBlond blond)
        {
            _blondData.InsertOne(blond);
            return blond;
        }
        public void Update(string id, ViewModelBlond blond)
        {
            _blondData.ReplaceOne(blond => blond.Id == id, blond);
        }
        public void Delete(ViewModelBlond blond)
        {
            _blondData.DeleteOne(blond => blond.Id == blond.Id);
        }
        public void DeleteById(string id)
        {
            _blondData.DeleteOne(blond => blond.Id == id);
        }


    }
}
