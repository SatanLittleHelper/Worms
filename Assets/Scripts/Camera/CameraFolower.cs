using UnityEngine;

    public class CameraFolower : MonoBehaviour
    {
        [SerializeField]private float _distance = 10f;
        private Camera _camera;
        private Player _player;

        private void Start()
        {
            _camera = Camera.main;
            _player = FindObjectOfType<Player>();
            
        }

        private void LateUpdate()
        {
            var playerPosition = _player.transform.position;
            var targetPosition =
                new Vector3(playerPosition.x, playerPosition.y, _player.transform.position.z - _distance);
            _camera.transform.position = targetPosition;

        }
    }
