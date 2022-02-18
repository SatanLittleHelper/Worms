
using System;
using UnityEngine;
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Control))]
[RequireComponent(typeof(SpeedUpControl))]

public class Player : MonoBehaviour
{
   [SerializeField] private float _speed = 5;
   [SerializeField] private int _tailElementPrice = 5;
   private Mouth _mouth;
   private SpeedUpControl _speedUpControl;

   #region Events

   public event Action Die;
   public event Action<bool> ChangeTail;
   public event Action<int> ScoreChanged;

   #endregion

   #region Properties

   public Vector3 Direction { get; set; } = Vector3.left;
   public float Speed => _speed;
   public int Score { get; private set; } = 10;

   #endregion
  
   private void Awake()
   {
       _mouth = GetComponentInChildren<Mouth>();
       _speedUpControl = GetComponent<SpeedUpControl>();

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
       ChangeScore(score);
       ChangeTailElementCount(addElement: false);
       
   }

   private void OnEat(int count)
   {
       ChangeScore(count);
       ChangeTailElementCount(addElement: true);
       
   }

   private void ChangeScore(int score)
   {
       Score += score;
       ScoreChanged?.Invoke(Score);

   }

   private void ChangeTailElementCount(bool addElement)
   {
       if (Score % _tailElementPrice != 0 || Score <= 10) return;
       ChangeTail?.Invoke(addElement);
       
   }

   private void OnTriggerExit2D(Collider2D other)
   {
       
       if (other.TryGetComponent(typeof(GameDesk), out _))
           Die?.Invoke();
       
   }
   
}
