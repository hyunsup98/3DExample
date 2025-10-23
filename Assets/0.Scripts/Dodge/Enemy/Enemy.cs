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
                ObjectManager.Instance.TakeEnemy(this);
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
        else if (other.CompareTag("Bullet"))
        {
            Hp--;
        }
        else if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player == null) return;

            player.OnTakeDamage(1);
            ObjectManager.Instance.TakeEnemy(this);
        }
    }

    private void OnDisable()
    {
        Hp = maxHp;
    }
}
