using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Farm
{
    public class AnimalEvent : MonoBehaviour
    {
        [SerializeField] private GameObject flag;
        private BoxCollider boxCollider;

        public static Action failAction;

        private float timer;
        private bool isTimer;
        
        private void Start()
        {
            boxCollider = GetComponent<BoxCollider>();
            failAction += SetRandomPosition;
        }

        private void Update()
        {
            if (!isTimer)
            {
                return;
            }
            timer += Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isTimer = true;
                SetRandomPosition();
                
                Farm_GameManager.Instance.uiManager.ActivateMiniMapUI(false);
                
                Farm_GameManager.Instance.SetCameraState(CameraState.Animal);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log($"깃발을 찾는데 걸린 시간 : {timer:F1}");
                isTimer = false;
                timer = 0;
                
                flag.SetActive(false);
                
                Farm_GameManager.Instance.uiManager.ActivateMiniMapUI(true);
                
                Farm_GameManager.Instance.SetCameraState(CameraState.Outside);
            }
        }

        private void SetRandomPosition()
        {
            float randomX = Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x);
            float randomZ = Random.Range(boxCollider.bounds.min.z, boxCollider.bounds.max.z);


            var randomPos = new Vector3(randomX, 0, randomZ);
            SetFlag(randomPos, true);
        }

        private void SetFlag(Vector3 pos, bool isActive)
        {
            flag.transform.SetParent(transform);
            flag.transform.position = pos;
            flag.SetActive(isActive);
        }
    }
}