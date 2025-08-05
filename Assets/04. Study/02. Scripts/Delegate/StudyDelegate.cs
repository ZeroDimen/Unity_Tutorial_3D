#region Delegates

// public class StudyDelegate : MonoBehaviour
// {
//     // Delegate : 대리자
//     // 함수 참조 역할
//     
//     // 접근 제한자 delegate 반환타입 변수명 (매개변수)
//     public delegate void MyDelegate(int n = 5);
//     public MyDelegate myDelegate;
//
//     private void Start()
//     {
//         // 옛날 방식의 델리게이트 할당
//         // myDelegate = new MyDelegate(MethodA);
//         
//         // 표준 방식의 할당
//         myDelegate = MethodA;
//         
//         myDelegate += MethodB;
//         myDelegate += MethodC;
//
//         myDelegate -= MethodB;
//         
//         // 델리게이트 호출
//         // myDelegate();
//         myDelegate?.Invoke(14); // 할당 되었을때만 호출 (null 확인)
//         myDelegate?.Invoke(); // 사용가능 5
//         
//     }
//
//     private void MethodA(int a)
//     {
//         Debug.Log($"Method_A : {a}");
//     }
//     private void MethodB(int b)
//     {
//         Debug.Log($"Method_B : {b}");
//     }
//     private void MethodC(int c)
//     {
//         Debug.Log($"Method_C : {c}");
//     }
// }


// public class StudyDelegate : MonoBehaviour
// {
//     public delegate void MyDelegate();
//     public static MyDelegate myDelegate;
//
//     public KeyCode KeyCode = KeyCode.Space;
//
//     public float timer;
//     public bool isTimer = true;
//
//     private void Start()
//     {
//         myDelegate = Respond;
//         myDelegate += StopTimer;
//         myDelegate += StopBomb;
//     }
//
//     private void Update()
//     {
//         if (isTimer)
//         {
//             timer += Time.deltaTime;
//         }
//
//         if (Input.GetKeyDown(KeyCode))
//         {
//             myDelegate?.Invoke();
//         }
//     }
//
//     private void Respond()
//     {
//         Debug.Log("키가 눌렸습니다.");
//     }
//
//     private void StopTimer()
//     {
//         isTimer  = false;
//         Debug.Log("타이머 정지");
//     }
//
//     private void StopBomb()
//     {
//         Debug.Log("폭탄 기능 정지");
//     }
// }
#endregion

using System;
using UnityEngine;

public class StudyDelegate : MonoBehaviour
{
   public delegate void TimerStart();
   public TimerStart onTimerStart;
   
   public delegate void TimerEnd();
   public TimerEnd onTimerEnd;

   public float timer = 3f;
   public bool istimer = true;

   private void OnEnable()
   {
      onTimerStart += StartEvent;
      onTimerEnd += EndEvent;
   }

   private void OnDisable()
   {
      onTimerStart -= StartEvent;
      onTimerEnd -= EndEvent;
   }

   private void Start()
   {
      onTimerStart?.Invoke();
   }

   private void Update()
   {
      if (!istimer)
      {
         return;
      }
      
      timer -= Time.deltaTime;
      if (timer <= 0)
      {
         onTimerEnd?.Invoke();
      }
   }

   private void StartEvent()
   {
      Debug.Log("타이머 시작");
   }
   
   private void EndEvent()
   {
      Debug.Log("타이머 종료");
   }
}