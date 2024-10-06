using UnityEngine;
using System;
using UnityEngine.Events;

namespace Sunshine
{
    public class InteractionTrigger : MonoBehaviour, IInteractable
    {
        public Action onPlayerEnter;
        public Action onPlayerExit;
        public Action onInteract;

        private bool _inRange;

        private void Update()
        {
            if (_inRange)
            {
                print ("yr here");
            }
        }

        public void Interact()
        {
            print ($"Interact called on { name }");

            onInteract.Invoke();
        }

        public void ControllerEnter(Hand hand)
        {
            _inRange = true;
            print($"{ hand } enetered interaction range of { name }");

            onPlayerEnter.Invoke();
        }

        public void ControllerExit(Hand hand)
        {
            _inRange = false;
            print($"{ hand } left interaction range of {name}");

            onPlayerExit.Invoke();
        }
    }
}
