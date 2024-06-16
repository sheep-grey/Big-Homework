using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapControl : MonoBehaviour
{
    public GameObject Player;
    public GameObject Pivot;

    void Start()
    {
        Player = GameObject.Find("Player");
        Pivot = GameObject.Find("Pivot");
    }

    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, 0, Player.transform.position.z);
        Vector3 PivotRotate = new Vector3(-90, 180, Player.transform.rotation.eulerAngles.y + 180);

        Pivot.transform.rotation = Quaternion.Euler(PivotRotate);

    }
}
