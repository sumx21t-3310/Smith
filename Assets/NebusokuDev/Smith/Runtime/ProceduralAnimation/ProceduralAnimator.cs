using System.Collections.Generic;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.ProceduralAnimation
{
    public class ProceduralAnimator : MonoBehaviour
    {
        private List<IProceduralAnimation> _animators;

        private void Awake()
        {
            _animators = new List<IProceduralAnimation>();

            _animators.AddRange(GetComponents<IProceduralAnimation>());
            _animators.AddRange(GetComponentsInChildren<IProceduralAnimation>());
        }

        public void Play()
        {
            foreach (var animator in _animators)
            {
                animator.Play();
            }
        }
    }
}