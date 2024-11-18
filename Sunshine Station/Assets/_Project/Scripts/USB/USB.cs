using UnityEngine;
using UnityEngine.Events;

namespace Sunshine
{
    public class USB : GrabableObject
    {
        public UnityEvent OnHover;
        public UnityEvent OnGrab;
        public UnityEvent OnDrop;
    }
}
