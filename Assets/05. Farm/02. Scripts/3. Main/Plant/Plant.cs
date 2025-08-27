using System;
using System.Collections;
using UnityEngine;

namespace Farm
{
    public class Plant : MonoBehaviour
    {
        private enum PlantState
        {
            Level1,
            Level2,
            Level3
        }

        private PlantState plantState;

        private DateTime startTime, growthTime, harvestTime; // 레벨이 변하는 시간 설정

        public int plantIndex;
        public bool isHarvest = false;

        void Awake()
        {
            startTime = DateTime.Now;
            growthTime = startTime.AddSeconds(5);
            harvestTime = startTime.AddSeconds(10);

            // DateTime.Now : 현재 시간을 활용한 방법
            // Time.time : 게임 실행 시간
            // Time.deltTime : 시간 조각
        }

        void OnEnable()
        {
            WeatherSystem.weatherAction += SetGrowth;
        }

        void OnDisable()
        {
            WeatherSystem.weatherAction -= SetGrowth;
        }


        IEnumerator Start()
        {
            SetState(PlantState.Level1);

            while (plantState != PlantState.Level3)
            {
                if (DateTime.Now >= harvestTime)
                {
                    SetState(PlantState.Level3);
                    isHarvest = true;
                }
                else if (DateTime.Now >= growthTime)
                {
                    SetState(PlantState.Level2);
                }

                yield return new WaitForSeconds(1f);
            }
        }

        private void SetState(PlantState newState)
        {
            if (plantState != newState || plantState == PlantState.Level1)
            {
                plantState = newState;

                for (int i = 0; i < 3; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }


                transform.GetChild((int)plantState).gameObject.SetActive(true);
            }
        }

        private void SetGrowth(WeatherType weatherType) // 작물을 심고나서 작동함
        {
            switch (weatherType)
            {
                case WeatherType.Sun:
                    growthTime = startTime.AddSeconds(5 * 0.5f);
                    harvestTime = startTime.AddSeconds(10 * 0.5f);
                    Debug.Log($"SetGrowth : {weatherType}");
                    // 성장 최대
                    break;
                case WeatherType.Rain:
                    growthTime = startTime.AddSeconds(5 * 1f);
                    harvestTime = startTime.AddSeconds(10 * 1f);
                    Debug.Log($"SetGrowth : {weatherType}");
                    // 성장 중간
                    break;
                case WeatherType.Snow:
                    growthTime = startTime.AddSeconds(5 * 1.5f);
                    harvestTime = startTime.AddSeconds(10 * 1.5f);
                    Debug.Log($"SetGrowth : {weatherType}");
                    // 성장 최소
                    break;
                
            }
        }
    }
}