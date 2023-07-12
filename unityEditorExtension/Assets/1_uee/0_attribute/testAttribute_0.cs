using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유니티에서 제공하는 attribute 몇가지를 살펴보자

public class testAttribute_0 : MonoBehaviour
{
    [Range(1, 10)]
    public int mNumber_0 = 1;

    [Range(1, 10)]
    public float mNumber_1 = 1.0f;

    [Range(1, 10)]
    public double mNumber_2 = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
