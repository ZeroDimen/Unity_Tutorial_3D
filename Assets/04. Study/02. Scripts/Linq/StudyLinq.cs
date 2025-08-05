using System.Linq;
using UnityEngine;

public class StudyLinq : MonoBehaviour
{
    // from 변수 in Collection
    // where 조건
    // select 조건을 통과한 대상

    public int[] numbers = {1,2,3,4,5};

    private void Start()
    {
        // var result = 
        //     from number in numbers 
        //     where number > 3 
        //     select number;

        // var result = numbers.Where(numbers =>  numbers > 3); // 람다 식으로 표현

        var result =
            from number in numbers
            where number % 2 == 0
            select number * number;
        

        foreach (var number in result)
        {
            Debug.Log(number);
        }
    }
}