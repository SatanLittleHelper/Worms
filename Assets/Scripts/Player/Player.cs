
using UnityEngine;
[RequireComponent(typeof(Mover))]

public class Player : MonoBehaviour
{
   [SerializeField] private float _speed = 5;
   
   public Vector3 Direction { get; set; } = Vector3.left;

   public float Speed => _speed;

}
