using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKManager : MonoBehaviour
{
    public GameObject meteor;
    public GameObject platform;
    public float X;
    public float Z;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        X = platform.transform.localScale.x;
        Z = platform.transform.localScale.z;
        count += 1;
        if(count % 300 == 0)
        {
            Instantiate(meteor, new Vector3(Random.Range(-X, X + 1), 100, Random.Range(-Z, Z + 1)), Quaternion.identity);
        }
    }
}
