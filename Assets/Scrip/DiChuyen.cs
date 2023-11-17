using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiChuyen : MonoBehaviour
{
    public Animator animator;
    public bool isright = true;
    private Rigidbody2D rb;
    public Boolean isGrounded = false;
    public int jumpCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("attack_1", false);
        animator.SetBool("jump", false );
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("attack_1", true);
        }

        if (Input.GetKey(KeyCode.RightArrow) )
        {
            animator.SetBool("isRunning", true);
            isright = true;
            transform.Translate(Time.deltaTime * 3, 0, 0);
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            transform.localScale = scale;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("isRunning", true);
            isright = false;
            transform.Translate(-Time.deltaTime * 5, 0, 0);
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            transform.localScale = scale;
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            if (isright)
            {
                animator.SetBool("jump", true);

                rb.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
           
            }


            else
            {
                animator.SetBool("jump", true);
                rb.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
                //transform.Translate(-Time.deltaTime * 5, Time.deltaTime * 5, 0);
                Vector2 scale = transform.localScale;
                scale.x *= scale.x > 0 ? -1 : 1;
                transform.localScale = scale;

            }
            jumpCount++;
            Debug.Log(jumpCount);

            if (jumpCount == 2)
            {
                isGrounded = false;
            }
        }
      
    }
    public bool Okela()
    {
        if (isGrounded == true && jumpCount < 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("nen"))
        {
            isGrounded = true;
            jumpCount = 0;
        }



    }
}
