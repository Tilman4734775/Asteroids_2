using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    [SerializeField] AudioSource SFXsource;

    public AudioClip shoot;
    public AudioClip meteordestroy;
    public AudioClip death;

    public void PlaySound(AudioClip sound)
    {
        SFXsource.PlayOneShot(sound);
    }

}