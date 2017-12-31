using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// PoolManager class for pooling object. Single instance only.
/// </summary>
public class ULibXPoolManager : MonoBehaviour {

    Dictionary<int, Queue<PooledObjectWrapper>> poolDictionary = new Dictionary<int, Queue<PooledObjectWrapper>>();
    static ULibXPoolManager _instance;

    /// <summary>
    /// PoolManager inner class for pooled object wrapper.
    /// </summary>
    private class PooledObjectWrapper
    {
        GameObject gameObject;
        Transform transform;

        bool hasULibxPooledObjectComponent;
        ULibXPooledObject pooledObjectScript;

        /// <summary>
        /// PooledObjectWrapper constructor.
        /// </summary>
        /// <param name="obj">Object to pool instantiated prefab.</param>
        public PooledObjectWrapper(GameObject obj) 
        {
            gameObject = obj;
            transform = gameObject.transform;
            gameObject.SetActive(false);

            pooledObjectScript = gameObject.GetComponent<ULibXPooledObject>();
            hasULibxPooledObjectComponent = (pooledObjectScript != null) ? true : false;
        }//END OF PooledObjectWrapper constructor

        /// <summary>
        /// Trigger object to reuse itself.
        /// </summary>
        /// <param name="position">Reused object position.</param>
        /// <param name="rotation">Reused object rotation.</param>
        public void Reuse(Vector3 position, Quaternion rotation)
        {
            gameObject.SetActive(true);
            transform.position = position;
            transform.rotation = rotation;

            if(hasULibxPooledObjectComponent)
            {
                pooledObjectScript.OnObjectReuse();
            }//END OF if STATEMENT
        }//END OF Reuse method

        /// <summary>
        /// Set the parent transform of the pooled object.
        /// </summary>
        /// <param name="parent"></param>
        public void SetParent(Transform parent)
        {
            transform.parent = parent;
        }//END OF SetParent method
    }//END OF class PooledObjectWrapper

    /// <summary>
    /// ULibXPoolManager singleton pattern.
    /// </summary>
    public static ULibXPoolManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<ULibXPoolManager>();
            }//END OF if STATEMENT
            return _instance;
        }//END OF getter
    }//END OF ULibXPoolManager ACCESSOR

    /// <summary>
    /// Create pool of the passed prefab.
    /// </summary>
    /// <param name="prefab">Prefab to be instantiated.</param>
    /// <param name="poolSize">Object pool size</param>
    public void CreatePool(GameObject prefab, int poolSize)
    {
        int poolKey = prefab.GetInstanceID();

        if(!poolDictionary.ContainsKey(poolKey))
        {
            poolDictionary.Add(poolKey, new Queue<PooledObjectWrapper>());

            GameObject poolHolder = new GameObject(prefab.name + " pool");
            poolHolder.transform.parent = transform;

            PooledObjectWrapper pooledObjectWrapper;

            for(int i = 0; i < poolSize; i++)
            {
                pooledObjectWrapper = new PooledObjectWrapper(Instantiate<GameObject>(prefab));
                poolDictionary[poolKey].Enqueue(pooledObjectWrapper);
                pooledObjectWrapper.SetParent(poolHolder.transform);
            }//END OF for LOOP

        }//END OF if STATEMENT
    }//END OF CreatePool method

    /// <summary>
    /// Triggers object reuse by prefab.
    /// </summary>
    /// <param name="prefab">Pooled object used prefab.</param>
    /// <param name="position">Pooled object position.</param>
    /// <param name="rotation">Pooled object rotation.</param>
    public void ReuseObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        int poolKey = prefab.GetInstanceID();

        if(poolDictionary.ContainsKey(poolKey))
        {
            PooledObjectWrapper pooledObjectWrapper = poolDictionary[poolKey].Dequeue();

            poolDictionary[poolKey].Enqueue(pooledObjectWrapper);
            pooledObjectWrapper.Reuse(position, rotation);
        }//END OF if STATEMENT
    }//END OF ReuseObject method
    
}//END OF class ULibXPoolManager
