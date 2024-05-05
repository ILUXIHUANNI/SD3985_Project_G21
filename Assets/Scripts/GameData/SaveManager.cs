using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public SaveFile saveFile;
    public string savePath;
    public string saveName = "/mySave.dat";

    [SerializeField] Slider Master;
    [SerializeField] Slider BGM;
    [SerializeField] Slider SFX;

    private void Awake()
    {
        instance = this;
        savePath = Application.persistentDataPath + saveName;
    }

    public void New()
    {
        saveFile = new SaveFile();
        Save();
        //saveFile.position = new Vector2 (-55.2f, -21.94f);
        SceneManager.LoadScene(1);
    }

    public void Save(PlayerController player)
    {
        saveFile.position = player.transform.position;
        saveFile.scene = SceneManager.GetActiveScene().buildIndex;
        saveFile.master = Master.value;
        saveFile.bgm = BGM.value;
        saveFile.sfx = SFX.value;
        BinarySaveSystem.WriteToBinaryFile(savePath, saveFile);
    }

    public void Save(int levelCheckpoint)
    {
        saveFile.scene = SceneManager.GetActiveScene().buildIndex;
        saveFile.master = Master.value;
        saveFile.bgm = BGM.value;
        saveFile.sfx = SFX.value;
        saveFile.checkpoint = levelCheckpoint;
        BinarySaveSystem.WriteToBinaryFile(savePath, saveFile);
    }

    public void Save()
    {
        saveFile.master = Master.value;
        saveFile.bgm = BGM.value;
        saveFile.sfx = SFX.value;
        saveFile.checkpoint = 0;
        saveFile.deathCount = 0;
        BinarySaveSystem.WriteToBinaryFile(savePath, saveFile);
    }

    public void SaveDeathCount(int count)
    {
        saveFile.deathCount = count;
        BinarySaveSystem.WriteToBinaryFile(savePath, saveFile);
    }    
    public void Load()
    {
        saveFile = BinarySaveSystem.ReadFromBinaryFile<SaveFile>(savePath);
        //Debug.Log(savePath);
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
    public float x, y;

    public float master;
    public float bgm;
    public float sfx;
    public int checkpoint;
    public int deathCount;
}