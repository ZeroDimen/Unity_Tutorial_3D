using UnityEngine;
using UnityEngine.UI;

public class StudyLambda : MonoBehaviour
{
    public delegate void MyDelegate(string s);
    public  MyDelegate myDelegate;

    public Button button;
    void Start()
    {
        // myDelegate += OnLog;

        // myDelegate += delegate (string s) // 익명 함수
        // {
        //     OnLog(s);
        //     OnLog(s);
        //     OnLog(s);
        //     transform.position = Vector3.zero;
        // };
        
        myDelegate += (string s) => // 익명 함수
        {
            OnLog(s);
            OnLog(s);
            OnLog(s);
            transform.position = Vector3.zero;
        };
        myDelegate?.Invoke("delegate Lambda");
        button.onClick.AddListener(() =>
        {
            OnLog("button.onClick");
        });
    }
    
    private void OnLog(string s)
    {
        Debug.Log($"Hello Unity :  {s}");
    }
}