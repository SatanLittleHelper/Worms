using System;
using UnityEngine;

public abstract class Control : MonoBehaviour
    {
        private Player _player;
        private Camera _camera;

        public event Action DirectionChanged;
        
        private void Awake()
        {
            _camera = Camera.main;
            _player = FindObjectOfType<Player>();

        }

        protected virtual void Update()
        {
            if (Input.GetMouseButton(0))
            {
                ChangeDirection(GetPositionInGameBoard(Input.mousePosition));
            
            }
        
        }

        private void ChangeDirection(Vector3 target)
        {
            var direction = target - _player.transform.position;
            direction.z = 0;
            _player.Direction = direction.normalized;
            DirectionChanged?.Invoke();

        }


        private Vector3 GetPositionInGameBoard(Vector3 mousePosition)
        {
            var position = _camera.ScreenPointToRay(mousePosition);
            return position.origin;

        }


    }
