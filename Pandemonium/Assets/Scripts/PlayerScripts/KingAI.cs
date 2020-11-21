using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingAI : MonoBehaviour
{
    BasicMovement bm;
    Vector2 centerBias;
    public float centerWeight;
    Vector2 gradientAscent;
    
    public float gradientWeight;

    Vector2 normalNoise;

    float previousTheta;
    float sigma;

    public float normalWeight;
    void Awake()
    {
        bm = transform.GetComponent<BasicMovement>();
        previousTheta = 0;
        centerWeight = .2f;
        gradientWeight = .6f;
        normalWeight = .2f;
        previousTheta = 0;
        sigma = .1f;

    }

    float GenerateNormalNoise(float sigma, float  mu)
    {
        float num1 = Random.value;
        float num2 = Random.value;

       
        float z = Mathf.Sqrt(-2 * Mathf.Log(num1)) * Mathf.Cos(2*Mathf.PI * num2);
        return z * sigma + mu;
    }

    void FixedUpdate(){
        Vector3 temp = gradientWeight * Terrain.activeTerrain.terrainData.GetInterpolatedNormal(transform.position.x/ Terrain.activeTerrain.terrainData.size.x,transform.position.z/Terrain.activeTerrain.terrainData.size.z);
        gradientAscent = new Vector3(-temp.z, temp.x);
        float theta = GenerateNormalNoise(sigma, previousTheta);
        previousTheta = theta;
        normalNoise = normalWeight * (new Vector2(Mathf.Cos(theta), Mathf.Cos(theta)));
        centerBias = -centerWeight * (new Vector2(transform.position.x, transform.position.z));
        bm.movementDirection = (-gradientAscent + normalNoise + centerBias).normalized;
        bm.Moving();

        
    }
}
