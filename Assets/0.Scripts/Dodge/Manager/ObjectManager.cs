using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectManager : Singleton<ObjectManager>
{
    [Header("총알 관련 변수")]
    [SerializeField] private Bullet bulletPrefab;           //총알 프리팹
    [SerializeField] private Transform bulletTrans;         //총알 인스턴스를 배치할 트랜스폼
    private Queue<Bullet> bullets = new Queue<Bullet>();    //생성한 총알을 담을 프리팹

    [Header("적 관련 변수")]
    [SerializeField] private Enemy enemyPrefab;             //적 프리팹
    [SerializeField] private Transform enemyTrans;          //적 인스턴스를 배치할 트랜스폼
    private Queue<Enemy> enemies = new Queue<Enemy>();      //생성한 적을 담을 프리팹

    #region 총알 관리
    public Bullet GetBullet()
    {
        return GetObject(bullets, bulletPrefab, bulletTrans);
    }

    public void TakeBullet(Bullet bullet)
    {
        TakeObject(bullets, bullet);
    }
    #endregion

    #region 적 관리
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
    /// 제네릭 오브젝트 풀 → 오브젝트 꺼내오기
    /// </summary>
    /// <typeparam name="T"> 풀 안에 넣을 오브젝트의 타입 </typeparam>
    /// <param name="queue"> 오브젝트를 꺼낼 큐 자료구조 </param>
    /// <param name="value"> 오브젝트 </param>
    /// <param name="pos"> 오브젝트를 배치할 위치(하이어라키 부모 오브젝트) </param>
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
    /// 제네릭 오브젝트 풀 → 오브젝트 담기
    /// </summary>
    /// <typeparam name="T"> 풀 안에 넣을 오브젝트의 타입 </typeparam>
    /// <param name="queue"> 오브젝트를 담을 큐 자료구조 </param>
    /// <param name="value"> 오브젝트 </param>
    public void TakeObject<T>(Queue<T> queue, T value) where T : MonoBehaviour
    {
        value.gameObject.SetActive(false);
        queue.Enqueue(value);
    }
}
