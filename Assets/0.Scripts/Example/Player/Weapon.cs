using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;            //총알 오브젝트 풀

    [SerializeField] private Transform firePos;                //총알 발사 위치
    [SerializeField] private float shootDelay = 0.1f;          //공격 속도
    private float shootTimer = 0;

    private void Start()
    {
        if(bulletPool == null)
        {
            bulletPool = FindAnyObjectByType(typeof(BulletPool)) as BulletPool;
        }
    }

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
    /// 총알 발사 메서드
    /// </summary>
    private void Shoot()
    {
        if (bulletPool == null) return;

        var bullet = bulletPool.GetBullet();
        bullet.BulletInit(firePos.position, transform.forward, bulletPool);
    }
}
