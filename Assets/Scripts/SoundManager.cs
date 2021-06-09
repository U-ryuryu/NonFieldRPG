using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSourceSE;
    public AudioClip audioClip;

    void Start()
    {
    }

    public void PlaySE()
    {
        audioSourceSE.PlayOneShot(audioClip);
    }
}
