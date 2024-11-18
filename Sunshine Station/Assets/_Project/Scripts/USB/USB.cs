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
            if (!tryHoverStart(out string hoverError))
            {
                Debug.LogWarning(hoverError);
            }
        }

        public void UnHover()
        {
            if (!tryHoverStop(out string unhoverError))
            {
                Debug.LogWarning(unhoverError);
            }
        }

        public void Grab()
        {
            if (!tryGrab(out string grabError))
            {
                Debug.LogWarning(grabError);
            }

            if (!tryStartCooldown(out string cooldownError))
            {
                Debug.LogWarning(cooldownError);
            }
        }

        public void Drop()
        {
            if (!tryDrop(out string dropError))
            {
                Debug.LogWarning(dropError);
            }

            if (!tryStartCooldown(out string cooldownError))
            {
                Debug.LogWarning(cooldownError);
            }
        }
    }
}