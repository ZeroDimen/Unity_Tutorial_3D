using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Farm
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] AudioClip[] bgm_Clips;
        [SerializeField] AudioClip[] weatherClips;
        [SerializeField] AudioClip[] sfx_Clips;
        
        [SerializeField] private AudioSource[] audioSources;
        [SerializeField] private Slider[] sliders;
        [SerializeField] private GameObject[] fillAreas;
        [SerializeField] private Button[] buttons;
        
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

        private void Start()
        {
            sliders[0].onValueChanged.AddListener(OnBGMVolumeChanged);
            sliders[1].onValueChanged.AddListener(OnWeatherVolumeChanged);
            sliders[2].onValueChanged.AddListener(OnSFXVolumeChanged);
            
            buttons[0].onClick.AddListener(OnBGMMute);
            buttons[1].onClick.AddListener(OnWeatherMute);
            buttons[2].onClick.AddListener(OnSFXMute);
            
            
            for (int i = 0; i < sliders.Length; i++)
            {
                sliders[i].onValueChanged.AddListener((temp) => SfxPlay("Interact"));
            }
        }

        private void OnBGMMute()
        {
            audioSources[0].mute = !audioSources[0].mute;
            BgmMute(audioSources[0].mute, 0);
        }
    
        private void OnWeatherMute()
        {
            audioSources[1].mute = !audioSources[1].mute;
            BgmMute(audioSources[1].mute, 1);
        }
        
        private void OnSFXMute()
        {
            audioSources[2].mute = !audioSources[2].mute;
            BgmMute(audioSources[2].mute, 2);
        }
        
        
        private void OnBGMVolumeChanged(float volume)
        {
            audioSources[0].volume = volume / sliders[0].maxValue;
        }
        
        private void OnWeatherVolumeChanged(float volume)
        {
            audioSources[1].volume = volume / sliders[1].maxValue;
        }
    
        private void OnSFXVolumeChanged(float volume)
        {
            audioSources[2].volume = volume / sliders[2].maxValue;
        }
        
        public void BgmPlay(string clipName)
        {
            StartCoroutine(FadeBgmPlay(clipName, audioSources[0]));
        }
        
        public void WeatherPlay(string clipName)
        {
            StartCoroutine(FadeBgmPlay(clipName, audioSources[1]));
        }
        
        
        public void SfxPlay(string clipName) // 효과음을 출력하는 함수
        {
            foreach (var clip in sfx_Clips)
            {
                if (clip.name == clipName)
                {
                    audioSources[2].PlayOneShot(clip);
                    return;
                }
            }

            Debug.Log($"{clipName} not found");
        }
        
        
        public void BgmMute(bool isMute , int i) // 개선 가능할지도
        {
            if (isMute)
            {
                audioSources[i].mute = true;
                sliders[i].interactable = false;
                fillAreas[i].SetActive(false);
            
                buttons[i].transform.GetChild(0).gameObject.SetActive(true);
                buttons[i].transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                audioSources[i].mute = false;
                sliders[i].interactable = true;
                fillAreas[i].SetActive(true);
            
                buttons[i].transform.GetChild(0).gameObject.SetActive(false);
                buttons[i].transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        
        IEnumerator FadeBgmPlay(string clipName , AudioSource audioSource) // 배경음을 자연스럽게 바꾸는 함수
        {
            float currentVolume = audioSource.volume;
            float timer = 0f;
            float fadeDuration = 0.2f;

            while (timer < fadeDuration)
            {
                audioSource.volume = Mathf.Lerp(audioSource.volume, 0f, timer/fadeDuration);
                timer += Time.deltaTime;
                yield return null;
            }

            audioSource.volume = 0f;
            audioSource.Stop();

            foreach (var clip in bgm_Clips)
            {
                if (clip.name == clipName)
                {
                    audioSource.clip = clip;
                    break;
                }
            }
            audioSource.Play();
            timer = 0;
        
            while (timer < fadeDuration)
            {
                audioSource.volume = Mathf.Lerp(0, currentVolume, timer/fadeDuration);
                timer += Time.deltaTime;
                yield return null;
            }

            audioSource.volume = currentVolume;
        }
    }
}