 using UnityEngine;

 public class TailElement : MonoBehaviour
 {
     public float Size { get; private set; }

     private void Awake()
     {
         Size = GetComponent<SpriteRenderer>().size.SqrMagnitude();
         
     }
 }