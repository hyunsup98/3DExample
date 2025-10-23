using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    //���� ����� �� ������ ����Ʈ
    private List<IObserver> observers = new List<IObserver>();

    //����, ���� ���
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
