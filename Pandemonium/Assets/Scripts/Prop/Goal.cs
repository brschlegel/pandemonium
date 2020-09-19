using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ScoredEvent : UnityEvent<GameObject>
{

}

[System.Serializable]

public class EventTagMap
{
     public string tag;
    public ScoredEvent tagEvent;
   
}

public class Goal : MonoBehaviour
{
    public List<EventTagMap> eventTagMap;
    public ScoredEvent defaultEvent;
    void Start()
    {
 
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCollider")
        {
            for (int i = 0; i < eventTagMap.Count; i++)
            {
                if (other.GetComponent<TagList>().HasTag(eventTagMap[i].tag))
                {
                    eventTagMap[i].tagEvent.Invoke(other.gameObject);
                    return;
                }
            }
            //if reached here and no return, then call default
            defaultEvent.Invoke(other.gameObject);


        }


    }

}
