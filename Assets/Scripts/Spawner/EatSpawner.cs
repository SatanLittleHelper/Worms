
    using Unity.Mathematics;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public class EatSpawner : MonoBehaviour
    {
        private int _count;
        private const string _EatPrefabPath = "Prefabs/Eat";
        private GameDesk _desk;
        
        private void Start()
        {
            _desk = FindObjectOfType<GameDesk>();
            _count = (int)_desk.Size.x * (int)_desk.Size.y / 5 ;
            Spawn();

        }

        private Vector3 GetRandomPositionForSpawn()
        {
            return new Vector3(Random.Range((-_desk.Size.x +1) / 2, (_desk.Size.x -1)  / 2),
                Random.Range((-_desk.Size.y +1) / 2, (_desk.Size.y -1)  / 2), transform.position.z);
            
        }

        private void Spawn()
        {
            for (int i = 0; i <= _count; i++)
            {
                Instantiate(Resources.Load<Eat>(_EatPrefabPath), GetRandomPositionForSpawn(), quaternion.identity, transform);
                
            }
            
        }
        
    }
