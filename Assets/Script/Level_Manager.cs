﻿using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Level_Manager : Singleton<Level_Manager>
{
    public ButtonState[] buttonStates;
    public Transform Position_Monster;
    public Transform Pos_Player;
    public TimeScript timescript;
    public List_Answer_Dialog ui;
    private Vector3 tem_pos_1;
    private Vector3 tem_pos_2;
    public float elapsedTime = 0f;
    public float elapsedTime2 = 0f;
    private float duration = 15f;
    private bool isMove =  false;
    private bool isPlayerMove = false;
    public float speed;
    private float regionalMonsterSpeed;
    private float distance;
    private Vector3 start;
    private Vector3 end;
    public Monster_Animation_Manager monster_anim;
    public Player_Animation_Manager player_anim;
    private bool isAttack = false;
    private bool isPlayerAttack = false;
    private bool isDead = false;
    private bool isPlayerDead = false;
    private bool isHit = false;
    //private int numberquestlose = 0;
    public int numberquest = 0;
    public Heal_UI_Manager heal_ui_mg;
    public Transform parent;
    //private bool isMoving = false;
    //public float speed = 0.1f;
    void Start()
    {
        start = Position_Monster.position;
        end = Pos_Player.position;
        ListButtonStates();
        isMove = true;
        distance = Vector3.Distance(start, end);
        speed = distance/duration;
        regionalMonsterSpeed = speed;
        tem_pos_1 = Position_Monster.transform.position;
        tem_pos_2 = Pos_Player.transform.position;
    }

    void Update()
    { 
        foreach (ButtonState buttonState in buttonStates)
        {
            if (buttonState.currentValue)
            {
                isPlayerMove = true;
                buttonState.currentValue = false;
                SoundManager.Instance.PlaySFX("True");
            }
        }
        if(isMove)
        {
            Monster_Move();
        }
        if(isPlayerMove)
        {
            Player_Move();
        }
        Anim_Monster();
        Anim_Player();
    }

    public void Move()
    {
        Position_Monster.position = Vector3.MoveTowards(Position_Monster.position,end,speed * Time.deltaTime);
        //SoundManager.Instance.PlaySFX("Run");
    }

    public void NextQuestion ()
    {
        numberquest++;
        ui.Show();
        Reset();
    }

    public void Reset()
    {
        Position_Monster.position = tem_pos_1;
        Pos_Player.position = tem_pos_2;
        timescript.slider_timer.value = timescript.slider_timer.maxValue;
        timescript.endtime = false;
        timescript._time = 14;
        ChangeMonsterStatus.Instance.AliveStatus();
        ChangeStatus.Instance.AliveStatus();
        speed = regionalMonsterSpeed;
        isMove = true;
        ListButtonStates();
    }

    public void Monster_Move()
    {
        float distance = Vector3.Distance(Position_Monster.position, Pos_Player.position);
        Debug.Log(distance);
        elapsedTime += Time.deltaTime;
        if (elapsedTime <= duration)
        {
            Move();
        }
        if (distance <= 1.75f)
        {
            DisableAllButtonStates();
            isMove = false;
            isAttack = true;
            SoundManager.Instance.PlaySFX("Slash");
            StartCoroutine(AnimAttackAndDieMonster());
        }
        if(timescript.endtime == true)
        {
            isMove = false;
        }
        //isAttack = false;
    }

    public void Anim_Monster()
    {
        Monster_Animation_Manager.Instance.running = isMove;
        Monster_Animation_Manager.Instance.attacking = isAttack;
        Monster_Animation_Manager.Instance.dead = isDead;
    }
    public void Anim_Player()
    {
        Player_Animation_Manager.Instance.running = isPlayerMove;
        Player_Animation_Manager.Instance.attacking = isPlayerAttack;
        Player_Animation_Manager.Instance.dead = isPlayerDead;
        Player_Animation_Manager.Instance.hit = isHit;
    }

    IEnumerator AnimAttackAndDieMonster()
    {
        yield return new WaitForSeconds(0.45f);
        isAttack = false;
        if(numberquest >= 3)
        {
            isPlayerDead = true;
            yield return new WaitForSeconds(0.40f);
            isPlayerDead = false;
            ChangeStatus.Instance.DeadStatus();
            elapsedTime = 0;
            elapsedTime2 = 0;
            yield return new WaitForSeconds(2f);
            heal_ui_mg.DropHealth();
            yield return new WaitForSeconds(2f);
            NextQuestion();
        }
        else
        {
            isHit = true;
            yield return new WaitForSeconds(0.40f);
            isHit = false;
            //isPlayerDead = false;
            //ChangeStatus.Instance.DeadStatus();
            elapsedTime = 0;
            elapsedTime2 = 0;
            yield return new WaitForSeconds(2f);
            heal_ui_mg.DropHealth();
            yield return new WaitForSeconds(2f);
            NextQuestion();
        }
       
    }
    public void Player_Move()
    {
        DisableAllButtonStates();
        timescript.endtime = true;
        float temp = Vector3.Distance(Position_Monster.position,end);
        float _speed = temp / 5f;
        elapsedTime2 += Time.deltaTime;
        Debug.Log(elapsedTime2);
        Debug.Log(Vector3.Distance(Pos_Player.position, Position_Monster.position));
        //Debug.Log(isPlayerMove);
        if (elapsedTime2 <= 5f)
        {
            Pos_Player.position = Vector3.MoveTowards(Pos_Player.position, Position_Monster.position, _speed * Time.deltaTime);
            //SoundManager.Instance.PlaySFX("Run");
        }
        if(Vector3.Distance(Pos_Player.position, Position_Monster.position) <= 1.75f)
        {
            isPlayerMove = false;
            isPlayerAttack = true;
            SoundManager.Instance.PlaySFX("Slash");
            StartCoroutine(AnimAttackAndDiePlayer());
        }
        
    }
    IEnumerator AnimAttackAndDiePlayer()
    {
        yield return new WaitForSeconds(0.45f);
        isPlayerAttack = false;
        isDead = true;
        yield return new WaitForSeconds(0.40f);
        isDead = false;
        ChangeMonsterStatus.Instance.DeadStatus();
        elapsedTime = 0;
        elapsedTime2 = 0;
        yield return new WaitForSeconds(2f);
        NextQuestion();
        timescript.StartTime();
    }

    public void ListButtonStates()
    {
       buttonStates = FindObjectsOfType<ButtonState>();
    }
    public void DisableAllButtonStates()
    {
        for (int i = 0;i < 4; i++ )
        {
            buttonStates[i].GetComponent<Button>().interactable = false;
        }
    }
}