using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using System;

public class DataBaseAcces : MonoBehaviour
{

    MongoClient client = new MongoClient("mongodb+srv://Admin:Admin@mycluster-xum9e.gcp.mongodb.net/test?retryWrites=true&w=majority");
    IMongoDatabase db;
    IMongoCollection<BsonDocument> collection;

    // Start is called before the first frame update
    void Start()
    {
        db = client.GetDatabase("JustAlive");
        collection = db.GetCollection<BsonDocument>("JustAliveScore");
    }

    public async void GuardarScore(string jugador, int score)
    {
        var document = new BsonDocument{{ jugador, score }};
        await collection.InsertOneAsync(document);
    }

    public async Task<List<MayoresScores>> TraerScores()
    {
        var allScoresTask = collection.FindAsync(new BsonDocument());
        var scoresAwaited = await allScoresTask;

        List<MayoresScores> mayoresScores = new List<MayoresScores>();
        foreach(var score in scoresAwaited.ToList())
        {
            mayoresScores.Add(Deserialize(score.ToString()));
        }
        return mayoresScores;
    }

    private MayoresScores Deserialize(string v)
    {
        var mayoresScores = new MayoresScores();
        var stringSinId = v.Substring(v.IndexOf("),")+4);

        var Jugador = stringSinId.Substring(0, stringSinId.IndexOf(":")-2);
        var Score = stringSinId.Substring(stringSinId.IndexOf(":")+2, stringSinId.IndexOf("}")-stringSinId.IndexOf(":")-3);


        mayoresScores.Jugador = Jugador;
        mayoresScores.score = Convert.ToInt32(Score);
        return mayoresScores;
    }

}


//inline class
public class MayoresScores{

    public string Jugador {get; set;}
    public int score {get; set;}
}