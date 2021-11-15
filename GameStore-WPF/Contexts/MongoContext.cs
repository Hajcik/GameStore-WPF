using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace GameStore_WPF.Contexts
{
    public class MongoContext
    {
        MongoClient _client;
        MongoServer _server;
        public MongoDatabase _database;

        public MongoContext()
        {
            var MongoDatabaseName = ConfigurationManager.AppSettings["MongoDatabaseName"];
            var MongoPort = ConfigurationManager.AppSettings["MongoPort"]; // 27017
            var MongoHost = ConfigurationManager.AppSettings["MongoHost"]; // localhost

            var settings = new MongoClientSettings
            {
                Server = new MongoServerAddress(MongoHost, Convert.ToInt32(MongoPort))
            };

            _client = new MongoClient(settings);
            _server = _client.GetServer();
            _database = _server.GetDatabase(MongoDatabaseName);
        }
    }
}
