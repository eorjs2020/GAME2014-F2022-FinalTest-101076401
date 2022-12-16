//CheckPoint
//LastUpdate 22_12_15
//Daekoen_Lee 101076401
//Revision History
//First modified 22_12_15
//Description - CheckPoint - SavePoint

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            FindObjectOfType<DeathPlaneController>().currentCheckPoint = transform;
        }
    }
}
