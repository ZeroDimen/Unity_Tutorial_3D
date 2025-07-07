using System.Collections.Generic;
using UnityEngine;

public class Study_Dictionary : MonoBehaviour
{
   
    public Dictionary<string, int> persons = new Dictionary<string, int>();

    private void Start()
    {
        // Dictionary에 데이터 추가
        persons.Add("철수", 12);
        persons.Add("영희", 14);
        persons.Add("동수", 7);

        int age = persons["철수"]; // key 값으로 value 출력
        Debug.Log($"철수의 나이는 {age}입니다.");
        
        foreach (var person in persons)
        {
            if (person.Value == 14)
            {
                Debug.Log($"나이가 14인 사람의 이름은 {person.Key} 입니다.");
            }

            Debug.Log($"{person.Key}의 나이는 {person.Value} 입니다.");
        }
    }
}
