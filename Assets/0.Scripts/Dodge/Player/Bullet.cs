using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 30f;          //총알 속도

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        //로컬 기준 forward 방향으로 이동
        transform.Translate(speed * Time.deltaTime * transform.forward);
    }

    public void BulletInit(Vector3 position, Vector3 direction_Forward)
    {
        transform.position = position;
        transform.forward = direction_Forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall") || other.CompareTag("Enemy"))
        {
            ObjectManager.Instance.TakeBullet(this);
        }
    }
}
