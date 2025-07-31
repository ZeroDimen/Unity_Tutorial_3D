using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Emitters : MonoBehaviour
{
    public PlayableDirector timeline;
    public SignalReceiver receiver;
    public SignalAsset signal;

    private void Start()
    {
        SetSignalEvent();
    }

    public void OnTimelineSpeed(float speed)
    {
        // 타임라인 속도제어
        timeline.playableGraph.GetRootPlayable(0).SetSpeed(speed);
    }

    public void SetSignalEvent() // 시그널에 이벤트를 등록하는 함수
    {
        UnityEvent eventContainer = new UnityEvent(); // 이벤트를 담는 변수
        
        eventContainer.AddListener(() =>
        {
            Debug.Log("이벤트 등록");
            OnTimelineSpeed(0.2f);
            Debug.Log("Timeline 0.2 속도 설정");
        });
        receiver.AddReaction(signal, eventContainer); // Signal에 Event 연결
    }
}
