using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxHp = 3;

    private float currentHp;
    public float CurrentHp
    {
        get { return currentHp; }
        set
        {
            if (value > maxHp)
                value = maxHp;

            currentHp = value;

            if(value <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }


    private float inputX;
    private float inputY;

    [Header("플레이어 관련 변수")]
    [SerializeField] private float moveSpeed;

    [SerializeField] private Collider col;      //플레이어 콜라이더
    private float playerHorizonHalfSize;        //플레이어 가로 절반 사이즈
    private float playerVerticalHalfSize;       //플레이어 세로 절반 사이즈

    private Vector3 cameraMinPos;               //카메라 화면의 왼쪽 아래 모서리 좌표
    private Vector3 cameraMaxPos;               //카메라 화면의 오른쪽 위 모서리 좌표

    private Camera cam;                         //메인 카메라


    private void Start()
    {
        Init();
    }

    void Update()
    {
        Move();
    }

    private void Init()
    {
        //Init
        cam = Camera.main;
        cameraMinPos = cam.ViewportToWorldPoint(new Vector3(0f, 0f, Mathf.Abs(transform.position.y - cam.transform.position.y)));
        cameraMaxPos = cam.ViewportToWorldPoint(new Vector3(1f, 1f, Mathf.Abs(transform.position.y - cam.transform.position.y)));
        playerHorizonHalfSize = col.bounds.extents.x;
        playerVerticalHalfSize = col.bounds.extents.z;

        CurrentHp = maxHp;
    }

    private void Move()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        Vector3 inputVec = new Vector3(inputX, 0, inputY).normalized;
        Vector3 deltaMovement = inputVec * moveSpeed * Time.deltaTime;
        Vector3 nextposition = transform.position + deltaMovement;

        //화면 밖으로 나가지 않도록 제어
        nextposition.x = Mathf.Clamp(nextposition.x, cameraMinPos.x + playerHorizonHalfSize, cameraMaxPos.x - playerHorizonHalfSize);
        nextposition.z = Mathf.Clamp(nextposition.z, cameraMinPos.z + playerVerticalHalfSize, cameraMaxPos.z - playerVerticalHalfSize);

        transform.position = nextposition;
    }

    public void OnTakeDamage(float damage)
    {
        CurrentHp -= damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {

        }
    }
}
