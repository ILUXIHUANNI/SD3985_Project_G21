using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level22 : MonoBehaviour
{
    [SerializeField] Animator sceneTransition;
    [SerializeField] int scene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (SaveManager.instance.saveFile.L2Checkpoint2)
                SaveManager.instance.Save(2, 4);
            else
                SaveManager.instance.Save(0, 4);
            SaveManager.instance.SavePreviousScene(3);
            Restart.restart = false;
            StartCoroutine(LoadScene());
        }
    }
    IEnumerator LoadScene()
    {
        sceneTransition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
