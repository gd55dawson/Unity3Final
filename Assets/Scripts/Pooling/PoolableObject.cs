using System.Collections;
using UnityEngine;


namespace ObjectPooling
{
    public class PoolableObject : MonoBehaviour
    {
        [SerializeField]
        private float _Lifespan = -1;

        public int poolId;

        private void OnEnable()
        {
            if(_Lifespan >= 0f)
            {
                StartCoroutine(Disabler());
            }
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator Disabler()
        {
            yield return new WaitForSeconds(_Lifespan);
            PoolManager.Fetch(this, poolId); // fetches a poolable object with the same poolid
            gameObject.SetActive(false); // disables game object
        }
    }
}
