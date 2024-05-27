using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouvement : MonoBehaviour
{
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
        moveInput = Input.GetAxisRaw("Horizontal");

        if (jumpValue == 0.0f && isGrounded)
        {
           movement = rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
            
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 3f),
        new Vector2(3f, 0.4f), 0f, groundMask);

        if (jumpValue > 0)
        {
            rb.sharedMaterial = bounceMat;
        }
        else
        {
            rb.sharedMaterial = normalMat;
        }

        if (Input.GetKey("space") && isGrounded && canJump)
        {
            jumpValue += 0.2f;
            jumpScript.SetJump(jumpValue);
            animator.SetBool("Space", true);

        }

        if (Input.GetKeyDown("space") && isGrounded && canJump)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }

        if (jumpValue >= 40f && isGrounded)
        {
            float tempx = moveInput * walkSpeed;
            float tempy = jumpValue;
            rb.velocity = new Vector2(tempx, tempy);
            Invoke("ResetJump", 0.2f);
            animator.SetBool("Space", false);
        }

        if (Input.GetKeyUp("space"))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
                jumpValue = 0.0f;
                jumpScript.SetJump(jumpValue);
                animator.SetBool("Space", false);
            }
            canJump = true;
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
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1f), new Vector2(3f, 0.6f));
    }

    void FixedUpdate()
    {
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


}



