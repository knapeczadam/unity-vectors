﻿using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
    [ExecuteInEditMode]
    public class _2D_18_Equal : MonoBehaviour
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

	    [_CA_ReadOnlyLabel("Approximately equal")]
	    [SerializeField]
	    private bool _equal;
	    
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

	        _equal = ApproximatelyEqual(_playerPosition, _enemyPosition);
	        
	        Draw();
        }
	    
	    private static bool ApproximatelyEqual(Vector2 lhs, Vector2 rhs)
	    {
		    /*
		     * Q: Vector2.kEpsilon is greater than 9.99999943962493E-11. True or false?
		     *
		     * Q: Vector2.kEpsilon is less than 0.00001. True or false?
		     *
		     * Q: What is casting?
		     *
		     * Q: This implementation is faster: (double) (lhs - rhs).magnitude < Vector2.kEpsilon. True or false?
		     */
		    return (double) (lhs - rhs).sqrMagnitude < Vector2.kEpsilon;
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
	    }
    }
}

