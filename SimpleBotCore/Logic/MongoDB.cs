using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace SimpleBotCore.Logic
{
    public class MongoDB
    {
        MongoClient client = null;

        public MongoDB()
        {
            client = new MongoClient("mongodb://localhost:27017");
        }

        public bool Inserir(string comando)
        {
            bool commit;
            try
            {
                var db = client.GetDatabase("16NET");
                var colecao = db.GetCollection<BsonDocument>("colecao");

                var dados = new BsonDocument()
            {
                {"id", 1 },
                {"comando", comando}
            };
                colecao.InsertOne(dados);
                commit = true;
            }
            catch
            {
                throw;
            }
            return commit;
        }
    }
}
