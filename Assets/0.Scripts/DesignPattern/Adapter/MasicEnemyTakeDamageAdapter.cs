using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasicEnemyTakeDamageAdapter : MonoBehaviour, ITakeDamageAdapter
{
    [SerializeField] private float weakness;

    private MasicEnemy enemy;

    private void Start()
    {
        enemy = GetComponent<MasicEnemy>();

        if (enemy == null)
            gameObject.SetActive(false);
    }

    public void OnTakeDamage(float damage)
    {
        enemy?.OnTakeMasicDamage(damage,  weakness);
    }
}
