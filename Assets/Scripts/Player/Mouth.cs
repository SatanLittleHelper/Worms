
    using UnityEngine;

    public class Mouth : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(typeof(Eat), out _))
            {
                Debug.Log("eat");
                col.gameObject.SetActive(false);
            }
            
        }
    }
