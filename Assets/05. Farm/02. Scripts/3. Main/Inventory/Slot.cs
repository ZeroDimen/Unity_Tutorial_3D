using System;
using UnityEngine;
using UnityEngine.UI;

namespace Farm.Inventory
{
    public class Slot : MonoBehaviour
    {
        private Crop crop; // 슬롯에 들어올 아이템
        [SerializeField] private Image slotImage;
        [SerializeField] private Button slotButton; 
        
        public bool isEmpty = true;

        private void Awake()
        {
            slotButton.onClick.AddListener(UseCrop);
        }

        private void OnEnable()
        {
            slotImage.gameObject.SetActive(!isEmpty);
            slotButton.interactable = !isEmpty;
        }

        public void AddCrop(Crop crop)
        {
            isEmpty = false;
            
            this.crop = crop;
            slotImage.sprite = crop.icon;
            AudioManager.Instance.SfxPlay("CropsGet");
        }
        
        private void UseCrop()
        {
            if (crop != null)
            {
                crop.Use();
                isEmpty = true;
                slotButton.interactable = false;
                slotImage.gameObject.SetActive(false);
                Farm_GameManager.Instance.itemManager.UseItem();
                
                AudioManager.Instance.SfxPlay("Eat");
            }
        }
    }
}