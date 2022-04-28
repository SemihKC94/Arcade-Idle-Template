using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public static class DataManager
{
    public static void SaveData<T>(string key, T saveObject)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(GetFullPath(key));
        binaryFormatter.Serialize(file, saveObject);
        file.Close();
    }

    public static void SaveDataAsJson<T>(string key, T saveObject)
    {
        string json = JsonUtility.ToJson(saveObject);
        SaveData<string>(key, json);
    }

    public static T LoadData<T>(string key)
    {
        T data;
        var fullPath = GetFullPath(key);

        if (File.Exists(fullPath))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(fullPath, FileMode.Open);

            data = (T)binaryFormatter.Deserialize(file);
            file.Close();
        }
        else
        {
            data = default(T);
        }

        return data;
    }

    public static T LoadJsonData<T>(string key)
    {
        var json = LoadData<string>(key);

        T data = JsonUtility.FromJson<T>(json);

        return data;
    }

    private static string GetFullPath(string key)
    {
        return Application.persistentDataPath + "/" + key + ".save";
    }
}