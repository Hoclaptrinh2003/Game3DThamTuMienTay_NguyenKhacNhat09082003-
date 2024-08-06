using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MoveStatePlayer : StatePlayer
{
    public MoveStatePlayer(PlayerManager playerManager) :
       base(playerManager)
    { }

    public override void Enter()
    {

    }
    public override void Update()
    {

        Move();
        if(PlayerController.Instance.curSpeedX==0 && PlayerController.Instance.curSpeedY == 0)
        {
           
            _playerManager.SetState(new IdleStatePlayer(_playerManager));

        }
    }

    private void Move() 
    {
        PlayerManager.Instance.animator.SetBool("isMove", true);
        PlayerManager.Instance.animator.SetFloat("Stafe", PlayerController.Instance.curSpeedX);
        PlayerManager.Instance.animator.SetFloat("Foward", PlayerController.Instance.curSpeedY);

    }
    public override void Exit()
    {
        base.Exit();
    }
}
