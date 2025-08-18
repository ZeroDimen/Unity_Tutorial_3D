using System;
using System.Collections;
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

        IEnumerator Start()
        {
            while (true)
            {

                int weatherCount = Enum.GetValues(typeof(WeatherType)).Length;
                int ranIndex = Random.Range(0, weatherCount);
            
                weatherType = (WeatherType)ranIndex;
                
                foreach (var particle in weatherParticles)
                    particle.SetActive(false);
            
                weatherParticles[ranIndex].SetActive(true);
                
                AudioManager.Instance.WeatherPlay($"{weatherType}");
                Debug.Log($"현제 날씨는 {weatherType} 입니다."); // 날씨가 바뀜에 따라 식물 성장 속도?
           
                weatherAction?.Invoke(weatherType);

                yield return new WaitForSeconds(15f);
            }
        }
    }
}