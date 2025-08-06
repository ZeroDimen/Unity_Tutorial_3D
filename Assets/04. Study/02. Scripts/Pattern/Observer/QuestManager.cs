using UnityEngine;


public class QuestManager : MonoBehaviour , IObserver
{
    public Subject Subject;

    private bool isQuestClear1 = false;
    private bool isQuestClear2 = false;
    private bool isQuestClear3 = false;
    private void OnEnable()
    {
        Subject.AddObserver(this);
    }

    private void OnDisable()
    {
        Subject.RemoveObserver(this);
    }



    public void Notify(int score)
    {
        if (score > 100 && !isQuestClear1)
        {
            isQuestClear1 = true;
            Debug.Log($"퀘스트 완료 : isQuestClear1");
        }
        else if (score >= 500 && !isQuestClear2)
        {
            isQuestClear2 = true;
            Debug.Log($"퀘스트 완료 : isQuestClear2");
        }
        else if (score >= 1000 && !isQuestClear3)
        {
            isQuestClear3 = true;
            Debug.Log($"퀘스트 완료 : isQuestClear3");
        }
        
    }
}