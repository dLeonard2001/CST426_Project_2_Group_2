using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBox : MonoBehaviour
{
    public Player player;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3) // layer 3 is ground
        {
            Debug.Log("I hit the ground");
            player.gravityReset();
        }
    }
}