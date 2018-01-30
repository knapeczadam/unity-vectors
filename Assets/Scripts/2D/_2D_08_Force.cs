using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class _2D_08_Force : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody _rigidbody;

    [Header("Player")] 
    [ReadOnly] 
    public Vector2 PlayerPosition;

    [ReadOnly] 
    public Vector2 Velocity;
    
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

        
        /*
         * Q: Value of x (Player Position) will be 11.5 after 5 seconds in game mode. True or false?
         *
         * Q: How can you calculate the position of an accelerating body after a certain time?
         */
        _rigidbody.AddForce(_acceleration, ForceMode.Force);
        Velocity = _rigidbody.velocity;

        PlayerPosition = _player.transform.position;
        
        if (_counter <= 40 && PlayerPosition.x >= _counter)
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