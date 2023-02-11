using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSub : MonoBehaviour, Subject
{
    private List<Observer> observers = new List<Observer>();

    private float _playerHP = 0f;
    private float _enemyHP = 0f;
    public void NotifyObservers()
    {
        int observersCount = observers.Count;
       for (int i = 0; i < observersCount; i++)
        {
            observers[i].ObserverUpdate(_playerHP, _enemyHP);
        }
    }

    public void RegisterObserver(Observer _observer)
    {
        observers.Add(_observer);
    }

    public void RemoveObserver(Observer _observer)
    {
        observers.Remove(_observer);
    }

    public void ChangeHP(float _playerHP, float _enemyHP)
    {
        this._playerHP = _playerHP;
        this._enemyHP = _enemyHP;
        NotifyObservers();
    }
}
