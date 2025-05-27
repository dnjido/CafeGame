using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] _stepAudio;

    private void PlayAudio()
    {
        GetComponent<AudioSource>().PlayOneShot(_stepAudio[Random.Range(0, _stepAudio.Length - 1)]);
    }
}
