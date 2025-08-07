using UnityEngine;

public class LegacyPlayer
{
    public void LegacyMove(float x, float y, float z)
    {
        Debug.Log($"LegacyPlayerControl : {x}, {y}, {z}");
    }

    public void LegacyAttack()
    {
        Debug.Log($"LegacyAttack");
    }
}