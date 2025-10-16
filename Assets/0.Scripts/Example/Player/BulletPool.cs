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
            //bullets ť�� �Ѿ��� ���� ��� ������ ��
            b = bullets.Dequeue();
            b.gameObject.SetActive(true);
        }
        else
        {
            //bullets ť�� �Ѿ��� ���� ��� ���� ����
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
