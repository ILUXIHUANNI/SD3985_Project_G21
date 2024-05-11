using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------Audio Source---------")]
    [SerializeField] AudioSource audioSourceBGM;
    [SerializeField] AudioSource audioSourceSFX;

    [Header("---------Audio Clip---------")]
    //public List<AudioClip> audioClipFootStep;
    public AudioClip audioClipBGM;
    public AudioClip playerDeath;
    public AudioClip monsterDeath;
    public AudioClip checkpoint;
    public AudioClip arrowShoot;
    public AudioClip arrowHit;
    public AudioClip powerDown;
    public AudioClip changeMode;
    public AudioClip blockArrow;

    private void Start()
    {
        audioSourceBGM.clip = audioClipBGM;
        audioSourceBGM.Play();
    }

    public void PlaySFX(AudioClip sfx)
    {
        audioSourceSFX.PlayOneShot(sfx);
    }

}
