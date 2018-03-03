using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
    public class _2D_19_SmoothDamp : MonoBehaviour
    {
        private GameObject _player;
        private Vector2 _playerPosition;
		
        [Header("Player")]
		
        [_CA_Color(_Color.Red, order = 0)]
        [_CA_Range("X", -50, 50, order = 1)]
        [SerializeField]
        private float _playerX;
		
        [_CA_Color(_Color.Green, order = 0)]
        [_CA_Range("Y", -50, 50, order = 1)]
        [SerializeField]
        private float _playerY;
        
        // -----
        
        private GameObject _enemy;
        
        // -----
        
        [Space]        

        [_CA_ReadOnly]
        [SerializeField]
        private Vector2 _currentVelocity = Vector2.zero;
        
        [_CA_Color(_Color.Cyan, order = 0)]
        [_CA_Range(0, 10, order = 1)]
        [SerializeField]
        private float _smoothTime;
        
        [_CA_Color(_Color.Yellow, order = 0)]
        [_CA_Range(0, 100, order = 1)]
        [SerializeField]
        private float _maxSpeed;
        
        // Use this for initialization
        void Start()
        {
            _player = GameObject.FindWithTag(Constant.PLAYER_2D);
            _enemy = GameObject.FindWithTag(Constant.ENEMY_2D);
        }
    
        // Update is called once per frame
        void Update()
        {
            UpdatePosition();
        }
        
        /*
         * Q: Difference between Vector2.SmoothDamp and Mathf.SmoothDamp?
         *
         * Q: What is ref in C#?
         *
         * Q: This version of SmoothDamp also works: SmoothDamp(Vector2 current, Vector2 target, ref Vector2 currentVelocity, float smoothTime, float maxSpeed = Mathf.Infinity, float deltaTime = Time.deltaTime). True or false?
         */
        private void LateUpdate()
        {
            _enemy.transform.position = SmoothDamp(_enemy.transform.position, _playerPosition, ref _currentVelocity, _smoothTime, _maxSpeed);
        }
        
        private static Vector2 SmoothDamp(Vector2 current, Vector2 target, ref Vector2 currentVelocity, float smoothTime, float maxSpeed = Mathf.Infinity)
        {
            float deltaTime = Time.deltaTime;
            smoothTime = Mathf.Max(0.0001f, smoothTime);
            float num1 = 2f / smoothTime;
            float num2 = num1 * deltaTime;
            float num3 = (float) (1.0 / (1.0 + (double) num2 + 0.479999989271164 * (double) num2 * (double) num2 + 0.234999999403954 * (double) num2 * (double) num2 * (double) num2));
            Vector2 vector = current - target;
            Vector2 vector2_1 = target;
            float maxLength = maxSpeed * smoothTime;
            Vector2 vector2_2 = Vector2.ClampMagnitude(vector, maxLength);
            target = current - vector2_2;
            Vector2 vector2_3 = (currentVelocity + num1 * vector2_2) * deltaTime;
            currentVelocity = (currentVelocity - num1 * vector2_3) * num3;
            Vector2 vector2_4 = target + (vector2_2 + vector2_3) * num3;
            if ((double) Vector2.Dot(vector2_1 - current, vector2_4 - vector2_1) > 0.0)
            {
                vector2_4 = vector2_1;
                currentVelocity = (vector2_4 - vector2_1) / deltaTime;
            }
            return vector2_4;
        }
        
        private void UpdatePosition()
        {
            _playerPosition = new Vector2(_playerX, _playerY);
            _player.transform.position = _playerPosition;
        }
    }
}
