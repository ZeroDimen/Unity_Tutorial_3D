using System;
using UnityEngine;

public class Study_String : MonoBehaviour
{
    public string str1 = " Hello World ";
    public string[] str2 = new string[] { "Hello", "Unity", "World" };

    private void Start()
    {
        Debug.Log(str1[0]); // H
        Debug.Log(str1[2]); // L
        
        Debug.Log(str2[0]); // Hello
        Debug.Log(str2[2]); // World

        Debug.Log(str1.Length); // 문자열의 길이 : 13
        Debug.Log(str1.Trim()); // 문자열의 앞뒤 공백 제거 : Hello World
        Debug.Log(str1.Trim()); // 문자열의 앞뒤 l 제거 : Hello World

        Debug.Log(str1.Contains("H")); // 대문자 H가 있는지
        Debug.Log(str1.ToUpper()); // 문자열 대문자로 변환
        Debug.Log(str1.ToLower()); // 문자열 소문자로 변환 
        Debug.Log(str1.Replace("World", "Unity")); // 문자열 World를 Unity로 치환
        
        string text = "Apple,Banana,Orange";
        string[] fruits = text.Split(','); // 특정 문자로 쪼개기

        foreach (var fruit in fruits)
        {
            Debug.Log(fruit);
        }
    }
}
