using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ScoredEvent : UnityEvent<GameObject>
{
    
}

public class Goal : MonoBehaviour
{

    public ScoredEvent entered;

    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MainCollider")
        {
            entered.Invoke(other.gameObject);
        }
    }

}
