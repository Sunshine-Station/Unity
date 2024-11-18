using System.Collections;
using UnityEngine;

namespace Sunshine
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _mgr;

        public static T MGR { get { return _mgr; } }

        protected virtual void Awake()
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
    }
}
