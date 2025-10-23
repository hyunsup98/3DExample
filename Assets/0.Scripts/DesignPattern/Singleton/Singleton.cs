using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindAnyObjectByType<T>();

                if(instance == null)
                {
                    GameObject obj = new GameObject();
                    instance = obj.AddComponent<T>();
                    obj.name = typeof(T).ToString();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        //instange�� ���� ��� ���� ��ü�� �Ҵ�, �ٸ� instance�� ���� ��� ���� ��ü �Ҹ�
        if (instance == null)
            instance = this as T;
        else if (instance != this)
            Destroy(gameObject);

        //�� �̵��� �Ҹ���� �ʵ��� �ϱ�
        if (transform.parent != null && transform.root != null)
            DontDestroyOnLoad(transform.root.gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}
