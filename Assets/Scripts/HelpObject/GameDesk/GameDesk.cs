    using UnityEngine;

    public class GameDesk : MonoBehaviour
    {
        private Vector2 _size;

        public Vector2 Size => _size;

        private void Start()
        {
            _size = transform.lossyScale;
            
        }

    }
