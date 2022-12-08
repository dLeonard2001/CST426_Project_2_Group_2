using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLookAt : EnemyLookAt
{
    public override void LookAt(Vector3 target)
    {
        if (target != Vector3.zero)
        {

            Quaternion rotation = Quaternion.LookRotation(target, Vector3.up);
            transform.rotation = rotation;
        }
        //transform.rotation = new Quaternion(-transform.rotation.x, transform.rotation.y - 90, transform.rotation.z, transform.rotation.w);
    }
}
