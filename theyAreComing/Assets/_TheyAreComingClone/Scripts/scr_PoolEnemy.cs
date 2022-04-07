using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scr_PoolEnemy : MonoBehaviour
{
    public static scr_PoolEnemy Instance;

    [SerializeField] GameObject enemyClone;
    public List<GameObject> PoolEnemyClones; 

    [SerializeField] int poolSize;
    [SerializeField] Transform poolParentTransform;



    //-------------------------------------------------


    GameObject poolObject;
    int enemyCount;

 void Awake()
   {
        if(Instance==null)
            Instance = this;
        else
            Destroy(Instance); 
   }

   void Start()
   {

       for(int i=0; i<poolSize;i++)
       {
            PoolEnemyClones.Add(Instantiate(enemyClone, Vector3.zero, Quaternion.identity, poolParentTransform));
            PoolEnemyClones[i].transform.localPosition = new Vector3(Random.Range(0f,1f),0,Random.Range(0f,1f));
            PoolEnemyClones[i].SetActive(false);
        }

        StartCoroutine(CallEnemy());
    }

    IEnumerator CallEnemy()
    {
        yield return new WaitForSeconds(.25f);

        if (scr_UiManager.Instance.GameActive)
        {
            PoolEnemyClones[enemyCount].SetActive(true);
            enemyCount++;
        }
        if (enemyCount<poolSize)
        {
            StartCoroutine(CallEnemy());
        }
        

    }

 
}
