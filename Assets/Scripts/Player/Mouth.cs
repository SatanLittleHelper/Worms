
    using System;
    using UnityEngine;

    public class Mouth : MonoBehaviour
    {
        public event Action<int> Eat;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(typeof(Eat), out _))
            {
                col.gameObject.SetActive(false);
                Eat?.Invoke(1);

            }

        }
        
    }
