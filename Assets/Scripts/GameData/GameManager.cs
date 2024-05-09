using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    private void Start()
    {
        LoadPosition();
    }

    private void Awake()
    {
        //LoadPosition();
    }

    void LoadPosition()
    {
        SaveManager.instance.Load();
        if (SaveManager.instance.saveFile.scene == SceneManager.GetActiveScene().buildIndex && !Restart.restart)
        {
            if (SaveManager.instance.saveFile.previousScene == 4 && SceneManager.GetActiveScene().buildIndex == 3)
                playerController.transform.position = new Vector2(57.22f, -19.98501f);
            else if (SaveManager.instance.saveFile.previousScene == 3 && SceneManager.GetActiveScene().buildIndex == 4)
                playerController.transform.position = new Vector2(-57.27f, -19.98503f);
            else /*if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)*/
                playerController.transform.position = SaveManager.instance.saveFile.position;

            if (SaveManager.instance.saveFile.simplePlant)
            {
                if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 4)
                {
                    GameObject.FindGameObjectWithTag("SimplePlant").GetComponent<Plant>().setOn() ;
                }
            }

            if (SaveManager.instance.saveFile.checkpoint == 1)
            {
                if (SceneManager.GetActiveScene().buildIndex == 2)
                    GameObject.FindGameObjectWithTag("Checkpoint1").GetComponent<Checkpoint1>().setOn();
                else if (SceneManager.GetActiveScene().buildIndex == 3)
                    GameObject.FindGameObjectWithTag("Checkpoint1").GetComponent<L2Checkpoint1>().setOn();
            }
            else if (SaveManager.instance.saveFile.checkpoint == 2)
            {
                if (SceneManager.GetActiveScene().buildIndex == 2)
                    GameObject.FindGameObjectWithTag("Checkpoint2").GetComponent<Checkpoint2>().setOn();
                else if (SceneManager.GetActiveScene().buildIndex == 4)
                    GameObject.FindGameObjectWithTag("Checkpoint2").GetComponent<L2Checkpoint2>().setOn();
            }
        }
        else if (SaveManager.instance.saveFile.scene == SceneManager.GetActiveScene().buildIndex && Restart.restart && SaveManager.instance.saveFile.checkpoint == 1)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                GameObject.FindGameObjectWithTag("Checkpoint1").GetComponent<Checkpoint1>().setOn();
                playerController.transform.position = GameObject.FindGameObjectWithTag("Checkpoint1").GetComponent<Checkpoint1>().transform.position;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                GameObject.FindGameObjectWithTag("Checkpoint1").GetComponent<L2Checkpoint1>().setOn();
                playerController.transform.position = GameObject.FindGameObjectWithTag("Checkpoint1").GetComponent<L2Checkpoint1>().transform.position;
            }

        }
        else if (SaveManager.instance.saveFile.scene == SceneManager.GetActiveScene().buildIndex && Restart.restart && SaveManager.instance.saveFile.checkpoint == 2)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                GameObject.FindGameObjectWithTag("Checkpoint2").GetComponent<Checkpoint2>().setOn();
                playerController.transform.position = GameObject.FindGameObjectWithTag("Checkpoint2").GetComponent<Checkpoint2>().transform.position;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                GameObject.FindGameObjectWithTag("Checkpoint2").GetComponent<L2Checkpoint2>().setOn();
                playerController.transform.position = GameObject.FindGameObjectWithTag("Checkpoint2").GetComponent<L2Checkpoint2>().transform.position;
            }
        }
    }
}
