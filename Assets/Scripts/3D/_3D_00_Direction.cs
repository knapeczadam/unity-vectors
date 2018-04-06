using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._3D
{
    [ExecuteInEditMode]
    public class _3D_00_Direction : MonoBehaviour
    {
        [Space]
        
        [_CA_ReadOnly]
        [SerializeField]
        private Vector3 _direction;
    
        [Space]
        
        public bool Zero;
        public bool One;
        public bool Up;
        public bool Down;
        public bool Left;
        public bool Right;
        public bool Forward;
        public bool Back;
    
        public bool PositiveInfinity; 
        public bool NegativeInfitiny;
        
        private BoolWrapper _zero;
        private BoolWrapper _one;
        private BoolWrapper _up;
        private BoolWrapper _down;
        private BoolWrapper _left;
        private BoolWrapper _right;
        private BoolWrapper _forward;
        private BoolWrapper _back;
    
        private BoolWrapper[] _dirs;
        private int _current = -1;
    
        private class BoolWrapper
        {
            public bool Value { get; set; }
    
            public BoolWrapper(bool value)
            {
                this.Value = value;
            }
        }
    
        private void OnEnable()
        {
            InitWrappers();
            _dirs = new[]
            {
                _zero,
                _one,
                _up,
                _down,
                _left,
                _right,
                _forward,
                _back
            };
        }
    
        // Use this for initialization
        void Start()
        {
            
        }
    
        // Update is called once per frame
        void Update()
        {
            UpdateWrappers();
            SetCurrent();
            _direction = UpdateDirection();
        }

        private void LateUpdate()
        {
            DebugLines();
        }

        private void InitWrappers()
        {
            _zero = new BoolWrapper(false);
            _one = new BoolWrapper(false);
            _up = new BoolWrapper(false);
            _down = new BoolWrapper(false);
            _left = new BoolWrapper(false);
            _right = new BoolWrapper(false);
            _forward = new BoolWrapper(false);
            _back = new BoolWrapper(false);
        }
    
        private void UpdateWrappers()
        {
            _zero.Value = Zero;
            _one.Value = One;
            _up.Value = Up;
            _down.Value = Down;
            _left.Value = Left;
            _right.Value = Right;
            _forward.Value = Forward;
            _back.Value = Back;
        }
    
        private void SetCurrent()
        {
            bool ticked = false;
            for (int i = 0; i < _dirs.Length; i++)
            {
                if (_current == -1 && _dirs[i].Value)
                {
                    _current = i;
                }
                if (_current >= 0 && _dirs[i].Value && i != _current)
                {
                    _dirs[_current].Value = false;
                    _current = i;
                }
                if (_dirs[i].Value)
                {
                    ticked = true;
                }
            }
            _current = ticked ? _current : -1;
    
            if (_current != -1)
            {
                for (int j = 0; j < _dirs.Length; j++)
                {
                    if (j != _current)
                    {
                        switch (j)
                        {
                            case 0:
                                Zero = false;
                                break;
                            case 1:
                                One = false;
                                break;
                            case 2:
                                Up = false;
                                break;
                            case 3:
                                Down = false;
                                break;
                            case 4:
                                Left = false;
                                break;
                            case 5:
                                Right = false;
                                break;
                            case 6:
                                Forward = false;
                                break;
                            case 7:
                                Back = false;
                                break;
                        }
                    }
                }
            }
        }
    
        private Vector3 UpdateDirection()
        {
            Vector3 dir = new Vector3();
            if (Zero)
            {
                dir = Vector3.zero;
            }
            else if (One)
            {
                dir = Vector3.one;
            }
            else if (Up)
            {
                dir = Vector3.up;
            }
            else if (Down)
            {
                dir = Vector3.down;
            }
            else if (Left)
            {
                dir = Vector3.left;
            }
            else if (Right)
            {
                dir = Vector3.right;
            }
            else if (Forward)
            {
                dir = Vector3.forward;
            }
            else if (Back)
            {
                dir = Vector3.back;
            }
    
            return dir;
        }
    
        private void DebugLines()
        {
            Debug.DrawLine(Vector3.zero, _direction, Color.cyan);
        }
    }
}
