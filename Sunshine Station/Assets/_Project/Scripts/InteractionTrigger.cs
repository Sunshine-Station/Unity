// layla
using UnityEngine;
using UnityEngine.Events;

namespace Sunshine
{
    [RequireComponent(typeof(Collider))]
    public class InteractionTrigger : MonoBehaviour, IInteractable
    {
        [Header("Events")]
        public UnityEvent OnControllerEnter;
        public UnityEvent OnControllerExit;
        public UnityEvent OnInteract;

        private bool _controllerHere;

        private void Update()
        {
            if (_controllerHere)
            {
                print ("yr here");
            }
        }

        public void Interact(Hand hand)
        {
            print ($"{ hand } called Interact on { name }");

            OnInteract?.Invoke();
        }

        public void ControllerEnter(Hand hand)
        {
            // This means that if both controllers are there,
            // and then one leaves, one of them has to reenter the collider
            // to trigger it... I'm leaving it off for now.
            //if (_controllerHere) { return; }

            _controllerHere = true;
            print($"{ hand } enetered interaction range of { name }");

            OnControllerEnter?.Invoke();
        }

        public void ControllerExit(Hand hand)
        {
            _controllerHere = false;
            print($"{ hand } left interaction range of {name}");

            OnControllerExit?.Invoke();
        }
    }
}
