using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
    [ExecuteInEditMode]
    public class _2D_00_Direction : MonoBehaviour
    {
        [Space]
        
        [_CA_ReadOnly]
        [SerializeField]
        private Vector2 _direction;
    
        [Space]
        
        public bool Zero;
        public bool One;
        public bool Up;
        public bool Down;
        public bool Left;
        public bool Right;
    
        // Can you setup these fields like the ones you see above (Zero, One, Up, etc.) ?
        public bool PositiveInfinity; // https://msdn.microsoft.com/en-us/library/system.single.positiveinfinity(v=vs.110).aspx
        public bool NegativeInfitiny; // https://msdn.microsoft.com/en-us/library/system.single.negativeinfinity(v=vs.110).aspx
        
        /*
         * Q: What is Inertial frame of reference?
         */
        private BoolWrapper _zero;
        private BoolWrapper _one;
        private BoolWrapper _up;
        private BoolWrapper _down;
        private BoolWrapper _left;
        private BoolWrapper _right;
    
        private BoolWrapper[] _dirs;
        private int _current = -1;
    
        private class BoolWrapper
        {
            /*
             * Q: What is AutoProperty in C#?
             */
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
            };
        }
    
        // Use this for initialization
        void Start()
        {
            // https://www.geogebra.org/m/W2t2MDBe
        }
    
        // Update is called once per frame
        void Update()
        {
            UpdateWrappers();
            SetCurrent();
            _direction = UpdateDirection();
            Draw();
        }
    
        private void InitWrappers()
        {
            _zero = new BoolWrapper(false);
            _one = new BoolWrapper(false);
            _up = new BoolWrapper(false);
            _down = new BoolWrapper(false);
            _left = new BoolWrapper(false);
            _right = new BoolWrapper(false);
        }
    
        private void UpdateWrappers()
        {
            _zero.Value = Zero;
            _one.Value = One;
            _up.Value = Up;
            _down.Value = Down;
            _left.Value = Left;
            _right.Value = Right;
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
                        }
                    }
                }
            }
        }
    
        private Vector2 UpdateDirection()
        {
            Vector2 dir = new Vector2();
            if (Zero)
            {
                dir = Vector2.zero;
            }
            else if (One)
            {
                dir = Vector2.one;
            }
            else if (Up)
            {
                dir = Vector2.up;
            }
            else if (Down)
            {
                dir = Vector2.down;
            }
            else if (Left)
            {
                dir = Vector2.left;
            }
            else if (Right)
            {
                dir = Vector2.right;
            }
    
            return dir;
        }
    
        private void Draw()
        {
            Debug.DrawLine(Vector2.zero, _direction, Color.cyan);
        }
    }
}
