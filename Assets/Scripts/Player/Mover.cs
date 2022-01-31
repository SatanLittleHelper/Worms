    using System;
    using System.Collections;
    using Unity.Mathematics;
    using UnityEngine;

    public class Mover : MonoBehaviour
    {
        private Player _player;
        private Coroutine _moveCoroutine;
        private Control _control;

        public event Action Moving;

        private void Awake()
        {
            _player = FindObjectOfType<Player>();
            _control = _player.GetComponent<Control>();
            StartMove();
            
        }

        private void OnEnable()
        {
            _control.DirectionChanged += OnDirectionChanged;
            
        }

        private void OnDisable()
        {
            _control.DirectionChanged -= OnDirectionChanged;
            
        }

        private IEnumerator MoveRoutine(Vector3 dir)
        {
            while (_player)
            {
                Move(_player, _player.transform.position + dir);
                LookAtTarget(_player, _player.transform.position + dir);
                Moving?.Invoke();

                yield return null;

            }

        }
        
        private void Move(Player obj, Vector3 direction)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, direction, _player.Speed * Time.deltaTime);
            


        }

        private void LookAtTarget(Player obj, Vector3 direction)
        {
            var angle = Vector2.Angle(Vector2.left,  direction - obj.transform.position);
            transform.eulerAngles = new Vector3(0f, 0f, obj.transform.position.y < direction.y ? -angle : angle);
            
        }

        private void StartMove()
        {
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
                _moveCoroutine = null;
            }
            
            _moveCoroutine = StartCoroutine(MoveRoutine(_player.Direction));
            
        }

        private void OnDirectionChanged()
        {
            StartMove();

        }

    }