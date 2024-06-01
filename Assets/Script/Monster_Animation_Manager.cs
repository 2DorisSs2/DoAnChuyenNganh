using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class Monster_Animation_Manager : Singleton<Monster_Animation_Manager>
{
    public bool running;
    public bool attacking;
    public bool dead;
}
