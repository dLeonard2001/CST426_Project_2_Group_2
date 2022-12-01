using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventHandler
{
    public static Action PlayerGetHit;
    public static void CallPlayerGetHit()
    {
        PlayerGetHit?.Invoke();
    }
}
