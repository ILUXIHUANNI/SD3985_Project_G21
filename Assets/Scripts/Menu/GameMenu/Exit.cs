using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void exit()
    {
        SaveManager.instance.Save(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>());
        Restart.restart = false;
        SceneManager.LoadScene(0);
    }
}
