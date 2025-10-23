using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectManager : Singleton<ObjectManager>
{
    [Header("�Ѿ� ���� ����")]
    [SerializeField] private Bullet bulletPrefab;           //�Ѿ� ������
    [SerializeField] private Transform bulletTrans;         //�Ѿ� �ν��Ͻ��� ��ġ�� Ʈ������
    private Queue<Bullet> bullets = new Queue<Bullet>();    //������ �Ѿ��� ���� ������

    [Header("�� ���� ����")]
    [SerializeField] private Enemy enemyPrefab;             //�� ������
    [SerializeField] private Transform enemyTrans;          //�� �ν��Ͻ��� ��ġ�� Ʈ������
    private Queue<Enemy> enemies = new Queue<Enemy>();      //������ ���� ���� ������

    #region �Ѿ� ����
    public Bullet GetBullet()
    {
        return GetObject(bullets, bulletPrefab, bulletTrans);
    }

    public void TakeBullet(Bullet bullet)
    {
        TakeObject(bullets, bullet);
    }
    #endregion

    #region �� ����
    public Enemy GetEnemy()
    {
        return GetObject(enemies, enemyPrefab, enemyTrans);
    }

    public void TakeEnemy(Enemy enemy)
    {
        TakeObject(enemies, enemy);
    }
    #endregion

    /// <summary>
    /// ���׸� ������Ʈ Ǯ �� ������Ʈ ��������
    /// </summary>
    /// <typeparam name="T"> Ǯ �ȿ� ���� ������Ʈ�� Ÿ�� </typeparam>
    /// <param name="queue"> ������Ʈ�� ���� ť �ڷᱸ�� </param>
    /// <param name="value"> ������Ʈ </param>
    /// <param name="pos"> ������Ʈ�� ��ġ�� ��ġ(���̾��Ű �θ� ������Ʈ) </param>
    /// <returns></returns>
    public T GetObject<T>(Queue<T> queue, T value, Transform pos) where T : MonoBehaviour
    {
        if (queue == null || value == null || pos == null) return null;

        T obj;

        if(queue.Any())
        {
            obj = queue.Dequeue();
            obj.gameObject.SetActive(true);
        }
        else
        {
            obj = Instantiate(value, pos);
        }

        return obj;
    }

    /// <summary>
    /// ���׸� ������Ʈ Ǯ �� ������Ʈ ���
    /// </summary>
    /// <typeparam name="T"> Ǯ �ȿ� ���� ������Ʈ�� Ÿ�� </typeparam>
    /// <param name="queue"> ������Ʈ�� ���� ť �ڷᱸ�� </param>
    /// <param name="value"> ������Ʈ </param>
    public void TakeObject<T>(Queue<T> queue, T value) where T : MonoBehaviour
    {
        value.gameObject.SetActive(false);
        queue.Enqueue(value);
    }
}
