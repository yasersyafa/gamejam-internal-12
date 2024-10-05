using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 5;
    [SerializeField] private GameObject bulletPrefab;

    void Awake()
    {
        if(instance == null) {
            instance = this;
        }
    }

    void Start()
    {
        for(int i = 0; i < amountToPool; i++) {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject() {
        foreach(GameObject obj in pooledObjects) {
            if(!obj.activeInHierarchy) {
                return obj;
            }
        }
        return null;
    }
}
