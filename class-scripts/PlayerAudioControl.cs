
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAudioControl : MonoBehaviour {

    [SerializeField] AudioSource footstepsSource;
    [SerializeField] AudioClip[] footsteps;

    int lastFootstepIndex;

    void Awake()
    {

    }

    void PlayerRandomFootstep()
    {
        var index = 0;
        while (index == lastFootstepIndex)
        {
            index = Random.Range(0, footsteps.Length);
        }
        lastFootstepIndex = index;
        PlayClip(footsteps[index]);
        Debug.Log("Playing footstep " + index);
       
    }


    void PlayClip(AudioClip clip)
    {
        if (footstepsSource.isPlaying)
            footstepsSource.Stop();
            footstepsSource.clip = clip;
            footstepsSource.Play();
        
    }
}
