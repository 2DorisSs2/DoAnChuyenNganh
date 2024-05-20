using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStatus : Singleton<ChangeStatus>
{
    public Transform Alive;
    public Transform Dead;
    public void DeadStatus()
    {
        Alive.gameObject.SetActive(false);
        Dead.gameObject.SetActive(true);
    }

    public void AliveStatus()
    {
        Alive.gameObject.SetActive(true);
        Dead.gameObject.SetActive(false);
    }
}
