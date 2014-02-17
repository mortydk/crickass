using UnityEngine;
using System.Collections;

public class PlayerKill : MonoBehaviour, IKillable
{  
    public void Kill()
    {
       Application.LoadLevel("GameOver");
    }
}
