using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] TMP_Text _textMeshPro;

    float time = 1.5f;
    float timer = 0;

    public static bool restart;

    void Update()
    {
        isDie();
    }

    void isDie()
    {
        if (DeathArea.isDeath)
        {
            int death = int.Parse(_textMeshPro.text);
            timer += Time.deltaTime;
            if (Input.GetKey(KeyCode.R) && timer > time)
            {
                death += 1;
                _textMeshPro.text = death.ToString();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                DeathArea.isDeath = false;
                restart = true;
                SaveManager.instance.SaveDeathCount(death);
            }
        }
    }

    public bool isRestart()
    {
        return restart;
    }
}
