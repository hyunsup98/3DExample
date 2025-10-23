using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Menu,
    InGame
}

public class GameManager : Singleton<GameManager>
{
    public event Action GameStateMenu;
    public event Action GameStateInGame;

    private GameState currentGameState;
    public GameState CurrentGameState
    {
        get { return currentGameState; }
        set
        {
            if (currentGameState == value) return;

            currentGameState = value;

            if(currentGameState == GameState.Menu)
            {
                //시간 관련 세팅들 다 초기화
                ResetTimer();
                GameStateMenu?.Invoke();
            }
            else if(currentGameState == GameState.InGame)
            {
                //이미 timerCoroutine 코루틴 변수에 돌아가는 코루틴이 있으면 중지
                if (timerCoroutine != null)
                    StopCoroutine(timerCoroutine);

                timerCoroutine = StartCoroutine(GameTimer());
                GameStateInGame?.Invoke();
            }
        }
    }

    private Coroutine timerCoroutine;

    private float timer = 0;
    private int minutes = 0;
    private int seconds = 0;

    private List<IGameTimerObserver> observers = new List<IGameTimerObserver> ();
    public void AddObserver(IGameTimerObserver observer) => observers.Add(observer);
    public void RemoveObserver(IGameTimerObserver observer) => observers.Remove(observer);

    private void Start()
    {
        CurrentGameState = GameState.Menu;
    }

    private IEnumerator GameTimer()
    {
        while(CurrentGameState == GameState.InGame)
        {
            timer += Time.deltaTime;

            minutes = (int)timer / 60;
            seconds = (int)timer % 60;

            foreach (var observer in observers)
            {
                observer.OnNotify(minutes, seconds);
            }

            yield return null;
        }
    }

    private void ResetTimer()
    {
        timer = minutes = seconds = 0;

        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);
    }
}
