using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
    [ExecuteInEditMode]
    public class _2D_17_MinMax : MonoBehaviour
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
        private Vector2 _enemyPosition;
        
        [Header("Enemy")]
        [_CA_Color(_Color.Red, order = 0)]
        [_CA_Range("X", -50, 50, order = 1)]
        [SerializeField]
        private float _enemyX;
		
        [_CA_Color(_Color.Green, order = 0)]
        [_CA_Range("Y", -50, 50, order = 1)]
        [SerializeField]
        private float _enemyY;
        
        [Space]

        [_CA_ReadOnly]
        [SerializeField]
        private Vector2 _min;
        
        [_CA_ReadOnly]
        [SerializeField]
        private Vector2 _max;

        private readonly Vector2 _zero = Vector2.zero;

        private void OnEnable()
        {
            _player = GameObject.FindWithTag(Constant.PLAYER_2D);
            _enemy = GameObject.FindWithTag(Constant.ENEMY_2D);
        }

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            UpdatePositions();

            /*
             * Q: Vector2.Min: Returns a vector that is made from the smallest components of two vectors. True or false?
             *
             * Q: What is Mathf?
             *
             * Q: Mathf class has a few instance methods. True or false?
             *
             * Q: What is static method?
             */
            _min = Vector2.Min(_playerPosition, _enemyPosition);
            _max = Max(_playerPosition, _enemyPosition);

            Draw();
        }
        
        /*
         * Q: This is the correct way to implement Unity's Vector2.Max function. True or false?
         */
        public static Vector2 Max(Vector2 lhs, Vector2 rhs)
        {
            return lhs.sqrMagnitude > rhs.sqrMagnitude ? lhs : rhs;
        }
        
        private void UpdatePositions()
        {
            _playerPosition = new Vector2(_playerX, _playerY);
            _player.transform.position = _playerPosition;
			
            _enemyPosition = new Vector2(_enemyX, _enemyY);
            _enemy.transform.position = _enemyPosition;
        }
        
        private void Draw()
        {
            Debug.DrawLine(_zero, _playerPosition, Color.green);
            Debug.DrawLine(_zero, _enemyPosition, Color.red);
            Debug.DrawLine(_zero, _min, Color.cyan);
            Debug.DrawLine(_zero, _max, Color.blue);
        }
    }
}