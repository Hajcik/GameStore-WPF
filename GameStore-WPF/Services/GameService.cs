using GameStore_WPF.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Windows.Controls;

namespace GameStore_WPF.Services
{
    public class GameService
    {
        // CRUD
        // Put them in controller later

        private readonly IMongoCollection<Game> _games;
        private static IMongoDatabase db;
        private static IMongoClient client;

        public GameService(string _client, string dbName, string collectionName, IMongoDatabase _db, IMongoClient _mongoClient)
        {
            client = new MongoClient(_client);
            db = client.GetDatabase(dbName);

            _games = db.GetCollection<Game>(collectionName);
            _db = db;
            _mongoClient = client;
            
        }

        public List<Game> Get() =>
            _games.Find(game => true).ToList();

        public Game Get(string id) =>
            _games.Find<Game>(game => game._id == id).FirstOrDefault();

        public Game Create(Game game)
        {
            _games.InsertOne(game);
            return game;
        }

        public void Update(string id, Game gameUpdate) =>
            _games.ReplaceOne(game => game._id == id, gameUpdate);

        public void Remove(Game gameDel) =>
            _games.DeleteOne(game => game._id == gameDel._id);

        public void Remove(string id) =>
            _games.DeleteOne(game => game._id == id);

    }
}
