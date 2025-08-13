using System;
using UnityEngine;

namespace Farm
{
    public class Crop : MonoBehaviour
    {
        [SerializeField] private string name;
        public Sprite icon;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Get();
            }
        }

        public void Get()   // 인밴토리에 작물 추가
        {
            if (Farm_GameManager.Instance.itemManager.CheckItemCount())
            {
                Farm_GameManager.Instance.itemManager.GetItem(this);
                Debug.Log($"{name}을 획득하였습니다.");
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("인벤토리가 가득 찼습니다.");
            }
           
        }

        public void Use()
        {
            // 체력이나 스테미너를 회복
            // 인벤토리에서 버튼을 눌렀을 때 실행되는 기능
            Debug.Log($"{name}을 사용했습니다.");
        }
    }
}