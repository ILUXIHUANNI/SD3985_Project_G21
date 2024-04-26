using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;

    private void Start()
    {
        LoadVolume();
    }
    public void SetMaseterVolume()
    {
        float volume = masterSlider.value;
        audioMixer.SetFloat("Master", Mathf.Log10(volume)*20);
    }

    public void SetBGMVolume()
    {
        float volume = bgmSlider.value;
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    private void LoadVolume()
    {
        SaveManager.instance.Load();
        if (SaveManager.instance.saveFile.master != 0 && SaveManager.instance.saveFile.bgm != 0 && SaveManager.instance.saveFile.sfx != 0)
        {
            masterSlider.value = SaveManager.instance.saveFile.master;
            SetMaseterVolume();
            bgmSlider.value = SaveManager.instance.saveFile.bgm;
            SetBGMVolume();
            sfxSlider.value = SaveManager.instance.saveFile.sfx;
            SetSFXVolume();
        }else
        {
            SetMaseterVolume();
            SetBGMVolume();
            SetSFXVolume();
        }
    }
}
