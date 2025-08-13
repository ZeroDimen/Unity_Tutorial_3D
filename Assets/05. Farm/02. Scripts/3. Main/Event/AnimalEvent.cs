using Unity.Cinemachine;
using UnityEngine;

namespace Farm
{
    public class AnimalEvent : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Farm_GameManager.Instance.SetCameraState(CameraState.Animal);
            }


        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Farm_GameManager.Instance.SetCameraState(CameraState.Outside);
            }
        }
    }
}