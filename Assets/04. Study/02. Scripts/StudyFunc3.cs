using UnityEngine;
using System;

public class StudyFunc3 : MonoBehaviour
{
    public int hp = 100;
    public Func<int> Gethp;
    public Func<float,float> GetRemainHp;
    public Func<string> GetAction;

    private void Start()
    {
        // 현재 체력
        Gethp = () => hp;
        
        // 데미지 받은 이후의 채력
        GetRemainHp = (dmg) => hp - dmg;
        GetAction = () =>
        {
            if (Gethp() > 50)
            {
                return "공격";
            }
            else if (Gethp() > 20)
            {
                return "도망";
            }
            else
            {
                return "죽음";
            }
        };
    }
}