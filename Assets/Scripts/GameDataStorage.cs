using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public class GameDataStorage 
{
    private const string filePath = "game_data.save";

    public void Initialize()
    {
       if(this==null)
        {
            new GameDataStorage();
        }
    }

    public void Save(GameDataWallet dataWallet)
    {
        string json = JsonUtility.ToJson(dataWallet);
        File.WriteAllText(Application.persistentDataPath + "/" + filePath, json);
    }

    public GameDataWallet Load()
    {
        if (!File.Exists(Application.persistentDataPath + "/" + filePath)) 
        {
           return new GameDataWallet();
        }

        string json = File.ReadAllText(Application.persistentDataPath + "/" + filePath);
        return JsonUtility.FromJson<GameDataWallet>(json);
    }
}
