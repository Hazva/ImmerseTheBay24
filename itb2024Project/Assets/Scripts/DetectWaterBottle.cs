using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectWaterBottle : MonoBehaviour
{
    public UnityEvent hitEvent;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Water Bottle"))
        {
            hitEvent.Invoke();
        }
    }
}
