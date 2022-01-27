
using UnityEngine;
[RequireComponent(typeof(Mover))]

public class Player : MonoBehaviour
{
   [SerializeField] private float _speed = 5;
   // [SerializeField] private float _sensitivity;

   public Vector3 Direction { get; set; } = Vector3.left;


   public float Speed => _speed;
   // public float Sensitivity => _sensitivity;

}
