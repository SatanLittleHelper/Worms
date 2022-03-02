    using System;
    using System.Collections;
    using UnityEngine;

    public class Mover : MonoBehaviour
    {
        private Player _player;
        private Coroutine _moveCoroutine;
        private Control _control;

        public event Action Moving;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _control = _player.GetComponent<Control>();
            StartMove(_player.Direction);
            
        }

        private void OnEnable()
        {
            _control.DirectionChanged += OnDirectionChanged;
            
        }

        private void OnDisable()
        {
            _control.DirectionChanged -= OnDirectionChanged;
            
        }

        private IEnumerator MoveRoutine(Vector3 direction)
        {
            while (_player)
            {
                _player.Direction = direction.normalized;
                Move(_player, _player.transform.position + direction);
                LookAtTarget(_player, _player.transform.position + direction);
                Moving?.Invoke();

                yield return null;

            }

        }
        
        private void Move(Player obj, Vector3 direction)
        {
            // Debug.Log(direction);
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, direction, _player.Speed * Time.deltaTime);

        }

        private void LookAtTarget(Player obj, Vector3 direction)
        {
            var angle = Vector2.Angle(Vector2.left,  direction - obj.transform.position);
            transform.eulerAngles = new Vector3(0f, 0f, obj.transform.position.y < direction.y ? -angle : angle);
            
        }

        private void StartMove(Vector3 direction)
        {
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
                _moveCoroutine = null;
            }

            _moveCoroutine = StartCoroutine(MoveRoutine(ReversalCheck(direction)));
            
        }

        private void OnDirectionChanged(Vector3 direction)
        {
            StartMove(direction);

        }

        private Vector3 ReversalCheck(Vector3 direction)
        {
            if (Math.Abs(direction.normalized.x - _player.Direction.x) > 0.2f ||
                Math.Abs(direction.normalized.y - _player.Direction.y) > 0.2f)
                // Debug.Log("reversal");
                return new Vector3(direction.x + 0.5f, direction.y + 0.5f, 0);
            
            return direction;
            
        }
        
    }