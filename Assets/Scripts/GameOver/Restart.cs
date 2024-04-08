using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    float time = 1.5f;
    float timer = 0;

    void Update()
    {
        if (DeathArea.isDeath)
        {
            timer += Time.deltaTime;
            if (Input.GetKey(KeyCode.R) && timer > time)
            {
                SceneManager.LoadScene(0);
                DeathArea.isDeath = false;
            }
        }
    }
}
