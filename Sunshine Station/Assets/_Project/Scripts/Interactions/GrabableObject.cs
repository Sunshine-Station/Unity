using Sunshine.GlobalEnums;
using System.Collections;
using UnityEngine;

namespace Sunshine
{
    public class GrabableObject : MonoBehaviour
    {
        [SerializeField] float cooldownTime;

        private GrabState currentState;
        private GrabState previousState;

        private bool isCooldown;

        public GrabState State { get { return currentState; } }

        void Start()
        {
            currentState = GrabState.UNTOUCHED;
        }

        private IEnumerator cooldown(float duration)
        {
            isCooldown = true;

            float timeRemaining = duration;

            while (timeRemaining > 0)
            {
                yield return new WaitForSeconds(Time.deltaTime);
                timeRemaining -= Time.deltaTime;
            }

            isCooldown = false;
        }

        /// <summary>
        /// Starts a cooldown timer with a
        /// duration value set in the inspector.
        /// </summary>
        protected bool tryStartCooldown(out string errorMsg)
        {
            if (isCooldown)
            {
                errorMsg = $"{name} is already on cooldown.";
                return false;
            }

            errorMsg = "";
            StartCoroutine(cooldown(cooldownTime));
            return true;
        }

        /// <summary>
        /// Starts a cooldown timer with a duration
        /// as specified in the function args.
        /// </summary>
        protected bool tryCooldownStart(float duration, out string errorMsg)
        {
            if (isCooldown)
            {
                errorMsg = $"{name} is already on cooldown.";
                return false;
            }

            errorMsg = "";
            StartCoroutine(cooldown(duration));
            return true;
        }

        /// <summary>
        /// Tries to set the Object's state to hover.
        /// Returns a bool representing the success of the action,
        /// and an out string containing a string with the reason
        /// why (if any) the function failed.

        protected bool tryHoverStart(out string errorMsg)
        {
            if (isCooldown)
            {
                errorMsg =  $"{name} is on cooldown and " +
                            $"its state can't be changed";

                return false;
            }

            switch (currentState)
            {
                default:
                case GrabState.UNTOUCHED:

                    errorMsg = "";

                    previousState = currentState;
                    currentState = GrabState.HOVER;

                    return true;


                case GrabState.HOVER:

                    errorMsg =  $"Can't hover over {name} because " +
                                $"there is already something " +
                                $"hovering over it.";

                    return true;


                case GrabState.HELD:

                    errorMsg =  $"Can't hover over {name} because " +
                                $"it is already being held.";

                    return false;


                case GrabState.DROPPED:

                    errorMsg = $"";

                    previousState = currentState;
                    currentState = GrabState.HOVER;

                    return true;
            }
        }

        /// <summary>
        /// Tries to set the Object's state to hover.
        /// Returns a bool representing the success of the action,
        /// and an out string containing a string with the reason
        /// why (if any) the function failed.
        protected bool tryHoverStop(out string errorMsg)
        {
            switch (currentState)
            {
                default:
                case GrabState.UNTOUCHED:

                    errorMsg =  $"Can't stop hovering over {name} " +
                                $"because there is already" +
                                $"nothing hovering over it.";

                    return false;


                case GrabState.HOVER:

                    errorMsg = "";

                    // Swap states
                    GrabState buffer = currentState;
                    currentState = previousState;
                    previousState = buffer;
                    return true;


                case GrabState.HELD:

                    errorMsg =  $"Can't stop hovering over {name}" +
                                $"because it is being held.";

                    return false;


                case GrabState.DROPPED:

                    errorMsg =  $"Can't stop hovering over {name} " +
                                $"because it has been droppeed; " +
                                $"there is nothing hovering over it.";

                    return false;
            }
        }


        protected bool tryGrab(out string errorMsg)
        {
            if (isCooldown)
            {
                errorMsg =  $"{name} is on cooldown and " +
                            $"its state can't be changed";

                return false;
            }

            switch (currentState)
            {
                default:
                case GrabState.UNTOUCHED:

                    errorMsg =  $"Can't grab {name}, " +
                                $"because there is nothing " +
                                $"targeting it by hovering";

                    return false;


                case GrabState.HOVER:

                    errorMsg = "";
                    currentState = GrabState.HELD;
                    return true;


                case GrabState.HELD:

                    errorMsg =  $"Can't grab {name}, " +
                                $"because it is already being held.";

                    return false;


                case GrabState.DROPPED:

                    errorMsg =  $"Can't grab {name}, " +
                                $"because there is nothing " +
                                $"targeting it by hovering";

                    return false;
            }
        }


        protected bool tryDrop(out string errorMsg)
        {
            if (isCooldown)
            {
                errorMsg =  $"{name} is on cooldown and " +
                            $"its state can't be changed";
                return false;
            }

            switch (currentState)
            {
                default:
                case GrabState.UNTOUCHED:

                    errorMsg =  $"{name} can't be dropped because " +
                                $"it is not being held.";

                    return false;


                case GrabState.HOVER:

                    errorMsg =  $"{name} can't be dropped because " +
                                $"it is not being held.";

                    return false;


                case GrabState.HELD:

                    errorMsg = "";
                    previousState = currentState;
                    currentState = GrabState.DROPPED;
                    return true;


                case GrabState.DROPPED:

                    errorMsg =  $"{name} can't be dropped because " +
                                $"it is not being held.";
                    return false;
            }
        }
    }
}
