using UnityEngine;

// The Audio Source component has an AudioClip option.  The audio
// played in this example comes from AudioClip and is called audioData.

[RequireComponent(typeof(AudioSource))]
public class ExampleScript : MonoBehaviour
{
    public AudioSource audioData;

    void JouerLeson()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        Debug.Log("started");
    }

  
}