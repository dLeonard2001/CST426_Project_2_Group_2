using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLookAt : EnemyLookAt
{
    public override void LookAt(Transform target)
    {
        transform.LookAt(target);

        //transform.rotation = new Quaternion(-transform.rotation.x, transform.rotation.y - 90, transform.rotation.z, transform.rotation.w);
    }
}
