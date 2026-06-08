using System.Collections.Generic;
using UnityEngine;

// PASTIKAN namanya ObjectPool, bukan PooledObjects!
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    // Ini adalah variabel untuk menampung pengaturan peluru
    public GameObject objectToPool;
    public int amountToPool = 10;

    private List<GameObject> pooledObjects;

    void Awake()
    {
        Instance = this;
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            if (objectToPool != null)
            {
                GameObject obj = Instantiate(objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}