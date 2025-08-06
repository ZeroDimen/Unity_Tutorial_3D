using System;

public static class StudyEventBus
{
    
    public static event Action OnStart;
    public static event Action <int> OnScoreChanged;

    public static void StartEvent()
    {
        OnStart?.Invoke();
    }

    public static void ScoreChange(int newScore)
    {
        OnScoreChanged?.Invoke(newScore);
    }
}
