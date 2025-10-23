using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHPBar : MonoBehaviour, IPlayerHPObserver
{
    [SerializeField] private float gap = 1.0f;
    [SerializeField] private Image imgHpBar;
    [SerializeField] private Player target;

    private Camera mainCamera;
    private Vector3 gapPos;

    private void Awake()
    {
        target.AddObserver(this);
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void Init()
    {
        if(mainCamera == null)
            mainCamera = Camera.main;

        gapPos = Vector3.forward * gap;

    }

    public void OnPlayerHPChanged(float maxHp, float currentHp)
    {
        imgHpBar.fillAmount = currentHp / maxHp;
    }

    private void MoveToTarget()
    {
        if (target == null) return;

        Vector3 movePos = target.transform.position + gapPos;
        transform.position = mainCamera.WorldToScreenPoint(movePos);
    }

    private void OnDestroy()
    {
        target.RemoveObserver(this);
    }
}
