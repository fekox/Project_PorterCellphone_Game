using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> objectList;

    private static ObjectPool instance;
    public static ObjectPool Instnace 
    {   
        get 
        { 
            return instance; 
        } 
    }

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }

    public void AddObjectsToPool(GameObject obj) 
    {
        obj.SetActive(false);
        objectList.Add(obj);
    }

    public GameObject RequestObject() 
    {
        for(int i = 0; i < objectList.Count ;i++) 
        {
            if (!objectList[i].activeSelf) 
            {
                objectList[i].SetActive(true);
                return objectList[i];
            }
        }

        return null;
    }
}
