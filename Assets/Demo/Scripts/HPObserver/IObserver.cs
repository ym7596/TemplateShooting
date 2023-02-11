
public interface Subject
{
    void RegisterObserver(Observer _observer);

    void RemoveObserver(Observer _observer);

    void NotifyObservers();
}

public interface Observer
{
    void ObserverUpdate(float _myHP, float _enemyHP);
}