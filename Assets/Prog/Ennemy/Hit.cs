using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public float bounce;
    public Rigidbody2D rb2D;

    void start()
    {

    }

    void OntriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ennemy"))
        {
            rb2D.velocity = new Vector3(rb2D.velocity.x, rb2D.velocity.y,bounce);
        }
    }
}
