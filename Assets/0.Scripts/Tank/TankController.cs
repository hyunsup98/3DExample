using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private Transform muzzleTransform;
    [SerializeField] private GameObject cannonBallPrefab;
    [SerializeField] private int cannonBallPoolSize = 10;

    private Rigidbody rigidBody;
    private GameObject[] cannonBallPool;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();

        cannonBallPool = new GameObject[cannonBallPoolSize];
        for(int i = 0; i < cannonBallPool.Length; i++)
        {
            cannonBallPool[i] = Instantiate(cannonBallPrefab);
            cannonBallPool[i].SetActive(false);
        }
    }

    private void Update()
    {
        MoveObject();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShotCannon();
        }
    }

    private void MoveObject()
    {
        Vector3 direction = GetNormalizedDirection();

        if (direction == Vector3.zero) return;

        SetRotateLerp(direction);
        SetFowardVelocity(moveSpeed);
    }

    private void SetRotateLerp(Vector3 direction)
    {
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation(direction),
            rotateSpeed * Time.deltaTime);
    }

    private void SetFowardVelocity(float value)
    {
        rigidBody.velocity = transform.forward * value;
    }

    private Vector3 GetNormalizedDirection()
    {
        Vector3 inputDirection = Vector3.zero;
        inputDirection.x = Input.GetAxisRaw("Horizontal");
        inputDirection.z = Input.GetAxisRaw("Vertical");

        return inputDirection.normalized;
    }

    private void ShotCannon()
    {
        foreach(var ball in cannonBallPool)
        {
            if(!ball.activeSelf)
            {
                ball.transform.position = muzzleTransform.position;
                ball.transform.rotation = Quaternion.LookRotation(muzzleTransform.forward);
                ball.SetActive(true);

                return;
            }
        }
    }
}
