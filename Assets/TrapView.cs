using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapView : MonoBehaviour
{
    public Action OnEnter;
    public Action OnExit;
   
    private void OnTriggerExit(Collider other)
    {
        OnExit.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        OnEnter.Invoke();
    }
}
