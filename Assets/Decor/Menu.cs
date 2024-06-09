using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    
    public void Jouer()
    {
        SceneManager.LoadSceneAsync("Cinematique");
    }

    public void Quit()
    {
        Application.Quit();
    }

    
}