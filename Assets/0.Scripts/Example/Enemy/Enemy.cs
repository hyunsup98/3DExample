using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHp = 5;

    private int hp;
    public int Hp
    {
        get { return hp; }
        set
        {
            if (value > maxHp)
                value = maxHp;

            hp = value;

            if (hp <= 0)
                Destroy(gameObject);
        }
    }

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private Material material;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if(rigidBody == null)
            rigidBody = GetComponent<Rigidbody>();

        if(material == null)
            material = GetComponent<Material>();

        Hp = maxHp;
    }

    private void Start()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        rigidBody.velocity = speed * transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if(other.CompareTag("Bullet"))
        {
            Hp--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Player player = collision.collider.GetComponent<Player>();

            if (player == null) return;

            player.OnTakeDamage(1);
        }
    }
}
