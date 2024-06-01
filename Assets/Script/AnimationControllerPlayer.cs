using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerPlayer : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        UpdateAnimPlayer();
    }
    public void UpdateAnimPlayer()
    {
        anim.SetBool(ANIM_PARAM_Player.Move, Player_Animation_Manager.Instance.running);
        anim.SetBool(ANIM_PARAM_Player.Attack, Player_Animation_Manager.Instance.attacking);
        anim.SetBool(ANIM_PARAM_Player.Dead, Player_Animation_Manager.Instance.dead);
        anim.SetBool(ANIM_PARAM_Player.Hit, Player_Animation_Manager.Instance.hit);
    }

    public struct ANIM_PARAM_Player
    {
        public const string Move = "isMove";
        public const string Attack = "isAttack";
        public const string Dead = "isDead";
        public const string Hit = "isHit";
    }
}
