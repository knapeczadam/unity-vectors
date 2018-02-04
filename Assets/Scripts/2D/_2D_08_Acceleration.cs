using UnityEditor;
using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
    public class _2D_08_Acceleration : MonoBehaviour
    {
        private GameObject _player;
        private Rigidbody _rigidbody;
    
        [Header("Player")] 
        [_CA_ReadOnlyLabel("Position")]
        [SerializeField]
        private Vector2 _playerPosition;
    
        [_CA_ReadOnly]
        [SerializeField]
        private Vector2 _velocity;
        
        private readonly Vector2 _acceleration = Vector2.one;
    
        private int _counter = 1;
        private float _timer;
    
    
        private void OnEnable()
        {
            _player = GameObject.FindWithTag(Constant.PLAYER_2D);
            _rigidbody = _player.GetComponent<Rigidbody>();
        }
    
        // Use this for initialization
        void Start()
        {
            // https://www.geogebra.org/m/d7vZRB8r
        }
        
        
        /*
         * Q: What's the difference between Update() and FixedUpdate()?
         *
         * Q: Which function should be used?
         */
        // Update is called once per frame
        void Update()
        {
            _timer += Time.deltaTime;
            Debug.Log(_timer);
            
            /*
             * Q: Value of x (Player Position) will be 8.5 after 4 seconds in game mode. True or false?
             *
             * Q: How can you calculate the position of an accelerating body after a certain time?
             */
            _rigidbody.AddForce(_acceleration, ForceMode.Acceleration);
            _velocity = _rigidbody.velocity;
    
            _playerPosition = _player.transform.position;
            
            if (_counter <= 40 && _playerPosition.x >= _counter)
            {
                DoBeep();
                ++_counter;
            }
        }
    
        private void DoBeep()
        {
            EditorApplication.Beep();
        }
        
        
        // https://answers.unity.com/questions/45676/making-a-timer-0000-minutes-and-seconds.html
        void OnGUI()
        {
            string minutes = Mathf.Floor(_timer / 60).ToString("00");
            string seconds = Mathf.Floor(_timer % 60).ToString("00");
    
            GUI.Label(new Rect(10, 10, 250, 100), minutes + ":" + seconds);
        }
    }
}
