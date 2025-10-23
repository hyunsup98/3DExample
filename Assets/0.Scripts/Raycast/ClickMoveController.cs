using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClickMoveController : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 10;
    [SerializeField] private Camera playerCamera;

    private Vector3 targetPos;
    private bool hasTarget = false;

    private Ray ray;

    private void Awake()
    {
        if (playerCamera == null)
            playerCamera = Camera.main;

        targetPos = transform.position;
    }

    private void Update()
    {
        HandleMouseInput();
        MoveToTarget();
    }

    private void HandleMouseInput()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray, out var hit, 100f, layerMask))
            {
                targetPos = hit.point;
                hasTarget = true;
            }
        }
    }

    private void MoveToTarget()
    {
        if (!hasTarget) return;

        Vector3 direction = targetPos - transform.position;
        direction.y = 0f;

        float distance = direction.sqrMagnitude;

        if(distance > 0.0025f)
        {
            //회전
            Quaternion targetRot = Quaternion.LookRotation(direction.normalized);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRot,
                rotateSpeed * Time.deltaTime);

            //이동
            Vector3 move = direction.normalized * moveSpeed * Time.deltaTime;
            if (move.sqrMagnitude > distance * distance)
                move = direction.normalized * distance;

            transform.position += move;
        }
        else
        {
            hasTarget = false;
        }
    }

    private void OnDrawGizmos()
    {
        if(hasTarget)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(targetPos + Vector3.up * 0.3f, 1f);
        }
    }
}
