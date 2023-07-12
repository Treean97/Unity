using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class CPlayer : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent mAgent;

    [SerializeField]
    GameObject mTarget = null;

    [SerializeField]
    bool mIsHasPath = false;

    private void OnGUI()
    {
        GUI.color = Color.white;
        //if (GUI.Button(new Rect(0, 0, 100, 50), "Go To Target"))
        //{
        //    StartCoroutine(GoToTarget());

        //    // 목적지 정해주고 autoRepath써도 알아서 경로를 찾는듯
        //    //mAgent.destination = mTarget.transform.position;
        //    //mAgent.autoRepath = true;
        //}

        //if (GUI.Button(new Rect(0, 50, 100, 50), "Stop"))
        //{
        //    mAgent.isStopped = true;
        //}

        //if (GUI.Button(new Rect(0, 100, 100, 50), "Continue"))
        //{
        //    mAgent.isStopped = false;
        //}

        //if (GUI.Button(new Rect(0, 150, 100, 50), "Reset"))
        //{
        //    StopCoroutine(GoToTarget());

        //    this.transform.position = Vector3.up;

        //    // 목적지 초기화
        //    mAgent.ResetPath();
        //}

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(GoToTarget());

            // 목적지 정해주고 autoRepath써도 알아서 경로를 찾는듯
            //mAgent.destination = mTarget.transform.position;
            //mAgent.autoRepath = true;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            mAgent.isStopped = true;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            mAgent.isStopped = false;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            StopCoroutine(GoToTarget());

            this.transform.position = Vector3.up;

            // 목적지 초기화
            mAgent.ResetPath();
        }
    }

    void DoCalculatePath(GameObject t)
    {
        NavMeshPath tPath = new NavMeshPath();
        mAgent.CalculatePath(t.transform.position, tPath);

        if (tPath.status == NavMeshPathStatus.PathComplete)
        {
            Debug.Log("path is BE");
        }
        else if (tPath.status == NavMeshPathStatus.PathPartial)
        {
            Debug.Log("<color='blue'>path is PARTIAL</color>");

        }
        else if (tPath.status == NavMeshPathStatus.PathInvalid)
        {
            Debug.Log("<color='red'>path is NOT BE</color>");

        }
    }

    IEnumerator GoToTarget()
    {
        for (; ; )
        {
            mAgent.SetDestination(mTarget.transform.position);

            DoCalculatePath(mTarget);

            yield return new WaitForSeconds(1f);
        }

    }

}
