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
            _yPosition = _tailElements[0].GetComponent<MeshRenderer>().bounds.size.y / 2;

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
            var targetPosition = new Vector3(_player.transform.position.x, _yPosition, _player.transform.position.z);
            
            foreach (var tail in _tailElements)
            {
                if ((targetPosition - tail.transform.position).sqrMagnitude > 
                    tail.GetComponent<MeshRenderer>().bounds.size.z /2)
                    
                    (tail.transform.position, targetPosition) = (targetPosition, tail.transform.position);

                else
                    break;
            }
            
        }

    }
