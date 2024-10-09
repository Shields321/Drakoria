using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using JetBrains.Annotations;

[System.Serializable]
public class playerList
{
    public List<PlayerData> Players;
}
[Serializable]
public class PlayerData
{
    public string Name;
    public int Level;
    public int hp;
    public int atk;
    public Skills skills;
}
public class Skills
{
    public string skill1;
    public string skill2;
    public string skill3;
    public string skill4;
    public string skill5;
    public string skill6;
}
public class readJson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "Json/playerStats.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            
            Debug.Log("Name: " + playerData.Name);
            Debug.Log("Level: " + playerData.Level);
            Debug.Log("hp: " + playerData.hp);
            Debug.Log("atk: " + playerData.atk);
            Debug.Log("skills: " + playerData.skills);
        }
        else
        {
            Debug.LogError("Cannot find the JSON file");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
