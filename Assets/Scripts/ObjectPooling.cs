using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private GameObject prefabObstacle;
    [SerializeField] private GameObject prefabCoin;
    [SerializeField] private GameObject prefabEnegy;
    [SerializeField] private GameObject prefabImmortal;
    [SerializeField] private GameObject prefabPlatform;
    [SerializeField] private int initialPoolSize = 10;

    private List<GameObject> obstaclePool = new();
    private List<GameObject> coinPool = new();
    private List<GameObject> enegyPool = new();
    private List<GameObject> immortalPool = new();
    private List<GameObject> platformPool = new();

    private static ObjectPooling staticInstance;

    private void Awake()
    {
        if (staticInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        staticInstance = this;
    }

    public static ObjectPooling GetInstance()
    {
        return staticInstance;
    }

    private void Start()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateNewObstacle();
            CreateNewCoin();
            CreateNewEnegy();
            CreateNewImmortal();
            CreateNewPlatform();
        }
    }

    private void CreateNewObstacle()
    {
        GameObject obj = Instantiate(prefabObstacle);
        obj.SetActive(false);
        obstaclePool.Add(obj);
    }

    private void CreateNewCoin()
    {
        GameObject obj = Instantiate(prefabCoin);
        obj.SetActive(false);
        coinPool.Add(obj);
    }

    private void CreateNewEnegy()
    {
        GameObject obj = Instantiate(prefabEnegy);
        obj.SetActive(false);
        enegyPool.Add(obj);
    }

    private void CreateNewImmortal()
    {
        GameObject obj = Instantiate(prefabImmortal);
        obj.SetActive(false);
        immortalPool.Add(obj);
    }

    private void CreateNewPlatform()
    {
        GameObject obj = Instantiate(prefabPlatform);
        obj.SetActive(false);
        platformPool.Add(obj);
    }

    public GameObject AcquireObstacle(Vector3 position, Quaternion rotation)
    {
        if (obstaclePool.Count == 0)
        {
            CreateNewObstacle();
        }

        GameObject obj = obstaclePool[0];
        obstaclePool.RemoveAt(0);

        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);

        return obj;
    }

    public GameObject AcquireCoin(Vector3 position, Quaternion rotation)
    {
        if (coinPool.Count == 0)
        {
            CreateNewCoin();
        }

        GameObject obj = coinPool[0];
        coinPool.RemoveAt(0);

        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);

        return obj;
    }

    public GameObject AcquireEnegy(Vector3 position, Quaternion rotation)
    {
        if (enegyPool.Count == 0)
        {
            CreateNewEnegy();
        }

        GameObject obj = enegyPool[0];
        enegyPool.RemoveAt(0);

        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);

        return obj;
    }

    public GameObject AcquireImmortal(Vector3 position, Quaternion rotation)
    {
        if (immortalPool.Count == 0)
        {
            CreateNewImmortal();
        }

        GameObject obj = immortalPool[0];
        immortalPool.RemoveAt(0);

        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);

        return obj;
    }

    public GameObject AcquirePlatform(Vector3 position, Quaternion rotation)
    {
        if (platformPool.Count == 0)
        {
            CreateNewPlatform();
        }

        GameObject obj = platformPool[0];
        platformPool.RemoveAt(0);

        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);

        return obj;
    }

    public void ReturnToObstaclePool(GameObject obj)
    {
        obj.SetActive(false);
        obstaclePool.Add(obj);
    }

    public void ReturnToCoinPool(GameObject obj)
    {
        obj.SetActive(false);
        coinPool.Add(obj);
    }

    public void ReturnToEnegyPool(GameObject obj)
    {
        obj.SetActive(false);
        enegyPool.Add(obj);
    }

    public void ReturnToImmortalPool(GameObject obj)
    {
        obj.SetActive(false);
        immortalPool.Add(obj);
    }

    public void ReturnToPlatformPool(GameObject obj)
    {
        obj.SetActive(false);
        platformPool.Add(obj);
    }
}
