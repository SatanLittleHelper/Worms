    using System.Collections.Generic;
    using Unity.Mathematics;
    using UnityEngine;

    public class Tail : MonoBehaviour
    {
        [SerializeField] private List<TailElement> _tailElements;
        [SerializeField] private Player _player;
        private Mover _mover;
        private List<Coroutine> _allMoveCoroutines;
        
        private void Awake()
        {
            _mover = FindObjectOfType<Mover>();
            _allMoveCoroutines = new List<Coroutine>();

        }

        private void OnEnable()
        {
            _mover.Moving += OnPlayerMoving;
            _player.ChangeTail += OnChangeTail;
        } 
        
        private void OnDisable()
        {
            _mover.Moving -= OnPlayerMoving;
            _player.ChangeTail -= OnChangeTail;
            
        }

        private void OnChangeTail(bool addElement)
        {
            var element = _tailElements[_tailElements.Count - 1];

            if (addElement)
            {
                element = Instantiate(element, element.transform.position, quaternion.identity, transform);
                element.name = "element" + (_tailElements.Count + 1);
                _tailElements.Add(element);

            }
            else
            {
                _tailElements.Remove(element);
                Destroy(element.gameObject);
                
            }
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
