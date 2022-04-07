using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Obstacle : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("PlayerClone"))
        {
            Debug.Log("sa");
            scr_PoolPlayer.Instance.CloseClone(other.gameObject);
        }

        if (other.CompareTag("Player") && scr_PoolPlayer.Instance.PoolPlayerClonesActives.Count==0)
        {
            scr_UiManager.Instance.LoseGame();
        }
    }
}
