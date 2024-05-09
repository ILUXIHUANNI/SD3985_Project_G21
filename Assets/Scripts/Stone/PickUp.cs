using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] SpriteRenderer pressQ;
    [SerializeField] SpriteRenderer blueMode;
    [SerializeField] SpriteRenderer threeSencond;

    private void Start()
    {
        checkIsGetBlueMode();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SaveManager.instance.SaveGetBlueMode(true);
            pressQ.enabled = true;
            blueMode.enabled = true;
            threeSencond.enabled = true;
            Destroy(this.gameObject);
        }
    }

    void checkIsGetBlueMode()
    {
        SaveManager.instance.Load();
        if (SaveManager.instance.saveFile.getBlueMode == true)
        {
            Destroy(this.gameObject);
        }
    }
}
