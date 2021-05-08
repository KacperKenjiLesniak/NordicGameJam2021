using System;
using UnityEngine;

namespace DefaultNamespace.Effects
{
    public class BloodSplash : MonoBehaviour
    {
        private void Start()
        {
            Invoke(nameof(DestroyBlood), 2f);
        }

        void DestroyBlood()
        {
            Destroy(gameObject);
        }
    }
}