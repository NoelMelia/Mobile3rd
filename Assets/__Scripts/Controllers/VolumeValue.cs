using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValue : MonoBehaviour
{
    //Reference to Audio Source component
    private AudioSource audioSource;

    //Music volume variable that willl be modified
    //by dragging the slider knob
    private float musicVolume = 1f;

    private void Start() {
        //Assign Audio Source compaonent to control it
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        //Setting volume option of Audio Source to be equal to Music Volume
        audioSource.volume = musicVolume;
    }

    //Method that is ca;;ed by the slider game object
    //This method takes vol value passed by slider 
    //and sets it as musicValue
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
