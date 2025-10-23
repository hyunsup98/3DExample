using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHPTopBar : MonoBehaviour, IPlayerHPObserver
{
    [SerializeField] private Image imgHpBar;
    [SerializeField] private Player target;

    private void Awake()
    {
        target.AddObserver(this);
    }

    public void OnPlayerHPChanged(float maxHp, float currentHp)
    {
        imgHpBar.fillAmount = currentHp / maxHp;
    }

    private void OnDestroy()
    {
        target.RemoveObserver(this);
    }
}
