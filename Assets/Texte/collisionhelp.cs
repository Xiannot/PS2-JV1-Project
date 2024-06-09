using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collisionhelp : MonoBehaviour
{

    private bool isInRange;

    public Animator m_Animator;
    bool m_play;



    void Start()
    {
        
        m_Animator = gameObject.GetComponent<Animator>();
        
        m_play = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            Debug.Log("oui");
            m_Animator.SetBool("play", true);
            



        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            isInRange = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            isInRange = false;
            m_Animator.SetBool("play", false);
        }
    }
}
