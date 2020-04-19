using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : Singleton<ObjectPooler>
{
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> pooledDict;

    protected ObjectPooler()
    {

    }
    private void Awake()
    {
        //Create Dictionary for the required pool objects containers 
        pooledDict = new Dictionary<string, Queue<GameObject>>();

        //Instantiate all objects as per the count and feed into the vs
        foreach (Pool poo in pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            for (int i = 0; i < poo.size; i++)
            {
                GameObject go = Instantiate(poo.prefeb);
                go.SetActive(false);
                queue.Enqueue(go);
            }
            pooledDict.Add(poo.tag, queue);
        }
    }

    /// <summary>
    /// Spawn an object from the pool
    /// </summary>
    /// <param name="tag">Object Name </param>
    /// <returns></returns>
    public GameObject SpwanFrompool(string tag)
    {
        if (!pooledDict.ContainsKey(tag))
        {
            Debug.LogWarning("Obeject not found in the pool " + tag);
            return null;
        }
        GameObject go = pooledDict[tag].Dequeue();
        go.SetActive(true);

        IObjectPool iPool = go.GetComponent<IObjectPool>();
        if (iPool != null)
        {
            iPool.OnObjectSpawn();
        }

        pooledDict[tag].Enqueue(go);

        return go;
    }
}


