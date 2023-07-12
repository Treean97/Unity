using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    프로퍼티

    base 예약어

 */

public class CUnit
{
    private decimal mCurAP;

    // 프로퍼티 문법 적용 : setter, getter를 만들어주는 문법
    public decimal _CurAP
    {
        get { return mCurAP; }
        set { mCurAP = value; }
    }

    public void Doit()
    {
        Debug.Log("CUnit.Doit");
    }
}

public class CExam_5 : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        CUnit tUnit = new CUnit();

        tUnit._CurAP = 777;
        Debug.Log($"unit cur ap : {tUnit._CurAP}");

        CActor tActor = new CActor();

        tActor.DoThat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class CActor : CUnit
{
    public void DoThat()
    {
        base.Doit();        // 부모클래스의 멤버함수를 호출

        Debug.Log("CActor.DoThat");
    }

}

