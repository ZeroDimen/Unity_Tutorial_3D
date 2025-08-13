using Unity.Cinemachine;
using UnityEngine;

namespace Farm
{
    public class FieldEvent : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Farm_GameManager.Instance.SetCameraState(CameraState.Field);
                Farm_GameManager.Instance.uiManager.ActivateFieldUI(true);
            }


        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Farm_GameManager.Instance.SetCameraState(CameraState.Outside);
                Farm_GameManager.Instance.uiManager.ActivateFieldUI(false);
                
            }
        }
    }
}