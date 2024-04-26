using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSetting : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Canvas close;
    [SerializeField] Canvas open;
    void Start()
    {
        button.onClick.AddListener(OpenMenu);
    }

    void OpenMenu()
    {
        close.enabled = false;
        open.enabled = true;
    }

}
