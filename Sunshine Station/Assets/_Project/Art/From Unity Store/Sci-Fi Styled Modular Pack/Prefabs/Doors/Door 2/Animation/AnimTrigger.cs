using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sunshine
{
    [RequireComponent(typeof(Animator))]
    public class AnimTrigger : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void Trigger(string nameOfTrigger)
        {
            _animator.SetTrigger(nameOfTrigger);
        }
    }
}
