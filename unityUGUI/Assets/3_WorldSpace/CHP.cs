using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 게임 오브젝트의 전방
        this.transform.forward = Camera.main.transform.forward;
    }
}
