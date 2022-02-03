
using System;
using UnityEngine;
[RequireComponent(typeof(Mover))]

public class Player : MonoBehaviour
{
   [SerializeField] private float _speed = 5;
   private Mouth _mouth;
   private Tail _tail;
   private int _score;
   private int _minimumScore;

   public event Action Die;
   public event Action AddTailElement;
   public Vector3 Direction { get; set; } = Vector3.left;
   public float Speed => _speed;

   private void Awake()
   {
       _mouth = GetComponentInChildren<Mouth>();
       _tail = FindObjectOfType<Tail>();
       _score = _tail.Lenth * 2;
       _minimumScore = _score;

   }

   private void OnEnable()
   {
       _mouth.Eat += OnEat;
       
   }

   private void OnDisable()
   {
       _mouth.Eat -= OnEat;
       
   }

   private void OnEat(int count)
   {
       _score += count;
       CheckScoreForAddTailElement();
   }

   private void CheckScoreForAddTailElement()
   {
       if (_score == _minimumScore) return;
       
       if (_score % 2 == 0)
           AddTailElement?.Invoke();
       
   }

   private void OnTriggerExit2D(Collider2D other)
   {
       
       if (other.TryGetComponent(typeof(GameDesk), out _))
           Die?.Invoke();
   }
}
