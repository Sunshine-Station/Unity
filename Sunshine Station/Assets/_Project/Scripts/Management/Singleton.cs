using System.Collections;
using UnityEngine;

namespace Sunshine
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _mgr;

        public static T MGR { get { return _mgr; } }

        private void Awake()
        {
            if (_mgr != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _mgr = this as T;
            }
        }

        private IEnumerator AddManagerToMasterList()
        {
            yield return new WaitUntil(() => Game.MGR != null);


        }
    }
}
