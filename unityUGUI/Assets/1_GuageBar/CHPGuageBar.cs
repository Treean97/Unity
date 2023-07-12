using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHPGuageBar : MonoBehaviour
{
    public float mMaxHP = 500.0f;
    public float mCurHP = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Slider>().maxValue = mMaxHP;

        this.mCurHP = 50.0f;

        this.GetComponent<Slider>().value = mCurHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
