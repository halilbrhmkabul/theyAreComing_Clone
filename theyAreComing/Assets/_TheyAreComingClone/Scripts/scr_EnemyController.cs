using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scr_EnemyController : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgentClone;
 
    void Start()
    { 
       StartCoroutine(waitNavMesh());
    }



    void Update()
    {
        if(scr_UiManager.Instance.GameActive && navMeshAgentClone.isActiveAndEnabled)
        { 
        navMeshAgentClone.SetDestination(scr_PlayerController.Instance.TargetNavMesh.position);
            //transform.LookAt(-scr_PlayerController.Instance.transform.forward);
        }
        else if (!scr_UiManager.Instance.GameActive && navMeshAgentClone.isActiveAndEnabled)
        {
            navMeshAgentClone.enabled = false;
            GetComponent<Animator>().Play("Idle");
            enabled = false;
        }
    }

    IEnumerator waitNavMesh()
    {
        yield return new WaitForSeconds(.1f);
         navMeshAgentClone.enabled=true;
         GetComponent<BoxCollider>().isTrigger=true;
         
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
        }

        if (other.CompareTag("PlayerClone"))
        {
            scr_PoolPlayer.Instance.CloseClone(other.gameObject);
        }
        if (other.CompareTag("Player") && scr_PoolPlayer.Instance.PoolPlayerClonesActives.Count == 0)
        {
            scr_UiManager.Instance.LoseGame();
        }
    }
}
