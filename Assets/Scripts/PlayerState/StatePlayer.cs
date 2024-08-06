using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class StatePlayer
{
    protected PlayerManager _playerManager;
   
    public StatePlayer(PlayerManager playerManager)
    {
        _playerManager = playerManager;
    }


    public virtual void Enter() { }

    public virtual void Update() { }
    public virtual void Exit() { }
}
