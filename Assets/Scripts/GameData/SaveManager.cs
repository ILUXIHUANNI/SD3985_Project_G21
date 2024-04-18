using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public SaveFile saveFile;
    public string savePath;
    public string saveName = "/mySave.dat";

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        savePath = Application.persistentDataPath + saveName;
    }

    public void New()
    {
        saveFile = new SaveFile();
        SceneManager.LoadScene(1);
    }

    public void Save(PlayerController player)
    {
        saveFile.position = player.transform.position;
        saveFile.scene = SceneManager.GetActiveScene().buildIndex;
        BinarySaveSystem.WriteToBinaryFile(savePath, saveFile);
    }
    public void Load()
    {
        saveFile = BinarySaveSystem.ReadFromBinaryFile<SaveFile>(savePath);
    }

}
[System.Serializable]
public class SaveFile
{
    public int scene;

    public Vector2 position
    {
        get => new Vector2(x, y);
        set
        {
            x = value.x;
            y = value.y;
        }
    }
    public float x, y, z;

}