using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 30f;          //�Ѿ� �ӵ�

    private BulletPool pool;

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        //���� ���� forward �������� �̵�
        transform.Translate(speed * Time.deltaTime * transform.forward);
    }

    public void BulletInit(Vector3 position, Vector3 direction_Forward, BulletPool pool)
    {
        transform.position = position;
        transform.forward = direction_Forward;
        this.pool = pool;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall") || other.CompareTag("Enemy"))
        {
            pool.TakeBullet(this);
        }
    }
}
