using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    private StatePlayer _currentState;
    public Animator animator;
   private void Start()
    {
        _currentState = new IdleStatePlayer(this);
        animator = GetComponent<Animator>();
    }

    private  void Update()
    {
        _currentState.Update();
    }

    public void SetState(StatePlayer state)
    {
        if (_currentState != null)
        {
            _currentState.Exit();

            _currentState = state;
            _currentState.Enter();
        }
    }
}
