using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public enum WeatherType
{
    Sun, Rain, Snow
}

namespace Farm
{
    public class WeatherSystem : MonoBehaviour
    {
        public WeatherType weatherType;

        public static event Action<WeatherType> weatherAction;

        [SerializeField] private GameObject[] weatherParticles;
        [SerializeField] private TextMeshProUGUI WeatherUI;
        [SerializeField] private TextMeshProUGUI WeatherEffectUI;
        private string effect;

        
        IEnumerator Start()
        {
            while (true)
            {

                int weatherCount = Enum.GetValues(typeof(WeatherType)).Length;
                int ranIndex = Random.Range(0, weatherCount);
                
                
                if (weatherType != (WeatherType)ranIndex)
                {
                    weatherType = (WeatherType)ranIndex;
                    
                    foreach (var particle in weatherParticles)
                        particle.SetActive(false);
            
                    weatherParticles[ranIndex].SetActive(true);
                }
                
                
                AudioManager.Instance.WeatherPlay($"{weatherType}");
                WeatherUI.text = $"현제 날씨 : {weatherType}";

                switch (weatherType)
                {
                    case WeatherType.Sun:
                        effect = "성장 속도 x 1.5";
                        break;
                    case WeatherType.Rain:
                        effect = "성장 속도 x 1.0";
                        break;
                    case WeatherType.Snow:
                        effect = "성장 속도 x 0.5";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                WeatherEffectUI.text = $"효과 : {effect}";
                Debug.Log($"현제 날씨는 {weatherType} 입니다."); // 날씨가 바뀜에 따라 식물 성장 속도?
           
                weatherAction?.Invoke(weatherType);

                yield return new WaitForSeconds(15f);
            }
        }
    }
}