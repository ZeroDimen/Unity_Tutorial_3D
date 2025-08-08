using UnityEngine;

public abstract class Pizza // MonoBehaviour 상속시 Null로 리턴되는 이슈 있음
{
    public string Name { get; }
    public string Sauce { get; }
}
