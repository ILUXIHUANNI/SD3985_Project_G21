using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L2DoorOpen : MonoBehaviour
{
    Animator animator;

    [SerializeField] int scene;

    [SerializeField] Animator sceneTransition;

    bool plantbool;

    bool isOpen = false;

    private void Start()
    {
        GetL2SimplePlant();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (plantbool)
            isOpen = true;
        OpenDoor(isOpen);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isOpen && Input.GetKey(KeyCode.E))
            {
                SaveManager.instance.FinishDemo();
                StartCoroutine(LoadScene());
            }
        }
    }

    void OpenDoor(bool lightOn)
    {
        if (lightOn)
        {
            animator.SetTrigger("Door Open");
        }
    }

    void GetL2SimplePlant()
    {
        SaveManager.instance.Load();
        plantbool = SaveManager.instance.saveFile.simplePlant;
    }

    IEnumerator LoadScene()
    {
        sceneTransition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
