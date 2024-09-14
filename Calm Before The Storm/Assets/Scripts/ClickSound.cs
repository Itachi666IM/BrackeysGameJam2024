using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip buttonClick;
    public void PlayButtonClickSound()
    {
        audioSource.PlayOneShot(buttonClick, 0.5f);
    }
}
