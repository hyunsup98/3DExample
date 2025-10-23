using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameTimer : MonoBehaviour, IGameTimerObserver
{
    [SerializeField] private TMP_Text text_GameTimer;

    private void Awake()
    {
        GameManager.Instance.AddObserver(this);
    }

    private void SetTimerText(int minutes, int seconds)
    {
        text_GameTimer.text = $"<color=black>게임 시간 :</color> {string.Format("{0:D2}:{1:D2}", minutes, seconds)}";
    }

    public void OnNotify(int minutes, int seconds)
    {
        SetTimerText(minutes, seconds);
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.RemoveObserver(this);
    }
}
