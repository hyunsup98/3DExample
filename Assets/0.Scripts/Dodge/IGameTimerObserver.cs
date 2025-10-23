using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameTimerObserver
{
    public void OnNotify(int minutes, int seconds);
}