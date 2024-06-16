using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Player;
    public GameObject GameCamera;
    public GameObject PlayerLookPos;
    public float rotateSpeed;

    void Start()
    {
        PlayerLookPos = GameObject.Find("LookPos");
        Player = GameObject.Find("Player");
        GameCamera = GameObject.Find("GameCamera");
    }

    void Update()
    {
    }

    private void LateUpdate()
    {
        transform.position = Player.transform.position;
        GameCamera.transform.position = transform.position + transform.forward * -3f + transform.up * 1.5f;

        float MouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, MouseX * rotateSpeed * Time.deltaTime, 0);
    }
}
