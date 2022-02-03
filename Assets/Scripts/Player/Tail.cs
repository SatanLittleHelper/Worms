    using System.Collections.Generic;
    using Unity.Mathematics;
    using UnityEngine;

    public class Tail : MonoBehaviour
    {
        [SerializeField] private List<TailElement> _tailElements;
        [SerializeField] private Player _player;
        private Mover _mover;
        private List<Coroutine> _allMoveCoroutines;
        
        
        public int Lenth { get; private set; }


        private void Awake()
        {
            _mover = FindObjectOfType<Mover>();
            _allMoveCoroutines = new List<Coroutine>();
            Lenth = _tailElements.Count;

        }

        private void OnEnable()
        {
            _mover.Moving += OnPlayerMoving;
            _player.AddTailElement += OnAddTailElement;
        } 
        
        private void OnDisable()
        {
            _mover.Moving -= OnPlayerMoving;
            _player.AddTailElement -= OnAddTailElement;
            
        }

        private void OnAddTailElement()
        {
            var element = _tailElements[_tailElements.Count - 1];
            element = Instantiate(element, element.transform.position, quaternion.identity, transform);
            element.name = "element" + (_tailElements.Count + 1);
            _tailElements.Add(element);
            
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
                    tail.Size / 50)
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
