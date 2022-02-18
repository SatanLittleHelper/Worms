using System;
using System.Collections;
using UnityEngine;


    public class SpeedUpControl : MonoBehaviour
    {
        private Control _control;
        private Player _player;
        private float _playerSpeed;
        private float _defaultPlayerSpeed;
        private int _minimumScore = 10;
        private int _score;
        private bool _speedUp;
        private Coroutine _speedUpRoutine;

        public event Action<float> SpeedChanged;
        public event Action<int> ScoreChanged;


        private void Awake()
        {
            _control = GetComponent<Control>();
            _player = GetComponent<Player>();
            _defaultPlayerSpeed = _playerSpeed = _player.Speed;

        }

        private void OnEnable()
        {
            _control.SpeedUp += OnSpeedUp;
            _control.SpeedDown += OnSpeedDown;
            
        }

        private void OnDisable()
        {
            _control.SpeedUp -= OnSpeedUp;
            _control.SpeedDown -= OnSpeedDown;
            
        }

        private void OnSpeedDown()
        {
           SpeedUp(speedUpEnable:false);
           
        }

        private void OnSpeedUp()
        {
           SpeedUp(SpeedUpPosible());
       
        }

        private bool SpeedUpPosible()
        {
            _score = _player.Score;
            return _score > _minimumScore;
            
        }

        private void SpeedUp(bool speedUpEnable)
        {
            if (!speedUpEnable)
            {
                _playerSpeed = _defaultPlayerSpeed;
                _speedUp = false;
                
                if (_speedUpRoutine == null) return;
                
                StopCoroutine(_speedUpRoutine);
                
            }
            else
            {
                if (_speedUp) return;
                
                _speedUp = true;
                _playerSpeed *= 2;
               
                _speedUpRoutine =  StartCoroutine(SpeedUpRoutine());

            }
            SpeedChanged?.Invoke(_playerSpeed);
            
        }

        private IEnumerator SpeedUpRoutine()
        {
            while (_speedUp)
            {
                ScoreChanged?.Invoke(-1);
                SpeedUp(SpeedUpPosible());
                yield return new WaitForSeconds(0.5f);

            }
            
        }
        
    }
