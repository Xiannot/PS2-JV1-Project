using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSound : MonoBehaviour
{

    public AudioSource source;
    public AudioClip clip;
    
    public void play()
    {
        source.PlayOneShot(clip);
    }
    
        
    
}
