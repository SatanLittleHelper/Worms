
using System;
using UnityEngine;
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Control))]
[RequireComponent(typeof(SpeedUpControl))]

public class Player : MonoBehaviour
{
   [SerializeField] private float _speed = 5;
   private Mouth _mouth;
   private SpeedUpControl _speedUpControl;
   private int _score = 10;

   public event Action Die;
   public event Action AddTailElement;
   
   public Vector3 Direction { get; set; } = Vector3.left;
   public float Speed => _speed;
   public int Score => _score;

   private void Awake()
   {
       _mouth = GetComponentInChildren<Mouth>();
       _speedUpControl = GetComponent<SpeedUpControl>();

   }

   private void Update()
   {
       Debug.Log(_score);
       
   }

   private void OnEnable()
   {
       _mouth.Eat += OnEat;
       _speedUpControl.ScoreChanged += OnScoreChanged;
       _speedUpControl.SpeedChanged += OnSpeedChanged;


   }

   private void OnDisable()
   {
       _mouth.Eat -= OnEat;
       _speedUpControl.ScoreChanged -= OnScoreChanged;
       _speedUpControl.SpeedChanged -= OnSpeedChanged;
       
   }

   private void OnSpeedChanged(float speed)
   {
       _speed = speed;
       
   }

   private void OnScoreChanged(int score)
   {
       _score += score;
       
   }

   private void OnEat(int count)
   {
       _score += count;
       CheckScoreForAddTailElement();
       
   }

   private void CheckScoreForAddTailElement()
   {
       if (_score % 2 == 0)
           AddTailElement?.Invoke();
       
   }

   private void OnTriggerExit2D(Collider2D other)
   {
       
       if (other.TryGetComponent(typeof(GameDesk), out _))
           Die?.Invoke();
   }
}
