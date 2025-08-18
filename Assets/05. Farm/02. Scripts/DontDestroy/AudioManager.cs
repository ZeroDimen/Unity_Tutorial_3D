using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Farm
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] AudioSource bgmAudioSource;
        [SerializeField] AudioSource weatherAudioSource;
        [SerializeField] AudioSource sfxAudioSource;
        
        [SerializeField] AudioClip[] bgm_Clips;
        [SerializeField] AudioClip[] sfx_Clips;
        
        [SerializeField] private Button[] bgm_Button;
        [SerializeField] private Button[] sfx_Button;
        
        [SerializeField] private Slider bgm_Slider;
        [SerializeField] private Slider sfx_Slider;
        
        [SerializeField] private GameObject bgm_FillArea;
        [SerializeField] private GameObject sfx_FillArea;
        
        protected override void Awake()
        {
            if (instance == null)
            {
                instance = this as AudioManager;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            bgm_Slider.onValueChanged.AddListener(OnBGMVolumeChanged);
            sfx_Slider.onValueChanged.AddListener(OnSFXVolumeChanged);

            for (int i = 0; i < bgm_Button.Length; i++)
            {
                bgm_Button[i].onClick.AddListener(OnBGMMute);
                sfx_Button[i].onClick.AddListener(OnSFXMute);
            }
            
            bgm_Slider.onValueChanged.AddListener((temp) => SfxPlay("Interact"));
            sfx_Slider.onValueChanged.AddListener((temp) => SfxPlay("Interact"));
        }

        private void OnBGMMute()
        {
            bgmAudioSource.mute = !bgmAudioSource.mute;
        }
    
        private void OnSFXMute()
        {
            sfxAudioSource.mute = !sfxAudioSource.mute;
        }
        
        private void OnBGMVolumeChanged(float volume)
        {
            bgmAudioSource.volume = volume / bgm_Slider.maxValue;
        }
    
        private void OnSFXVolumeChanged(float volume)
        {
            sfxAudioSource.volume = volume / sfx_Slider.maxValue;
        }
        
        public void BgmPlay(string clipName)
        {
            StartCoroutine(FadeBgmPlay(clipName, bgmAudioSource));
        }
        
        public void WeatherPlay(string clipName)
        {
            StartCoroutine(FadeBgmPlay(clipName, weatherAudioSource));
        }
        
        
        public void SfxPlay(string clipName) // 효과음을 출력하는 함수
        {
            foreach (var clip in sfx_Clips)
            {
                if (clip.name == clipName)
                {
                    sfxAudioSource.PlayOneShot(clip);
                    return;
                }
            }

            Debug.Log($"{clipName} not found");
        }
        
        public void BgmMute(bool isMute) // 개선 가능할지도
        {
            if (isMute)
            {
                bgmAudioSource.mute = true;
                bgm_Slider.interactable = false;
                bgm_FillArea.SetActive(false);
            
                bgm_Button[0].gameObject.SetActive(true); // OFF
                bgm_Button[1].gameObject.SetActive(false); // ON
            }
            else
            {
                bgmAudioSource.mute = false;
                bgm_Slider.interactable = true;
                bgm_FillArea.SetActive(true);
            
                bgm_Button[0].gameObject.SetActive(false); // OFF
                bgm_Button[1].gameObject.SetActive(true); // ON
            }
        }

        public void SfxMute(bool isMute)
        {
            if (isMute)
            {
                sfxAudioSource.mute = true;
                sfx_Slider.interactable = false;
                sfx_FillArea.SetActive(false);
            
                sfx_Button[0].gameObject.SetActive(true); // OFF
                sfx_Button[1].gameObject.SetActive(false); // ON
            }
            else
            {
                sfxAudioSource.mute = false;
                sfx_Slider.interactable = true;
                sfx_FillArea.SetActive(true);
            
                sfx_Button[0].gameObject.SetActive(false); // OFF
                sfx_Button[1].gameObject.SetActive(true); // ON
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