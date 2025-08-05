using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StudyLinq2 : MonoBehaviour
{
    public class Person // 중첩클래스
    {
        public string name;
        public int score;

        public Person(string name, int score) 
        {
            this.name = name;
            this.score = score;
        }
    }
    
    public List<Person> persons = new List<Person>();
    public int cutline = 70;

    private void Start()
    {
        persons.Add(new Person("John", 70));
        persons.Add(new Person("Jane", 72));
        persons.Add(new Person("James1", 68));
        persons.Add(new Person("James2", 56));
        persons.Add(new Person("James3", 80));
        CheckScore();
    }

    private void CheckScore()
    {
        // foreach (var person in persons)
        // {
        //     if (person.score >= cutline)
        //     {
        //         Debug.Log($"{person.name} : 합격");
        //     }
        //     else
        //     {
        //         Debug.Log($"{person.name} : 불합격");
        //     }
        // }
        
        // var passPersons = 
        //     from person in persons 
        //     where person.score >= cutline 
        //     select person;
        
        var passPersons = persons.Where(person => person.score >= cutline);
        var failPersons = persons.Except(passPersons);

        foreach (var person in passPersons)
        {
            Debug.Log($"<color=green> {person.name} </color>");
        }
        
        foreach (var person in failPersons)
        {
            Debug.Log($"<color=red> {person.name} </color>");
        }
    }
}