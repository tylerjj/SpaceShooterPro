using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Author: Jason Weimann
// Source: https://www.youtube.com/watch?v=uxm4a0QnQ9E&t=1478s

public class GenericObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _preWarmCount = 25;

    private Queue<T> objects = new Queue<T>();
    public static GenericObjectPool<T> Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        AddObjects(_preWarmCount);
    }

    public T Get()
    {
        if (objects.Count == 0)
        {
            AddObjects(1);
        }
        return objects.Dequeue();
    }

    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objects.Enqueue(objectToReturn);
    }

    private void AddObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var newObject = GameObject.Instantiate(_prefab);
            newObject.transform.parent = Instance.transform;
            ReturnToPool(newObject);
        }

    }


}
