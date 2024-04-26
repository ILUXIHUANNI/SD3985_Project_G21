using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGameMenu : MonoBehaviour
{
    [SerializeField] Canvas menuCanvasComponent;

    [SerializeField] KeyCode toggleKey = KeyCode.Escape;

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            if (menuCanvasComponent.enabled)
            {
                //off
                SetMenuActive(false);
            }
            else
            {
                //on
                SetMenuActive(true);

            }
        }
    }

    /// <summary>
    /// Sets the menu canvas component enabled value equal to active.
    /// </summary>
    /// <param name="active"></param>
    private void SetMenuActive(bool active)
    {
        if (active)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().setSpeed(0);
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().setSpeed(7);
        }
        menuCanvasComponent.enabled = active;
    }

}
