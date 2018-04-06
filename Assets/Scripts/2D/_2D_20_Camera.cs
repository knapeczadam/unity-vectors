using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
    [ExecuteInEditMode]
    public class _2D_20_Camera : _2D_Base
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
	    
	    [_CA_Color(_Color.White, order = 0)]
	    [_CA_Range("Focus", 0, 1, order = 1)]
	    [SerializeField]
	    private float _t;
		
	    [_CA_Color(_Color.Cyan, order = 0)]
	    [_CA_Range(1, 10, order = 1)]
	    [SerializeField]
		private float _padding;
	    
	    [Space]

	    [SerializeField] 
	    private bool _manual;

	    [_CA_Range(1, 10)]
	    [SerializeField]
	    private float _zoom;
	    
	    [Space]
		
	    [SerializeField]
	    private Camera _camera;
	    
	    private void OnEnable()
	    {
		    _player = GameObject.FindWithTag(Constant.PLAYER_2D);
		    _enemy = GameObject.FindWithTag(Constant.ENEMY_2D);
		    
		    _t = 0.5f;
		    _padding = 1;
		    _zoom = 1;
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
        }

	    protected override void LateUpdate()
	    {
		    Zoom();

		    UpdateCameraPosition();

		    DebugLines();
	    }

	    private void Zoom()
	    {
		    float size;
		    if (_manual)
		    {
			    size = _zoom;
		    }
		    else
		    {
			    Vector2 offset = _playerPosition - _enemyPosition;
			    float height = Mathf.Abs(offset.y);
			    float width = Mathf.Abs(offset.x);
	
			    if (height < width)
			    {
				    size = width / 2;
			    }
			    else
			    {
				    size = height / 2;
			    }
		    }
			
		    /*
		     * Q: What is an ortographic camera?
		     *
		     * Q: There are three types of projection: perspective, ortographic and linear. True or false?
		     *
		     * Q: What is a camera's aspect?
		     */
		    _camera.orthographicSize = size * _padding;
	    }

	    private void UpdateCameraPosition()
	    {
		    Vector2 pos = Vector2.Lerp(_playerPosition, _enemyPosition, _t);
		    _camera.transform.position = new Vector3(pos.x, pos.y, -1);
	    }
	    
	    protected override void DebugLines()
	    {
		    Debug.DrawLine(_zero, _playerPosition, Color.green);
		    Debug.DrawLine(_zero, _enemyPosition, Color.red);
		    Debug.DrawLine(_playerPosition, _enemyPosition, Color.white);
		    DrawingHelper.DrawPoint(new Vector2(_camera.transform.position.x, _camera.transform.position.y), Color.white);
		    DrawingHelper.DrawRectangle(_camera.transform.position, _camera.orthographicSize * 4 / _padding, _camera.orthographicSize * 2 / _padding, Color.cyan);
	    }
    }
}