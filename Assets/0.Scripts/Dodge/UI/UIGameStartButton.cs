using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameStartButton : MonoBehaviour
{
    [SerializeField] private Button startButton;

    private void Start()
    {
        GameManager.Instance.GameStateMenu += ShowButton;
    }

    private void ShowButton()
    {
        startButton.gameObject.SetActive(true);
    }

    public void OnClickGameStartButton()
    {
        GameManager.Instance.CurrentGameState = GameState.InGame;
        startButton.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if(GameManager.Instance != null)
            GameManager.Instance.GameStateMenu -= ShowButton;
    }
}
