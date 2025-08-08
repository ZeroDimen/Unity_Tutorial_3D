using System;
using System.IO;
using UnityEngine;


[System.Serializable]
public class SaveData
{
    public int score;
}

public class SavaDataFile : MonoBehaviour
{
    private int score;
    private string savePath;

    void Start()
    {
        // Application.dataPath : Assets 폴더
        // Application.persistentDataPath : 플랫폼별로 안전하게 추천하는 로컬 저장소 경로
        savePath = Path.Combine(Application.persistentDataPath, "saveDataFile.json");

        Load();
        Debug.Log("Load Score : " + score);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score++;
            Debug.Log("Score : " + score);
            
            Save();
        }
    }

    private void Save()
    {
        SaveData data = new SaveData();
        data.score = this.score;

        string json = JsonUtility.ToJson(data);
        // string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(savePath, json);

        Debug.Log("Data saved to : " + savePath);
    }

    private void Load()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            this.score = data.score;
        }
        else
        {
            score = 0;
        }
    }

    void OnApplicationQuit()
    {
        Save();
    }
}