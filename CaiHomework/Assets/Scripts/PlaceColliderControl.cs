using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceColliderControl : MonoBehaviour
{
    string placeName;
    void Start()
    {
        placeName = transform.GetChild(0).name;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            StopUIManager.instance.ReLoadPlace(placeName);
        }
    }

}
