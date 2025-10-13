using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isDone_Update;
    private bool isDone_LateUpdate;
    private bool isDone_FixedUpdate;

    private void Awake()
    {
        Debug.Log($"Awake ȣ��");
    }

    private void Start()
    {
        Debug.Log($"Start ȣ��");
    }

    private void Update()
    {
        if (!isDone_Update)
        {
            isDone_Update = true;
            Debug.Log($"Update ȣ��");
        }
    }

    private void LateUpdate()
    {
        if (!isDone_LateUpdate)
        {
            isDone_LateUpdate = true;
            Debug.Log($"LateUpdate ȣ��");
        }
    }

    private void FixedUpdate()
    {
        if (!isDone_FixedUpdate)
        {
            isDone_FixedUpdate = true;
            Debug.Log($"FixedUpdate ȣ��");
        }
    }

    private void OnEnable()
    {
        Debug.Log($"OnEnable ȣ��");
    }

    private void OnDisable()
    {
        Debug.Log($"OnDisable ȣ��");
    }

    private void OnDestroy()
    {
        Debug.Log($"OnDesstroy ȣ��");
    }
}
