using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEnemyTakeDamageAdapter : MonoBehaviour, ITakeDamageAdapter
{
    [SerializeField] private float defense;

    private PhysicsEnemy enemy;

    private void Start()
    {
        enemy = GetComponent<PhysicsEnemy>();

        if (enemy == null)
            gameObject.SetActive(false);
    }

    public void OnTakeDamage(float damage)
    {
        enemy?.OnTakePhysicsDamage(damage, defense);
    }
}
