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
        //instange가 없을 경우 지금 객체를 할당, 다른 instance가 있을 경우 지금 객체 소멸
        if (instance == null)
            instance = this as T;
        else if (instance != this)
            Destroy(gameObject);

        //씬 이동시 소멸되지 않도록 하기
        if (transform.parent != null && transform.root != null)
            DontDestroyOnLoad(transform.root.gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}
