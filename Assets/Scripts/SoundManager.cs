using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

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
