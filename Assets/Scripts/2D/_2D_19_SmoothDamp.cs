using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
    public class _2D_19_SmoothDamp : _2D_Base
    {
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
            _debugLines = false;
            
            _player = GameObject.FindWithTag(Constant.PLAYER_2D);
            _enemy = GameObject.FindWithTag(Constant.ENEMY_2D);
        }
    
        // Update is called once per frame
        void Update()
        {
            UpdatePlayerPosition();
        }
        
        /*
         * Q: Difference between Vector2.SmoothDamp and Mathf.SmoothDamp?
         *
         * Q: What is ref in C#?
         *
         * Q: This version of SmoothDamp also works: SmoothDamp(Vector2 current, Vector2 target, ref Vector2 currentVelocity, float smoothTime, float maxSpeed = Mathf.Infinity, float deltaTime = Time.deltaTime). True or false?
         *
         * Q: LateUpdate is always called before Update. True or false?
         *
         * Q: What is the execution order of event functions in Unity?
         *
         * Q: You can use the Script Execution Order settings (menu: Edit > Preferences... > 2D > Execution Order). True or false?
         */
        protected override void LateUpdate()
        {
            _enemy.transform.position = SmoothDamp(_enemy.transform.position, _playerPosition, ref _currentVelocity, _smoothTime, _maxSpeed);
        }
        
        private Vector2 SmoothDamp(Vector2 current, Vector2 target, ref Vector2 currentVelocity, float smoothTime, float maxSpeed = Mathf.Infinity)
        {
            // Based on Game Programming Gems 4 Chapter 1.10
            float deltaTime = Time.deltaTime;
            smoothTime = Mathf.Max(0.0001F, smoothTime);
            float omega = 2F / smoothTime;

            float x = omega * deltaTime;
            float exp = 1F / (1F + x + 0.48F * x * x + 0.235F * x * x * x);
            Vector2 change = current - target;
            Vector2 originalTo = target;

            // Clamp maximum speed
            float maxChange = maxSpeed * smoothTime;
            change = Vector2.ClampMagnitude(change, maxChange);
            target = current - change;

            Vector2 temp = (currentVelocity + omega * change) * deltaTime;
            currentVelocity = (currentVelocity - omega * temp) * exp;
            Vector2 output = target + (change + temp) * exp;

            // Prevent overshooting
            if (Vector2.Dot(originalTo - current, output - originalTo) > 0)
            {
                output = originalTo;
                currentVelocity = (output - originalTo) / deltaTime;
            }

            return output;
        }
    }
}
