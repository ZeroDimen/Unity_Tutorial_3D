using System;
using UnityEngine;
using UnityEngine.UI;

namespace Farm
{
    public class SettingManager : MonoBehaviour
    {
        [SerializeField] private Button settingButton;
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            // settingButton.onClick.AddListener();
        }
        
        
    }
}