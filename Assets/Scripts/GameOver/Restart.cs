using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    float time = 1.5f;
    float timer = 0;

    public static bool restart;

    void Update()
    {
        if (DeathArea.isDeath)
        {
            timer += Time.deltaTime;
            if (Input.GetKey(KeyCode.R) && timer > time)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                DeathArea.isDeath = false;
                restart = true;
            }
        }
    }

    public bool isRestart()
    {
        return restart;
    }
}
