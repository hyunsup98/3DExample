using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    //발행 대상이 될 구독자 리스트
    private List<IObserver> observers = new List<IObserver>();

    //구독, 해제 기능
    public void AddObserver(IObserver observer) => observers.Add(observer);
    public void RemoveObserver(IObserver observer) => observers.Remove(observer);

    private void Start()
    {
        Notify();
    }

    private void Notify()
    {
        if (observers.Count <= 0) return;


        foreach(var o in observers)
        {
            o.OnNotify();
        }
    }
}
