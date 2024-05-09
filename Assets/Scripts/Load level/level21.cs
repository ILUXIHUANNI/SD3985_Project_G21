using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level21 : MonoBehaviour
{
    [SerializeField] Animator sceneTransition;
    [SerializeField] int scene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (SaveManager.instance.saveFile.L2Checkpoint1)
                SaveManager.instance.Save(1, 3);
            else
                SaveManager.instance.Save(0, 3);
            SaveManager.instance.SavePreviousScene(4);
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
