using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Animator animator;
    Rigidbody rigidbody;

    private int UP = 0;//角色状态向前
    private int RIGHT = 90;//角色状态向右
    private int DOWN = -180;//角色状态向后
    private int LEFT = -90;//角色状态向左

    public float speed;

    public GameObject CameraParent;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        CameraParent = GameObject.Find("CameraParent");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalk", true);
            setState(UP);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isWalk", true);
            setState(DOWN);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalk", true);
            setState(RIGHT);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isWalk", true);
            setState(LEFT);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("isJump");
            rigidbody.velocity = new Vector3(0, 4f, 0);
        }


    }
    private void LateUpdate()
    {

    }

    void setState(int currState)
    {
        if (Time.deltaTime != 0)
        {
            Vector3 lateRotate = transform.rotation.eulerAngles;
            lateRotate.x = lateRotate.z = 0;
            lateRotate.y = currState + CameraParent.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(lateRotate);
        }

        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
