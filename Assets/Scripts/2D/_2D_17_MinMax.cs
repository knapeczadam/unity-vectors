using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
    [ExecuteInEditMode]
    public class _2D_17_MinMax : _2D_Base
    {
        [Header("Enemy")]
        [_CA_Color(_Color.Red, order = 0)]
        [_CA_Range("X", -50, 50, order = 1)]
        [SerializeField]
        private float _enemyX;
		
        [_CA_Color(_Color.Green, order = 0)]
        [_CA_Range("Y", -50, 50, order = 1)]
        [SerializeField]
        private float _enemyY;
        
        // -----
        
        [Space]

        [_CA_ReadOnly]
        [SerializeField]
        private Vector2 _min;
        
        [_CA_ReadOnly]
        [SerializeField]
        private Vector2 _max;

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
            UpdatePlayerPosition();
            UpdateEnemyPosition(_enemyX, _enemyY);

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
        }
        
        /*
         * Q: This is the correct way to implement Unity's Vector2.Max function. True or false?
         */
        public static Vector2 Max(Vector2 lhs, Vector2 rhs)
        {
            return lhs.sqrMagnitude > rhs.sqrMagnitude ? lhs : rhs;
        }
        
        protected override void DebugLines()
        {
            Debug.DrawLine(_zero, _playerPosition, Color.green);
            Debug.DrawLine(_zero, _enemyPosition, Color.red);
            Debug.DrawLine(_zero, _min, Color.cyan);
            Debug.DrawLine(_zero, _max, Color.blue);
        }
    }
}