using System.Collections.Generic;

public interface ISubject
{
    List<IObserver> Observers
    {
        get;
        set;
    }
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}