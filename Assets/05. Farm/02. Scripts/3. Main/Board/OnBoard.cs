using Farm.Board;
using UnityEngine;

namespace Farm
{
    public class OnBoard : MonoBehaviour
    {
        [SerializeField] private GameObject[] Button;
        [SerializeField] private GameObject[] Board;
        
        [SerializeField] private Single_BoardController s_Controller;
        [SerializeField] private BoardController a_Controller;
        private void OnEnable()
        {
            for (int i = 0; i < Button.Length; i++)
            {
                Button[i].SetActive(true);
            }
        }

        private void OnDisable() // 초기화 후 비활성화
        {
            s_Controller.StartGame();
            a_Controller.StartGame();
            
            for (int i = 0; i < Board.Length; i++)
            {
                Board[i].SetActive(false);
            }
        }
    }
}