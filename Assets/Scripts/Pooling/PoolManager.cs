using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{

    public static class PoolManager 
    {
        private static readonly int INITIAL_POOL_SIZE = 5;
        private static Dictionary<int, Queue<PoolableObject>> _Pools = new Dictionary<int, Queue<PoolableObject>>(); // switched list to queue

        private static PoolableObject AddObjectToPool(PoolableObject prefab, int poolId)
        {
            var clone = GameObject.Instantiate(prefab);
            clone.gameObject.SetActive(false);
            _Pools[poolId].Enqueue(clone); // when button is pressed clone enters queue
            clone.poolId = prefab.GetInstanceID(); // clone's ID equal to the prefabs ID
            return clone;
        }

        public static void CreatePool(PoolableObject prefab, int poolSize)
        {
            var poolId = prefab.GetInstanceID();
            _Pools[poolId] = new Queue<PoolableObject>(poolSize);
            for (int i = 0; i < poolSize; i++)
            {
                AddObjectToPool(prefab, poolId);
            }
        }
            public static PoolableObject GetNext(PoolableObject prefab, Vector3 pos, Quaternion rot, bool active = true)
            {
                var clone = GetNext(prefab);
                clone.transform.position = pos;
                clone.transform.rotation = rot;
                clone.gameObject.SetActive(active);
                return clone;
            }

        public static PoolableObject GetNext(PoolableObject prefab)
        {
            var poolId = prefab.GetInstanceID();
            if(_Pools.ContainsKey(poolId) == false)
            {
                CreatePool(prefab, INITIAL_POOL_SIZE);
            }

            var currentPoolableObjectList = _Pools[poolId];

            // Return the next avaiable PoolableObject

            if(_Pools[poolId].Count > 0) // if the pool count is less than 0
            {
                return _Pools[poolId].Dequeue(); // dequeues bullet
                
            }
            return AddObjectToPool(prefab, poolId);
        }
        public static void Fetch(PoolableObject prefab, int poolId)
        {
            _Pools[prefab.poolId].Enqueue(prefab); // enques a new prefab
        }
    }
}
