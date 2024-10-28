using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.Events;

namespace Sunshine
{
    public class ToggleableObject : MonoBehaviour
    {
        [SerializeField] private UnityEvent TurnOn;
        [SerializeField] private UnityEvent TurnOff;
        [SerializeField] private UnityEvent WhileOn;
        [SerializeField] private UnityEvent WhileOff;
        [SerializeField] private bool _startOn;

        private bool _isOn;
        [SerializeField] private bool TEST_ONLY_Toggle;

        private void Awake()
        {
            _isOn = _startOn;
        }

        private void Update()
        {
            if (TEST_ONLY_Toggle)
            {
                Toggle();
                TEST_ONLY_Toggle = false;
            }

            if (_isOn)
            {
                WhileOn.Invoke();
            }
            else
            {
                WhileOff.Invoke();
            }
        }

        private void turnOn()
        {
            _isOn = true;
            TurnOn.Invoke();
        }

        private void turnOff()
        {
            _isOn = false;
            TurnOff.Invoke();
        }

        public void Toggle()
        {
            if (_isOn)
            {
                turnOff();
            }
            else
            {
                turnOn();
            }
        }
    }
}
