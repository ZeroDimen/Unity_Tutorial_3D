using Unity.Cinemachine;
using UnityEngine;


public enum CameraState {Outside, Field, House, Animal, Board}

namespace Farm
{
    public class Farm_GameManager : Singleton<Farm_GameManager>
    {
        public UIManager uiManager;
        public FieldManager fieldManager;
        public ItemManager itemManager;
        
        public CameraState cameraState = CameraState.Outside;

        [SerializeField] private CinemachineClearShot clearShot;

        public void SetCameraState(CameraState newState)
        {
            if (cameraState != newState)
            {
                cameraState = newState;

                foreach (var camera in clearShot.ChildCameras)
                {
                    camera.Priority = 1;
                }
                clearShot.ChildCameras[(int)cameraState].Priority = 10;
            }
        }
    }
}