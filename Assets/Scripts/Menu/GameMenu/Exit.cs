using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void exit()
    {
        SaveManager.instance.Save(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>());
        SaveManager.instance.SaveBlueMode(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetBlueMode());
        SaveManager.instance.SavePreviousScene(0);
        Restart.restart = false;
        SceneManager.LoadScene(0);
    }
}
