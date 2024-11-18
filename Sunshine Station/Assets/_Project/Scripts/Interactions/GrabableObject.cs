using Sunshine.GlobalEnums;
using System.Collections;
using UnityEngine;

namespace Sunshine
{
    public class GrabableObject : MonoBehaviour
    {
        [SerializeField] float cooldownTime;

        private GrabState state;
        private bool isCooldown;

        public GrabState State { get { return state; } }

        void Start()
        {
            state = GrabState.UNTOUCHED;
        }

        private IEnumerator cooldown()
        {
            isCooldown = true;

            float timeRemaining = cooldownTime;

            while (timeRemaining > 0)
            {
                yield return new WaitForSeconds(Time.deltaTime);
                timeRemaining -= Time.deltaTime;
            }

            isCooldown = false;
        }

        protected bool tryHover(out string errorMsg)
        {
            if (isCooldown)
            {
                errorMsg = $"{name} is on cooldown and its state can't be changed";
                return false;
            }

            switch (state)
            {
                default:
                case GrabState.UNTOUCHED:

                    errorMsg = "";
                    state = GrabState.HOVER;
                    return true;


                case GrabState.HOVER:

                    errorMsg = $"{name} is already being targeted.";
                    return false;


                case GrabState.HELD:

                    errorMsg = $"{name} is already being held.";
                    return false;


                case GrabState.DROPPED:

                    errorMsg = $"";
                    state = GrabState.HOVER;
                    return true;
            }
        }


        protected bool tryHold(out string errorMsg)
        {
            if (isCooldown)
            {
                errorMsg = $"{name} is on cooldown and its state can't be changed";
                return false;
            }

            switch (state)
            {
                default:
                case GrabState.UNTOUCHED:

                    errorMsg = $"{name} is NOT being targeted.";
                    return false;


                case GrabState.HOVER:

                    errorMsg = "";
                    state = GrabState.HELD;
                    return true;


                case GrabState.HELD:

                    errorMsg = $"{name} is already being held.";
                    return false;


                case GrabState.DROPPED:

                    errorMsg = $"{name} is NOT being targeted.";
                    return false;
            }
        }


        protected bool tryDrop(out string errorMsg)
        {
            if (isCooldown)
            {
                errorMsg = $"{name} is on cooldown and its state can't be changed";
                return false;
            }

            switch (state)
            {
                default:
                case GrabState.UNTOUCHED:

                    errorMsg = $"{name} is trying to get dropped," +
                                        $" but it NOT being held.";

                    return false;


                case GrabState.HOVER:

                    errorMsg = $"{name} is trying to get dropped," +
                                        $" but it NOT being held.";

                    return false;


                case GrabState.HELD:

                    errorMsg = "";
                    state = GrabState.DROPPED;
                    return true;


                case GrabState.DROPPED:

                    errorMsg = $"{name} is trying to get dropped," +
                                        $" but it NOT being held.";
                    return false;
            }
        }
    }
}
