using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform firePos;                //�Ѿ� �߻� ��ġ
    [SerializeField] private float shootDelay = 0.1f;          //���� �ӵ�
    private float shootTimer = 0;

    private void Update()
    {
        shootTimer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            if(shootTimer > shootDelay)
            {
                shootTimer = 0;
                Shoot();
            }
        }
    }

    /// <summary>
    /// �Ѿ� �߻� �޼���
    /// </summary>
    private void Shoot()
    {
        var bullet = ObjectManager.Instance.GetBullet();
        bullet.BulletInit(firePos.position, transform.forward);
    }
}
