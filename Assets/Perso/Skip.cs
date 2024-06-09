using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Skip : MonoBehaviour
{
    public void Jouer()
    {
        SceneManager.LoadSceneAsync("Game");
    }
}
