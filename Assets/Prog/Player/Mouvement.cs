using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class Mouvement : MonoBehaviour
{

    public AudioSource source;
    public AudioClip clip;


    public int playerId = 0;
    private Player player;

    public float walkSpeed;
    private float moveInput;
    public bool isGrounded;
    private Rigidbody2D rb;
    public LayerMask groundMask;

    public PhysicsMaterial2D bounceMat, normalMat;
    public bool canJump = true;
    public float jumpValue = 0.0f;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;

    public Animator animator;

    public float minJump = 0f;
    public float currentJump;
    private JumpScript jumpScript;

    Vector3 movement;



    void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
    }


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        jumpScript = FindObjectOfType<JumpScript>();

        minJump = 0f;
        currentJump = minJump;
        jumpScript.SetJumpMin(minJump);


    }

    public void JumpPlayer(float amount)
    {
        if ((currentJump + amount) > minJump)
        {
            currentJump = minJump;
        }
        else
        {
            currentJump += amount;
        }
        jumpScript.SetJump(currentJump);
    }



    void Update()
    {

        moveInput = player.GetAxisRaw("Horizontal");


        if (jumpValue > 0)
        {
            rb.sharedMaterial = bounceMat;
        }
        else
        {
            rb.sharedMaterial = normalMat;
        }


        if (player.GetButtonDown("space") && isGrounded && canJump)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
            
        }


        if (player.GetButtonUp("space"))
        {
            source.PlayOneShot(clip);
            if (isGrounded)
            {
                rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
                jumpValue = 0.0f;
                jumpScript.SetJump(jumpValue);
                animator.SetBool("Space", false);
            }
            canJump = true;
        }

        if (player.GetButtonDown("space") && isGrounded && canJump)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);   
        }

        if (player.GetButton("space") && isGrounded && canJump)
        {
            
            jumpScript.SetJump(jumpValue);
            animator.SetBool("Space", true);

        }

        if (jumpValue == 0.0f && isGrounded)
        {
            movement = rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);

        }
    }

    void FixedUpdate()
    {

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.9f),
        new Vector2(3f, 0.4f), 0f, groundMask);

        

        if (player.GetButton("space") && isGrounded && canJump)
        {
            jumpValue += 0.4f;  
            jumpScript.SetJump(jumpValue);
            animator.SetBool("Space", true);

        }



        if (jumpValue >= 25f && isGrounded)
        {
            float tempx = moveInput * walkSpeed;
            float tempy = jumpValue;
            rb.velocity = new Vector2(tempx, tempy);
            Invoke("ResetJump", 0.1f);
            animator.SetBool("Space", false);
        }

        

        if (KBCounter <= 0)
        {
            
        }
        else
        {
            if (KnockFromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KnockFromRight == false)
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }

            KBCounter -= Time.deltaTime;
        }
    }

    void ResetJump()
    {
        canJump = false;
        jumpValue = 0;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.9f), new Vector2(3f, 0.6f));
    }

    //void FixedUpdate()
   // {
    //    if (KBCounter <= 0)
    //    {
            
   //     }
    //    else
   //     {
      //      if (KnockFromRight == true)
      //      {
       //         rb.velocity = new Vector2(-KBForce, KBForce);
       //     }
        //    if (KnockFromRight == false)
        //    {
          //      rb.velocity = new Vector2(KBForce, KBForce);
          //  }

          //  KBCounter -= Time.deltaTime;
        //}
  //  }


}



