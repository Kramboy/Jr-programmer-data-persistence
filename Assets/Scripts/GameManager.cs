using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int highScore1;
    public int highScore2;
    public int highScore3;
    public string currentPlayer;
    public string bestPlayer1;
    public string bestPlayer2;
    public string bestPlayer3;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    class SaveData
    {
        public string bestPlayer1;
        public string bestPlayer2;
        public string bestPlayer3;
        public int highScore1;
        public int highScore2;
        public int highScore3;
    }

    public void Save()
    {
        SaveData data = new();
        data.bestPlayer1 = bestPlayer1;
        data.bestPlayer2 = bestPlayer2;
        data.bestPlayer3 = bestPlayer3;
        data.highScore1 = highScore1;
        data.highScore2 = highScore2;
        data.highScore3 = highScore3;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayer1 = data.bestPlayer1;
            bestPlayer2 = data.bestPlayer2;
            bestPlayer3 = data.bestPlayer3;
            highScore1 = data.highScore1;
            highScore2 = data.highScore2;
            highScore3 = data.highScore3;
        }
    }
}
