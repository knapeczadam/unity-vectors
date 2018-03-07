using UnityEditor;
using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
    public class _2D_12_Acceleration : MonoBehaviour
    {
        private GameObject _player;
        private Rigidbody2D _rigidbody;
    
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
    
        // Use this for initialization
        void Start()
        {
            // https://www.geogebra.org/m/d7vZRB8r
            
            _player = GameObject.FindWithTag(Constant.PLAYER_2D);
            _rigidbody = _player.GetComponent<Rigidbody2D>();
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
             *
             * Q: Default value of AddForce's mode is ForceMode2D.Impulse. True or false?
             *
             * Q: ForceMode2D.Force is a constant. True or false?
             *
             * Q: Is there any difference between using Constant Force 2D componenet and AddForce (applied on Rigidbody2D)?
             */
            _rigidbody.AddForce(_acceleration);
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
