using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public UserSave _userSave;

    private string SAVE_PATH = "";
    private readonly string SAVE_FILENAME = "/SaveFile.json";


    private void Awake()
    {
        instance = this;
        SAVE_PATH = Application.persistentDataPath + "/Save";

        if (!Directory.Exists(SAVE_PATH))
        {
            Directory.CreateDirectory(SAVE_PATH);
        }

        LoadFronJson();
    }

    public void ResetSaveFile()
    {
        _userSave = new UserSave("User", 0, 0, 10, 0, 10);
    }

    private void LoadFronJson()
    {
        if (File.Exists(SAVE_PATH + SAVE_FILENAME))
        {
            string json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            _userSave = JsonUtility.FromJson<UserSave>(json);
        }
        else
        {
            ResetSaveFile();

            SaveToJson();
            LoadFronJson();
        }
    }

    public void SaveToJson()
    {
        SAVE_PATH = Application.persistentDataPath + "/Save";
        if (_userSave == null) return;

        string json = JsonUtility.ToJson(_userSave, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json);
    }

    private void OnApplicationQuit()
    {
        SaveToJson();
    }

}