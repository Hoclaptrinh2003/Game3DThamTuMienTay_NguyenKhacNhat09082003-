using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class MoveStatePlayer : StatePlayer
{
    public MoveStatePlayer(PlayerManager playerManager) :
       base(playerManager)
    { }
    private float footstepTimer = 0.5f; 
    private float footstepTimeElapsed = 0f; 
    public override void Enter()
    {
        footstepTimeElapsed = 0f;

    }
    public override void Update()
    {

        Move();
        HandleFootsteps();
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
    private void HandleFootsteps()
    {
        footstepTimeElapsed += Time.deltaTime;

        if (footstepTimeElapsed >= footstepTimer)
        {
            AudioManager.Instance.PlayFootstepSound();

            footstepTimeElapsed = 0f;
        }
    }



    public override void Exit()
    {
        base.Exit();
    }
}
