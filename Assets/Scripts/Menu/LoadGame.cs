using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    [SerializeField] Button button;

    private void Awake()
    {
        button.onClick.AddListener(Load);
    }
    void Load()
    {
        SaveManager.instance.Load();
        if (SaveManager.instance.saveFile.scene == 0)
        {
            Debug.Log("No exist game is found.");
        }
        else
        {
            SceneManager.LoadScene(SaveManager.instance.saveFile.scene);
        }
    }
}
