using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererSelector : MonoBehaviour
{
    int count = 0;
    public MeshRenderer GetRenderer{
        get
        {   
            MeshRenderer mr = transform.GetChild(count).GetComponent<MeshRenderer>();
            count++;
            return mr;
        }
    }
}
