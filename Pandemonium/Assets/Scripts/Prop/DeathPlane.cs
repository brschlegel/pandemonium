using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathPlane : MonoBehaviour
{

    TagList tagList;

    void Start()
    {
        tagList = GetComponent<TagList>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if(tagList.Count == 0){
             other.gameObject.SetActive(false);
        }
        else{
        for(int i =0; i < tagList.Count; i++)
        {
            if(other.GetComponent<TagList>().HasTag(tagList.GetAtIndex(i)))
            {
                other.gameObject.SetActive(false);
            }
        }
        }

    }
}
