using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

public class DirectorAction : MonoBehaviour
{
    private PlayableDirector pd; // 감독 오브젝트
    public Camera targetCam;

    private void Start()
    {
        // Director 오브젝트가 갖고 있는 PlayableDiretor 커포넌트를 가져옴
        pd = GetComponent<PlayableDirector>();
        
        // 타임라인 실행
        pd.Play();
    }

    private void Update()
    {
        if (pd.time >= pd.duration) // 전체 시간이 끝난다면
        {
            if (Camera.main == targetCam)
            {
                targetCam.GetComponent<CinemachineBrain>().enabled = false;
            }
            targetCam.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
