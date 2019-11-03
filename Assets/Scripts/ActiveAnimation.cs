using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAnimation : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Active", true);
        }   
    }
}
