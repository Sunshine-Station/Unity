using Sunshine.GlobalEnums;
using System.Collections;
using UnityEngine;

namespace Sunshine
{
    public class GrabableObject : MonoBehaviour
    {
        [SerializeField] bool printErrors;
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

        public bool TryHover()
        {
            bool result = false;
            string errorMsg = "";
            if (isCooldown)
            {
                errorMsg = $"{name} is on cooldown and its state can't be changed";
                if (printErrors)
                {
                    Debug.LogWarning(errorMsg);
                    return result;
                }
            }

            switch (state)
            {
                default:
                case GrabState.UNTOUCHED:

                    errorMsg = "";
                    result = true;
                    break;


                case GrabState.HOVER:

                    errorMsg = $"{name} is already being targeted.";
                    break;


                case GrabState.HELD:

                    errorMsg = $"{name} is already being held.";
                    break;


                case GrabState.DROPPED:

                    errorMsg = $"";
                    result = true;
                    break;
            }

            if (printErrors)
            {
                Debug.LogWarning(errorMsg);
            }

            return result;
        }


        public bool TryHold()
        {
            bool result = false;
            string errorMsg = "";
            if (isCooldown)
            {
                errorMsg = $"{name} is on cooldown and its state can't be changed";
                if (printErrors)
                {
                    Debug.LogWarning(errorMsg);
                    return result;
                }
            }

            switch (state)
            {
                default:
                case GrabState.UNTOUCHED:

                    errorMsg = $"{name} is NOT being targeted.";
                    break;


                case GrabState.HOVER:

                    errorMsg = "";
                    result = true;
                    break;


                case GrabState.HELD:

                    errorMsg = $"{name} is already being held.";
                    break;


                case GrabState.DROPPED:

                    errorMsg = $"{name} is NOT being targeted.";
                    break;
            }

            if (printErrors)
            {   
                Debug.LogWarning(errorMsg);
            }

            return result;

        }


        public bool TryDrop()
        {
            bool result = false;
            string errorMsg = "";
            if (isCooldown)
            {
                errorMsg = $"{name} is on cooldown and its state can't be changed";
                if (printErrors)
                {
                    Debug.LogWarning(errorMsg);
                    return result;
                }
            }

            switch (state)
            {
                default:
                case GrabState.UNTOUCHED:

                    errorMsg = $"{name} is trying to get dropped," +
                                        $" but it NOT being held.";

                    break;


                case GrabState.HOVER:

                    errorMsg = $"{name} is trying to get dropped," +
                                        $" but it NOT being held.";

                    break;


                case GrabState.HELD:

                    errorMsg = "";
                    result = true;
                    break;


                case GrabState.DROPPED:

                    errorMsg = $"{name} is trying to get dropped," +
                                        $" but it NOT being held.";
                    break;
            }

            if (printErrors)
            {       
                Debug.LogWarning(errorMsg);
            }

            return result;
        }
    }
}
