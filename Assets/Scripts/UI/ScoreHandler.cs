
    using UnityEngine;
    using UnityEngine.UI;

    public class ScoreHandler : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        private Player _player;

        private void Awake()
        {
            _player = FindObjectOfType<Player>();
            _scoreText.text += _player.Score;

        }

        private void OnEnable()
        {
            _player.ScoreChanged += OnScoreChanged;
            
        }

        private void OnDisable()
        {
            _player.ScoreChanged -= OnScoreChanged;
            
        }

        private void OnScoreChanged(int score)
        {
            _scoreText.text = "Score: " +  score;
            
        }
        
    }
