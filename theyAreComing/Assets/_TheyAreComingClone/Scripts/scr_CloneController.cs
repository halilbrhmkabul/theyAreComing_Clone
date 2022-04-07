using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scr_CloneController : MonoBehaviour
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
            transform.LookAt(scr_PlayerController.Instance.transform.forward);
        }
    }

    IEnumerator waitNavMesh()
    {
        yield return new WaitForSeconds(.1f);
         navMeshAgentClone.enabled=true;
         GetComponent<BoxCollider>().isTrigger=true;

        StartCoroutine(Shoot());
    }


    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1f);
        if (scr_UiManager.Instance.GameActive)
        {
            yield return new WaitForSeconds(Random.Range(0,1f)); 
            scr_PoolBullet.Instance.ShootBullet(transform.position + new Vector3(0,0,0.1f));
            StartCoroutine(Shoot());
        }
        else
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(Shoot());
        }
    }
}
