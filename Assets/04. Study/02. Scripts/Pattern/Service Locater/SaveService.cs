using UnityEngine;

public class SaveService : ISaveService
{
    public void SaveData()
    {
        Debug.Log("Save Data");
    }

    public void LoadData()
    {
        Debug.Log("Load Data");
    }
}