using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] footsteps;
    void footSound()
    {
        source.clip = footsteps[Random.Range(0, footsteps.Length)];
        source.Play();
    }
}
