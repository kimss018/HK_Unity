using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public ObjectId _id { get; set; }

    public string name { get; set; }
    public int highscore { get; set; }
    
}
