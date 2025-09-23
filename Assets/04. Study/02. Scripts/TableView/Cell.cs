using TMPro;
using UnityEngine;
using UnityEngine.UI;

// TableView를 구현하기위한 Cell 스크립트
namespace TableView
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text subtitleText;
        
        public int Index { get; private set; }
        
        public void SetItem(Item item, int index) // Cell 오브젝트가 사라지면 구조체도 사라짐
        {
            image.sprite = Resources.Load<Sprite>(item.imageFileName);
            titleText.text = item.title;
            subtitleText.text = item.subtitle;

            Index = index;
        }
    }
}

