using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerMonster : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        UpdateAnimMonster();
    }
    public void UpdateAnimMonster()
    {
        anim.SetBool(ANIM_PARAM_Monster.Move, Monster_Animation_Manager.Instance.running);
        anim.SetBool(ANIM_PARAM_Monster.Attack, Monster_Animation_Manager.Instance.attacking);
        anim.SetBool(ANIM_PARAM_Monster.Dead, Monster_Animation_Manager.Instance.dead);
    }

    public struct ANIM_PARAM_Monster
    {
        public const string Move = "isMove";
        public const string Attack = "isAttack";
        public const string Dead = "isDead";
    }
}
