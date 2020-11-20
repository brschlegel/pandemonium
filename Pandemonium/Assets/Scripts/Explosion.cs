using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
   
   
    private int count = 0;
    public int destructionCount;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        count += 1;
        if(count == destructionCount)
        {
            Destroy(gameObject);
        }
    }

   
}
