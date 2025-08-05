using System;
using System.Collections;
using UnityEngine;

public class SwingController : MonoBehaviour
{
    private Animator anim;
    
    public Action onStartSwing;
    public Action onEndSwing;
    
    private bool isSwing;

    void Start()
    {
        anim = GetComponent<Animator>();
        
        onStartSwing += SwingStart;
        onEndSwing += SwingEnd;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isSwing)
            {
                StartCoroutine(SwingRoutine(onStartSwing, onEndSwing));
            }
        }
    }

    public IEnumerator SwingRoutine(Action aciton1, Action action2)
    {
        isSwing = true;
        anim.SetTrigger("Swing");
        aciton1?.Invoke();

        // float animLength = anim.GetCurrentAnimatorClipInfo(0).Length;
        // float animLength2 = anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(0.5f);
        
        action2?.Invoke();
        isSwing = false;
    }

    private void SwingStart()
    {
        Debug.Log("스윙 시작");
    }

    private void SwingEnd()
    {
        Debug.Log("스윙 종료");
    }
}