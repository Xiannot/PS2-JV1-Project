using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAH : MonoBehaviour
{

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("oui");
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("caca");
            }
        }
    }
}