    using System.Collections.Generic;
    using UnityEngine;

    public class Tail : MonoBehaviour
    {
        [SerializeField] private TailElement[] _tailElements;
        [SerializeField] private Player _player;
        private Mover _mover;
        private List<Coroutine> _allMoveCoroutines;
        private float _yPosition;

        private void Awake()
        {
            _mover = FindObjectOfType<Mover>();
            _allMoveCoroutines = new List<Coroutine>();
            _yPosition = _tailElements[0].GetComponent<SpriteRenderer>().size.x / 2;

        }

        private void OnEnable()
        {
            _mover.Moving += OnPlayerMoving;

        } 
        
        private void OnDisable()
        {
            _mover.Moving -= OnPlayerMoving;
            
        }
        
        private void OnPlayerMoving()
        {
            ChangeTailPosition();
            
        }
        private void ChangeTailPosition()
        {
            var targetPosition = _player.transform.position;
            
            foreach (var tail in _tailElements)
            {
                if ((targetPosition - tail.transform.position).sqrMagnitude >
                    tail.GetComponent<SpriteRenderer>().size.SqrMagnitude() / 20)
                {
                    tail.transform.position = Vector3.MoveTowards(tail.transform.position, targetPosition, 
                        _player.Speed * Time.deltaTime);
                    targetPosition = tail.transform.position;
                    
                }

                else
                    break;
                
            }
            
        }

    }
