using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    // Start is called before the first frame update
    static public Vector3 GetRandomUnitVector(float thetaLowerBound,float thetaUpperBound,float phiLowerBound, float phiUpperBound )
    {
        float theta = Random.Range(thetaLowerBound, thetaUpperBound);
        float phi = Random.Range(phiLowerBound,phiUpperBound);
        float x = Mathf.sin(phi) * Mathf.cos(theta);
    }
}
