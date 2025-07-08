using System.Collections.Generic;
using UnityEngine;

public class PersonData
{
    public int age;
    public string name;
    public float height;
    public float weight;

    public PersonData(int age, string name, float height, float weight)
    {
        this.age = age;
        this.name = name;
        this.height = height;
        this.weight = weight;
    }
}

public class Study_Dictionary : MonoBehaviour
{
   
    // public Dictionary<string, int> persons = new Dictionary<string, int>();
    //
    // private void Start()
    // {
    //     // Dictionary에 데이터 추가
    //     persons.Add("철수", 12);
    //     persons.Add("영희", 14);
    //     persons.Add("동수", 7);
    //
    //     int age = persons["철수"]; // key 값으로 value 출력
    //     Debug.Log($"철수의 나이는 {age}입니다.");
    //     
    //     foreach (var person in persons)
    //     {
    //         if (person.Value == 14)
    //         {
    //             Debug.Log($"나이가 14인 사람의 이름은 {person.Key} 입니다.");
    //         }
    //
    //         Debug.Log($"{person.Key}의 나이는 {person.Value} 입니다.");
    //     }
    // }
    
    public Dictionary<string , PersonData> persons = new Dictionary<string , PersonData>();

    void Start()
    {
        persons.Add("철수", new PersonData(10,"철수", 150, 30));
        persons.Add("영희", new PersonData(12,"영희", 162, 32));
        persons.Add("동수", new PersonData(14,"동수", 153, 40));

        Debug.Log(persons["철수"].age);
        Debug.Log(persons["영희"].name);
        Debug.Log(persons["동수"].height);
    }
    
}
