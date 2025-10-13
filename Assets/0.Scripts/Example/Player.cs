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
        Debug.Log($"Awake 호출");
    }

    private void Start()
    {
        Debug.Log($"Start 호출");
    }

    private void Update()
    {
        if (!isDone_Update)
        {
            isDone_Update = true;
            Debug.Log($"Update 호출");
        }
    }

    private void LateUpdate()
    {
        if (!isDone_LateUpdate)
        {
            isDone_LateUpdate = true;
            Debug.Log($"LateUpdate 호출");
        }
    }

    private void FixedUpdate()
    {
        if (!isDone_FixedUpdate)
        {
            isDone_FixedUpdate = true;
            Debug.Log($"FixedUpdate 호출");
        }
    }

    private void OnEnable()
    {
        Debug.Log($"OnEnable 호출");
    }

    private void OnDisable()
    {
        Debug.Log($"OnDisable 호출");
    }

    private void OnDestroy()
    {
        Debug.Log($"OnDesstroy 호출");
    }
}
