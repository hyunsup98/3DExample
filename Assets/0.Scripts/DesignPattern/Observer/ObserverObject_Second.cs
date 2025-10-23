using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverObject_Second : MonoBehaviour, IObserver
{
    [SerializeField] private Subject subject;

    private void Awake()
    {
        subject.AddObserver(this);
    }

    private void OnDestroy()
    {
        subject.RemoveObserver(this);
    }

    public void OnNotify()
    {
        Debug.Log("Second Observer");
    }
}
