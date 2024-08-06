using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.TextCore.Text;

public class IdleStatePlayer : StatePlayer
{
 
    public IdleStatePlayer(PlayerManager playerManager) :
    base(playerManager)
    { }

    public override void Enter()
    {

    }
    public override void Update()
    {
        Idle();

        if (PlayerController.Instance.curSpeedX != 0 || PlayerController.Instance.curSpeedY != 0)
        {

            _playerManager.SetState(new MoveStatePlayer(_playerManager));

        }
    }

    private void Idle()
    {
      
        PlayerManager.Instance.animator.SetBool("isMove", false);
       

    }

    public override void Exit()
    {
        base.Exit();
    }


}
