using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSettingMenu : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Button Button;
    [SerializeField] Canvas closeCanvas;
    private void Awake()
    {
        Button.onClick.AddListener(SetMenuActive);
    }
    void SetMenuActive()
    {
        closeCanvas.enabled = false;
        canvas.enabled = true;
    }
}
