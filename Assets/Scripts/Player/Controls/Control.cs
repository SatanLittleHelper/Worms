using System;
using UnityEngine;

public abstract class Control : MonoBehaviour
    {
        private Player _player;
        private Camera _camera;
        private Vector3 _lastDirection;

        public event Action<Vector3> DirectionChanged;
        public event Action SpeedUp;
        public event Action SpeedDown;
        
        private void Awake()
        {
            _camera = Camera.main;
            _player = FindObjectOfType<Player>();

        }

        protected virtual void Update()
        {
            ChangeDirection(GetPositionInGameBoard(Input.mousePosition));

            if (Input.GetMouseButtonDown(0))
                SpeedUp?.Invoke();
            if (Input.GetMouseButtonUp(0))
                SpeedDown?.Invoke();

        
        }

        private void ChangeDirection(Vector3 target)
        {
                
            var direction = target - _player.transform.position;
            direction.z = 0;
            if (_lastDirection.normalized == direction.normalized) return;
            
            DirectionChanged?.Invoke(direction.normalized);
            _lastDirection = direction;

        }


        private Vector3 GetPositionInGameBoard(Vector3 mousePosition)
        {
            var position = _camera.ScreenPointToRay(mousePosition);
            return position.origin;

        }


    }
