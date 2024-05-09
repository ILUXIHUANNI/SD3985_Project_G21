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

    public void FinishDemo()
    {
        saveFile = new SaveFile();
        Save();
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

    public void Save(int levelCheckpoint, int sceneIndex)
    {
        saveFile.scene = sceneIndex;
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
    
    public void SaveGetBlueMode(bool get)
    {
        saveFile.getBlueMode = get;
        BinarySaveSystem.WriteToBinaryFile(savePath, saveFile);
    }
    public void SaveBlueMode(bool isblueMode)
    {
        saveFile.blueMode = isblueMode;
        BinarySaveSystem.WriteToBinaryFile(savePath, saveFile);
    }

    public void SavePreviousScene(int lastScene)
    {
        saveFile.previousScene = lastScene;
        BinarySaveSystem.WriteToBinaryFile(savePath, saveFile);
    }

    public void SaveSimplePlant(bool lightOn)
    {
        saveFile.simplePlant = lightOn;
        BinarySaveSystem.WriteToBinaryFile(savePath, saveFile);
    }

    public void SaveL2Checkpoint1(bool check)
    {
        saveFile.L2Checkpoint1 = check;
        BinarySaveSystem.WriteToBinaryFile(savePath, saveFile);
    }

    public void SaveL2Checkpoint2(bool check)
    {
        saveFile.L2Checkpoint2 = check;
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
    public bool getBlueMode;
    public bool blueMode;
    public int previousScene;
    public bool simplePlant;
    public bool L2Checkpoint1;
    public bool L2Checkpoint2;
}