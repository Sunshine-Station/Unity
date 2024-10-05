using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

namespace Sunshine
{
    public class InteractionTrigger : MonoBehaviour, IInteractable
    {
        private bool _inRange;

        private void Awake()
        {
        }

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }

        private void Update()
        {
            if (_inRange)
            {
                print ("yr here");
            }
        }

        public void Interact()
        {
            print ("pushy button");
        }

        public void OnPlayerEnterRange()
        {
            _inRange = true;
            print("hi");
        }

        public void OnPlayerExitRange()
        {
            _inRange = false;
            print("bye");
        }
    }
}
