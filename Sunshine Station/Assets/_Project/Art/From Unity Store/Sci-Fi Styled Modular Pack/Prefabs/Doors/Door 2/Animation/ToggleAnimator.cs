using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sunshine
{
    [RequireComponent(typeof(AnimTrigger))]
    public class ToggleAnimator : MonoBehaviour
    {
        [SerializeField] string _onTriggerName;
        [SerializeField] string _offTriggerName;

        private AnimTrigger _trigger;

        private void Start()
        {
            _trigger = GetComponent<AnimTrigger>();
        }

        public void ToggleOn()
        {
            _trigger.Trigger(_onTriggerName);
        }

        public void ToggleOff()
        {
            _trigger.Trigger(_offTriggerName);
        }
    }
}
