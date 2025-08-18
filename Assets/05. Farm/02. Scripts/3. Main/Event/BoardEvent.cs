using UnityEngine;

namespace Farm
{
    public class BoardEvent : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Farm_GameManager.Instance.uiManager.ActivateBoardUI(true);
                
                Farm_GameManager.Instance.SetCameraState(CameraState.Board);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Farm_GameManager.Instance.uiManager.ActivateBoardUI(false);
                
                Farm_GameManager.Instance.SetCameraState(CameraState.House);
            }
        }
    }
}