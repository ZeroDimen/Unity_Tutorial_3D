using System;
using UnityEngine;
using UnityEngine.UI;

namespace Farm
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject outsiderUI;
        [SerializeField] private GameObject fieldUI;
        [SerializeField] private GameObject houseUI;
        [SerializeField] private GameObject animalUI;
        [SerializeField] private GameObject seedUI;
        [SerializeField] private GameObject inventoryUI;
        
        [SerializeField] private Button seedButton;
        [SerializeField] private Button harvestButton;
        [SerializeField] private Button[] plantButtons;
        

        private void Awake()
        {
            seedButton.onClick.AddListener(OnSeedButton);
            harvestButton.onClick.AddListener(OnHarvestButton);

            for (int i = 0; i < plantButtons.Length; i++)
            {
                int j = i; // 클로저 문제 해결
                plantButtons[j].onClick.AddListener((() => Farm_GameManager.Instance.fieldManager.SetPlant(j)));
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                inventoryUI.gameObject.SetActive(!inventoryUI.activeSelf);
            }
        }

        private void OnSeedButton()
        {
            Farm_GameManager.Instance.fieldManager.SetState(FieldManager.FieldState.Seed);
            seedUI.SetActive(true);
        }
        private void OnHarvestButton()
        {
            Farm_GameManager.Instance.fieldManager.SetState(FieldManager.FieldState.Harvest);
            seedUI.SetActive(false);
        }

        public void ActivateFieldUI(bool isActive)
        {
            fieldUI.SetActive(isActive);
        }
    }
}