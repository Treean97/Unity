using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCreateCube : MonoBehaviour
{
    [SerializeField]
    GameObject mPFCube = null;

    [SerializeField]
    List<GameObject> Cubes = null;

    // Start is called before the first frame update
    void Start()
    {
        Cubes = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Cubes.Add(Instantiate<GameObject>(mPFCube, new Vector3(Random.Range(-10, 11), 2f, 17f), Quaternion.Euler(0, 90, 0)));
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            foreach(var t in Cubes)
            {
                Destroy(t.gameObject);
            }
        }
    }
}
