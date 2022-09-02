using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mongoDBCtrl : MonoBehaviour
{
    const string MONGO_URI = "mongodb+srv://test11:test11@cluster0.idpyw5b.mongodb.net/?retryWrites=true&w=majority";
    const string DATABASE_NAME = "test11";

    MongoClient client;
    IMongoDatabase db;
    IMongoCollection<GameData> db_col;

    void Start()
    {
        // 초기화 부분
        /////////////////////
        db_login();
        get_database();
        get_collection();
        /////////////////////

        // db_all_view();
        // db_insert("HK", 0);
        // db_find("HK");

        // db_insert("HK", 0);
        // db_insert("HYO", 0);
        // db_insert("KYEONG", 0);

        // db_removes("HK");
        // db_remove_all();
        db_update("HK", 100);
    }

    void db_update(string name, int score)
    {
        BsonDocument _bson_search = new BsonDocument { { "name", name } };
        BsonDocument _bson_update = new BsonDocument { { "name", name }, { "highscore", score } };

        db_col.FindOneAndUpdate(_bson_search, _bson_update);

    }

    void db_remove(string name)
    {
        // 하나만 지우기
        BsonDocument _bson = new BsonDocument { { "name", name } };
        db_col.DeleteOne(_bson);
    }

    void db_removes(string name)
    {
        // 다수 지우기
        BsonDocument _bson = new BsonDocument { { "name", name } };
        db_col.DeleteMany (_bson);
    }

    void db_remove_all()
    {
        BsonDocument _bson = new BsonDocument {};
        db_col.DeleteMany (_bson);
    }

    void db_find(string name)
    {
        BsonDocument _bson = new BsonDocument { { "name", name } };

        List<GameData> user_list = db_col.Find(_bson).ToList();
        
        GameData[] user_data = user_list.ToArray();

        for(int i = 0; i < user_data.Length; i++)
        {
            //Debug.Log(user_data[i].name + ":" + user_data[i].highscore);
        }
    }

    void db_all_view()
    {
        List<GameData> user_list = db_col.Find(user => true).ToList();
        GameData[] user_data = user_list.ToArray();
        
        for (int i = 0; i < user_data.Length; i++)
        {
            // Debug.Log(user_data[i].name + ":" + user_data[i].highscore);
        }
    }

    bool db_exist(string name)
    {
        BsonDocument _bson = new BsonDocument { { "name", name } };
        
        List<GameData> user_list = db_col.Find(_bson).ToList();
        GameData[] user_data = user_list.ToArray();

        if(user_data.Length == 0) return false;
        return true;
    }

    void db_insert(string name, int score)
    {
        if (db_exist(name))
        {
           // Debug.Log("Name is exist : " + name);
            return;
        }

        GameData _g = new GameData();
        _g.name = name;
        _g.highscore = score;

        db_col.InsertOne(_g);
    }







    void get_collection()
    {
        db_col = db.GetCollection<GameData>("test11_col");

    }

    void db_login()
    {
        client =  new MongoClient(MONGO_URI);
    }

    void get_database()
    {
        db = client.GetDatabase(DATABASE_NAME);
    }


}
