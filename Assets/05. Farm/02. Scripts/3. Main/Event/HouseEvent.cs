using System;
using Unity.Cinemachine;
using UnityEngine;

namespace Farm
{
    public class HouseEvent : MonoBehaviour
    {
        [SerializeField] private GameObject houseTop; // 지붕 오브젝트

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                houseTop.SetActive(false);
                Farm_GameManager.Instance.uiManager.ActivateMiniMapUI(false);
                
                Farm_GameManager.Instance.SetCameraState(CameraState.House);
            }


        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                houseTop.SetActive(false);
                Farm_GameManager.Instance.uiManager.ActivateMiniMapUI(true);
                
                Farm_GameManager.Instance.SetCameraState(CameraState.Outside);
            }
        }
    }
}
