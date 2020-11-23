using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundColliderScript : MonoBehaviour
{
    public UnityEvent<Collider> groundCollision;
    void OnTriggerStay(Collider other)
    {
        groundCollision.Invoke(other);
    }
}
