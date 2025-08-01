using System;
using UnityEngine;

public class StudyParameter : MonoBehaviour
{
    public int number = 1;
    public int number2 = 0;

    
    public GameObject player;
    public GameObject enemy;
    public GameObject item;
    private void Start()
    {
        // NormalParameter(2);
        // Debug.Log(number);
        //
        // DefaultParameter();
        // Debug.Log(number);
        //
        // NormalParameter(5);
        // Debug.Log(number);
        //
        // ReferenceParameter(ref number);
        // Debug.Log($"Call By Ref : {number}");
        //
        //
        // OutParameter(out number, out number2);
        
        // OverloadingMethod();
        // OverloadingMethod(5);
        // OverloadingMethod(7, "nins");
        int[] intArray = new int[3] { 10, 20, 30 };
        
        ArrayParameter(intArray);
        ParamsParameter(10, 20, 30, 40, 50);

        ParamsParameters(player, enemy, item);
    }

    private void NormalParameter(int num) // 일반적인 매개변수 -> Call By Value
    {
        num = 10;
    }

    private void DefaultParameter(int num = 3) // 선택적 매개변수 (default 매개변수)
    {
        number = num;
    }

    private void ReferenceParameter(ref int num) // 참조 방식의 매개변수 -> Call By Reference (원본 수정)
    {
        num = 20;
    }

    private void OutParameter(out int num , out int num2) // 반환, 초기화 하지않아도 사용 가능
    {
        num = 10;
        num2 = 20;
    }

    private void ArrayParameter(int[] numbers) // Collection을 매개변수로 넣은 경우
    {
        foreach (var n in numbers)
        {
            Debug.Log(n);
        }
    }

    private void ParamsParameter(params int[] numbers) // params를 활용한 매개변수
    {
        foreach (var n in numbers)
        {
            Debug.Log(n);
        }
    }

    private void ParamsParameters(params GameObject[] objs)
    {
        foreach (var o in objs)
        {
            o.SetActive(false);
        }
    }

    #region 오버로딩 : 매개변수를 다르게 해서 다른 기능을 구현하는 방법
    
    private void OverloadingMethod()
    {
        Debug.Log($"OverloadingMethod : ");
    }
    private void OverloadingMethod(int num)
    {
        Debug.Log($"OverloadingMethod : {num}");
    }
    private void OverloadingMethod(int num, string str)
    {
        Debug.Log($"OverloadingMethod : {num} : {str}");
    }

    #endregion
    
}
