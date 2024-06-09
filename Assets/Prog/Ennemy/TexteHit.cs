using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexteHit : MonoBehaviour
{

  
   
    
    private Vector3 orientation;

    public Mouvement playerMouvement;

   


    public bool interieure = false;


    
        
    

    public void inter(Collider2D collision)
    {
        if (interieure == true) 
        {

            playerMouvement.KBCounter = playerMouvement.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                playerMouvement.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                playerMouvement.KnockFromRight = false;
            }

            SpriteRenderer spriterd = gameObject.GetComponent<SpriteRenderer>();
            spriterd.sortingOrder = 4;

        }


    }
}
