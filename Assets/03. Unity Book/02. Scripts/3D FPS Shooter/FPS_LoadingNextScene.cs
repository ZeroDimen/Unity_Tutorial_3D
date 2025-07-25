using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FPS_LoadingNextScene : MonoBehaviour
{
    public int sceneNumber = 2;
    public Slider loadingBar;
    public Text loadingText;

    private void Start()
    {
        StartCoroutine(TransitionNextScene(sceneNumber));
    }

    IEnumerator TransitionNextScene(int num)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(num); // 지정된 씬을 비동기 형식으로 로드
        ao.allowSceneActivation = false; // 로드되는 씬의 모습이 화면에 보이지 않게 함

        while (!ao.isDone)
        {
            // 로딩 진행률을 슬라이더 바와 텍스트로 표시
            loadingBar.value = ao.progress;
            loadingText.text = (ao.progress * 100f).ToString() + "%";
            if (ao.progress >= 0.9f)
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
