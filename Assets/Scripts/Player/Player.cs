
using System;
using UnityEngine;
[RequireComponent(typeof(Mover))]

public class Player : MonoBehaviour
{
   [SerializeField] private float _speed = 5;

   public event Action Die;
   
   public Vector3 Direction { get; set; } = Vector3.left;

   public float Speed => _speed;


   private void OnTriggerExit2D(Collider2D other)
   {
       
       if (other.TryGetComponent(typeof(GameDesk), out _))
           Die?.Invoke();
   }
}
