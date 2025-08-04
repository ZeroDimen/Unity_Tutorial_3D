using UnityEngine;

public class ParentClass : MonoBehaviour
{
    public virtual void Method() // 가상함수
    {
        Debug.Log("ParentClass : Method");
    }
}
public class StudySealed : ParentClass // sealed (상속, 재정의 불가)
{
    public sealed override void Method() // 오버라이드한 함수
    {
        base.Method(); // 부모 클래스의 함수 기능을 가져오는 방법
        Debug.Log("StudySealed : Method");
    }
}

public class ChildClass : StudySealed 
{
    // public override void Method() // 오버라이드 불가
    // {
    //     
    // }
}
