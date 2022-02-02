    using UnityEngine;

    public class GameDesk : MonoBehaviour
    {
        public Vector2 Size { get; private set; }

        private void Awake()
        {
            Size = transform.localScale;
            
        }

    }
