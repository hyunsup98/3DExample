using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private Queue<Bullet> bullets = new Queue<Bullet>();

    [SerializeField] private Bullet bullet;

    public Bullet GetBullet()
    {
        Bullet b;

        if(bullets.Any())
        {
            //bullets 큐에 총알이 있을 경우 꺼내서 줌
            b = bullets.Dequeue();
            b.gameObject.SetActive(true);
        }
        else
        {
            //bullets 큐에 총알이 없을 경우 새로 생성
            b = Instantiate(bullet, transform);
        }

        return b;
    }

    public void TakeBullet(Bullet b)
    {
        b.gameObject.SetActive(false);
        bullets.Enqueue(b);
    }
}
