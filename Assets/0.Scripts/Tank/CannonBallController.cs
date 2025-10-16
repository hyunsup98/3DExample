using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour
{
    [SerializeField] private float deactiveTime = 5f;
    [SerializeField] private float shotForce = 3f;

    private Rigidbody rigidBody;
    private float deactCount;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CountTime();
    }

    private void CountTime()
    {
        deactCount -= Time.deltaTime;

        if(deactCount <= 0)
        {
            rigidBody.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }

    private void ActivateAction()
    {
        deactCount = deactiveTime;
        rigidBody.AddForce(transform.forward * shotForce, ForceMode.Impulse);
    }

    private void OnEnable()
    {
        ActivateAction();
    }
}
