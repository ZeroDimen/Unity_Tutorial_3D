using UnityEngine;
using UnityEngine.SceneManagement;

namespace Farm
{
    public class LoadSceneManager : Singleton<LoadSceneManager>
    {
        private int sceneIndex = 0;
        public int characterIndex = 0;
        
        protected override void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // 0 : 인트로, 1 : 캐릭터 선택, 2 : 메인
        public void OnLoadScene()
        {
            sceneIndex++;
            Fade.onFadeAction(1f, Color.white, true, () => SceneManager.LoadScene(sceneIndex));
        }

        public void SetCharacterIndex(int index)
        {
            characterIndex = index;
        }

        public void OnExitScene()
        {
            
            #if UNITY_EDITOR
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
            #else
            {
                Application.Quit();
            }
            #endif  
        }
    }
}