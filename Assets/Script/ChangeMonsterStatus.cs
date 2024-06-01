using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMonsterStatus : Singleton<ChangeMonsterStatus>
{
    public Transform Alive;
    public Transform Dead;
    private void Awake()
    {
        //Debug.LogError(Dead.position);
    }
    public void DeadStatus()
    {
        Alive.gameObject.SetActive(false);
        Dead.gameObject.SetActive(true);
        Dead.position = new Vector3(Alive.position.x, -5.67f, Alive.position.z);
    }

    public void AliveStatus()
    {
        Alive.gameObject.SetActive(true);
        Dead.gameObject.SetActive(false);
    }
}
