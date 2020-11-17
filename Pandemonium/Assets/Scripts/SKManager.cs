using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKManager : MonoBehaviour
{
    public GameObject meteor;
    public GameObject platform;
    public GameObject crab;
    //public float X;
    //public float Z;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //X = platform.transform.localScale.x;
        //Z = platform.transform.localScale.z;
        count += 1;
        if(count % 500 == 0)
        {
            Instantiate(meteor, new Vector3(Random.Range(-30, 68 + 1), 50, Random.Range(-22, 63 + 1)), Quaternion.identity);
        }
        if(count % 100 == 0 && count % 75 == 0)
        {
            Instantiate(crab, new Vector3(Random.Range(-30, 68 + 1), 0, Random.Range(-22, 63 + 1)), Quaternion.identity);
        }
    }
}
