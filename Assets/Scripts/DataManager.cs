using System;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string CurrentName = String.Empty;
    public string ScoreName = String.Empty;
    public int Score = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string ScoreName;
        public int Score;
    }

    public void LoadScore()
    {
        string path = $"{Application.persistentDataPath}/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            ScoreName = data.ScoreName;
            Score = data.Score;
        }
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.ScoreName = ScoreName;
        data.Score = Score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText($"{Application.persistentDataPath}/savefile.json", json);
    }
}