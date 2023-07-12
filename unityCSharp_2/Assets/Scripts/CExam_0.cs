// Array�� ����� ����ϱ� ����
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
    Collection
        .Net Framework���� �����ϴ� �ڷᱸ��

    Collection.Generic
        .Net Framework���� �����ϴ� �Ϲ�ȭ��(Ÿ�Կ� ���ؼ� ��������) �ڷᱸ��

    Array �迭
        ��� �迭�� �Ϲ����� �θ�Ŭ����
        CLR�� �迭�� ���ؼ� ���ӵ� �޸� ������ �Ҵ��Ѵ�
        �׷��Ƿ�, �ε����� �����ϴ� �ӵ��� �ſ� ������
        ����, ĳ�����߷��� ���̹Ƿ� ������
        �׷���, �ϴ� ������ �迭�� ũ��� �����ȴ�
        �迭 ��ü�� ���� Ÿ���̴�

    List<T> �����迭
        �����߿� ���Ҹ� �߰�, ���� ������ �迭�̴�.
        �� ���� ���Ҹ� �߰�, �����ϴ� ���� ȿ�������� �̷�������� �߰��� �����ϴ� ���� �ӵ��鿡�� ��ȿ�����̴�

*/

public class CExam_0 : MonoBehaviour
{
    bool IsContain_a(string tName)
    {
        return tName.Contains("a");
        
    }

    

    // Start is called before the first frame update
    void Start()
    {
        // int[] tArray = new int[3] { 1, 2, 3 };
        int[] tArray = { 3, 1, 2 };

        // ���Ź�
        // foreach���Ź��� Object�� ������� ������� �ִ�
        // �׷��� ��Ÿ���� ����ϸ� boxing�� �Ͼ��
        // �׷��Ƿ� ������
        foreach (var t in tArray)
        {
            Debug.Log(t.ToString());
        }

        Array.Sort(tArray);

        Debug.Log("After Sort======================");

        foreach (var t in tArray)
        {
            Debug.Log(t.ToString());
        }


        string[] tNames = new string[3] { "Robert", "Jack", "Gill" };
        foreach (var t in tNames) 
        {
            Debug.Log(t);
        }



        // Array.Find �Լ�
        string tResult = Array.Find<string>(tNames, IsContain_a);
        Debug.Log($"Find {tResult}");


        // �����迭
        List<int> tInts = new List<int>();

        // �����߿� ���Ҹ� �߰� �����ϴ�
        tInts.Add(3);
        tInts.Add(2);
        tInts.Add(1);

        Debug.Log("List<int>=====================");

        foreach(var t in tInts)
        {
            Debug.Log(t.ToString());
        }

        tInts.Sort();

        Debug.Log("After Sort==========================");

        foreach (var t in tInts)
        {
            Debug.Log(t.ToString());
        }

        List<string> tJobs = new List<string>();

        tJobs.Add("knight");
        tJobs.Add("magician");

        for(int i = 0; i < tJobs.Count; i++)
        {
            Debug.Log(tJobs[i]);
        }

        tJobs.AddRange(new string[] { "paladin", "druid" });

        Debug.Log("After List AddRange=====================");

        for (int i = 0; i < tJobs.Count; i++)
        {
            Debug.Log(tJobs[i]);
        }

        tJobs.Insert(0, "fighter");

        Debug.Log("After List Insert=====================");

        for (int i = 0; i < tJobs.Count; i++)
        {
            Debug.Log(tJobs[i]);
        }


        tJobs.InsertRange(1, new string[] { "gobline", "slime" });

        Debug.Log("After List InsertRange=================");

        for (int i = 0; i < tJobs.Count; i++)
        {
            Debug.Log(tJobs[i]);
        }


        tJobs.RemoveAt(3);
        tJobs.Remove("fighter");



        Debug.Log("After List Remove=================");

        for (int i = 0; i < tJobs.Count; i++)
        {
            Debug.Log(tJobs[i]);
        }


        tJobs.RemoveRange(0, 2);    // index, count

        Debug.Log("After List RemoveRange=================");

        for (int i = 0; i < tJobs.Count; i++)
        {
            Debug.Log(tJobs[i]);
        }

        Debug.Log("ForEach======================");

        // ������ ForEach�� List<T>�� ���� ������� �ִ�. ���ɻ��� �������� ����
        // ����, ��ȸ����, ��ȸ�ϸ鼭 �ؾߵ� ���� ��������Ʈ�� �����
        // ���⼭�� ���ٸ� ����� ��������Ʈ�� �Ѱ��
        tJobs.ForEach(t => { Debug.Log(t); });

        tJobs.RemoveAll(t => t.StartsWith("p"));

        Debug.Log("After RemoveAll=================");
        tJobs.ForEach(t => { Debug.Log(t); });


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
