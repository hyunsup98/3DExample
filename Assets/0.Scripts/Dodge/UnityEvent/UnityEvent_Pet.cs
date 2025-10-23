using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEvent_Pet : MonoBehaviour
{
    [SerializeField] private UnityEvent_Player player;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveDistance;

    private Coroutine moveCoroutine;

    private void Init()
    {
        player.onPetCalled.AddListener(MoveToPlayer);
    }

    public void MoveToPlayer()
    {
        if(moveCoroutine == null)
        {
            moveCoroutine = StartCoroutine(MoveToTarget(player.transform));
        }
    }

    private IEnumerator MoveToTarget(Transform target)
    {
        while(true)
        {
            float distance = Vector3.Distance(target.position, transform.position);

            if(distance <= moveDistance)
            {
                moveCoroutine = null;
                yield break;
            }

            transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            moveSpeed * Time.deltaTime
            );

            yield return null;
        }
    }
}
