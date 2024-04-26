using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSetting : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Canvas close;
    [SerializeField] Canvas open;
    void Start()
    {
        button.onClick.AddListener(OpenMusicSetting);
    }

    void OpenMusicSetting()
    {
        close.enabled = false;
        open.enabled = true;
    }
}
