using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;


    public class MongoHelper<T> where T : class
    {
        public MongoCollection<T> Collection { get; private set; }

        private MongoClient client;
        private MongoServer server;
        private MongoDatabase provider;
        private MongoUrl mongoUrl;
        //string _connectionString;


        public MongoHelper()
        {

            //MongoClient client = new MongoClient(new MongoUrl("mongodb://localhost"));
            //MongoClient client = new MongoClient(new MongoUrl("mongodb://MongoLab-f:WWbQ.o5xQSOIU7fKjXqtCubyg_iD9BZVoSrCIFfKk.0-@ds062797.mongolab.com:62797/MongoLab-f"));
            //MongoClient client = new MongoClient(new MongoUrl("mongodb://Andrew:----@ds062797.mongolab.com:62797/MongoLab-f"));

            
            mongoUrl = new MongoUrl("mongodb://MongoLab-f:WWbQ.o5xQSOIU7fKjXqtCubyg_iD9BZVoSrCIFfKk.0-@ds062797.mongolab.com:62797/MongoLab-f");
            
            
            client = new MongoClient(mongoUrl);           
            server = client.GetServer();
            server.Connect();
            
            
            //MongoDatabase db = server.GetDatabase("hearthealth");
            //MongoDatabase db = server.GetDatabase("MongoLab-f");

            provider = server.GetDatabase(mongoUrl.DatabaseName, WriteConcern.Acknowledged);

            Collection = provider.GetCollection<T>(typeof(T).Name.ToLower());
        }


        public MongoHelper(string connectionString)
        {

            mongoUrl = new MongoUrl(connectionString);
            client = new MongoClient(mongoUrl);
            server = client.GetServer();
            server.Connect();
            provider = server.GetDatabase(mongoUrl.DatabaseName, WriteConcern.Acknowledged);
            Collection = provider.GetCollection<T>(typeof(T).Name.ToLower());
        }

    }

