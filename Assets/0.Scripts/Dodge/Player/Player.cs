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

            if (value <= 0)
            {
                GameManager.Instance.CurrentGameState = GameState.Menu;
                PlayerDead();
                return;
            }

            foreach (var o in observers)
            {
                o.OnPlayerHPChanged(maxHp, CurrentHp);
            }
        }
    }

    private List<IPlayerHPObserver> observers = new List<IPlayerHPObserver>();

    private float inputX;
    private float inputY;

    [Header("�÷��̾� ���� ����")]
    [SerializeField] private float moveSpeed;

    [SerializeField] private Collider col;      //�÷��̾� �ݶ��̴�
    private float playerHorizonHalfSize;        //�÷��̾� ���� ���� ������
    private float playerVerticalHalfSize;       //�÷��̾� ���� ���� ������

    private Vector3 cameraMinPos;               //ī�޶� ȭ���� ���� �Ʒ� �𼭸� ��ǥ
    private Vector3 cameraMaxPos;               //ī�޶� ȭ���� ������ �� �𼭸� ��ǥ

    private Camera cam;                         //���� ī�޶�

    private Vector3 startPos;

    private void Start()
    {
        Init();
    }

    void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameState.InGame)
        {
            Move();
        }
    }

    private void Init()
    {
        //Init
        cam = Camera.main;
        cameraMinPos = cam.ViewportToWorldPoint(new Vector3(0f, 0f, Mathf.Abs(transform.position.y - cam.transform.position.y)));
        cameraMaxPos = cam.ViewportToWorldPoint(new Vector3(1f, 1f, Mathf.Abs(transform.position.y - cam.transform.position.y)));
        playerHorizonHalfSize = col.bounds.extents.x;
        playerVerticalHalfSize = col.bounds.extents.z;

        startPos = transform.position;
        CurrentHp = maxHp;

        GameManager.Instance.GameStateInGame += PlayerStartGame;
    }

    private void Move()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        Vector3 inputVec = new Vector3(inputX, 0, inputY).normalized;
        Vector3 deltaMovement = inputVec * moveSpeed * Time.deltaTime;
        Vector3 nextposition = transform.position + deltaMovement;

        //ȭ�� ������ ������ �ʵ��� ����
        nextposition.x = Mathf.Clamp(nextposition.x, cameraMinPos.x + playerHorizonHalfSize, cameraMaxPos.x - playerHorizonHalfSize);
        nextposition.z = Mathf.Clamp(nextposition.z, cameraMinPos.z + playerVerticalHalfSize, cameraMaxPos.z - playerVerticalHalfSize);

        transform.position = nextposition;
    }

    private void PlayerDead()
    {
        transform.position = startPos;
        CurrentHp = maxHp;
        gameObject.SetActive(false);
    }

    //������ ������ �� �÷��̾� ����
    private void PlayerStartGame()
    {
        //activeSelf�� false�� ��� �ٽ� ����
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);
    }

    public void AddObserver(IPlayerHPObserver observer) => observers.Add(observer);
    public void RemoveObserver(IPlayerHPObserver observer) => observers.Remove(observer);

    public void OnTakeDamage(float damage)
    {
        CurrentHp -= damage;
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.GameStateInGame -= PlayerStartGame;
    }
}
