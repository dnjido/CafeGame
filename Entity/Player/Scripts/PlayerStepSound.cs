using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStepSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] _stepAudio;
    [SerializeField] private float _delay;
    private bool _canPlay = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<CharacterController>().velocity.magnitude >= .5f) PlayStep();
    }

    private void PlayStep()
    {
        if (!_canPlay) return;
        GetComponent<AudioSource>().PlayOneShot(_stepAudio[Random.Range(0, _stepAudio.Length - 1)]);
        _canPlay = false;
        StartCoroutine(AudioTimer());
    }

    private IEnumerator AudioTimer()
    {
        yield return new WaitForSeconds(_delay);
        _canPlay = true;
    }
}
