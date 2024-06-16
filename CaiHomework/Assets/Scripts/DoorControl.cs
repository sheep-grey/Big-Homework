using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    Animator animator;
    public GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Player");
        animator = GetComponent<Animator>();

        animator.SetBool("isOpen", false);
    }

    void Update()
    {
        if (animator != null)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) <= 3)
            {
                animator.SetBool("isOpen", true);
            }
            else
            {
                animator.SetBool("isOpen", false);
            }
        }

    }
}
