using UnityEngine;
using UnityEngine.Events;
using Sunshine.GlobalEnums;

namespace Sunshine
{
    public class USB : GrabableObject
    {
        public UnityEvent WhileUntouched;
        public UnityEvent WhileHover;
        public UnityEvent WhileHeld;
        public UnityEvent WhileDropped;

        private void Update()
        {
            switch (State)
            {
                default:
                case GrabState.UNTOUCHED:

                    WhileUntouched.Invoke();
                    break;


                case GrabState.HOVER:

                    WhileHover.Invoke();
                    break;


                case GrabState.HELD:

                    WhileHeld.Invoke();
                    break;


                case GrabState.DROPPED:

                    WhileDropped.Invoke();
                    break;
            }
        }

        public void Hover()
        {
            if (!tryHover(out string error))
            {
                Debug.LogWarning(error);
            }
        }

        public void Grab()
        {
            if (!tryHold(out string error))
            {
                Debug.LogWarning(error);
            }
        }

        public void Drop()
        {
            if (!tryDrop(out string error))
            {
                Debug.LogWarning(error);
            }
        }
    }
}