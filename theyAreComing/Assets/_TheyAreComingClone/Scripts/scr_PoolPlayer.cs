using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scr_PoolPlayer : MonoBehaviour
{
    public static scr_PoolPlayer Instance;

    [SerializeField] GameObject playerClone;
    public List<GameObject> PoolPlayerClones;
    public List<GameObject> PoolPlayerClonesActives;
    public List<GameObject> PoolPlayerClonesDeactives;

    [SerializeField] int poolSize;
    [SerializeField] Transform poolParentTransform;



    //-------------------------------------------------


    GameObject poolObject;

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
            PoolPlayerClones.Add(Instantiate(playerClone, Vector3.zero, Quaternion.identity, poolParentTransform));
            PoolPlayerClones[i].transform.localPosition = new Vector3(Random.Range(0f,1f),0,Random.Range(0f,1f));
            PoolPlayerClones[i].SetActive(false);
        }  
   }

    public void OpenClone()
    {
        if (!PoolPlayerClones[0].gameObject.activeSelf)
        {
            poolObject = PoolPlayerClones[0];
            PoolPlayerClones.RemoveAt(0);
            poolObject.SetActive(true);

            PoolPlayerClonesActives.Add(poolObject);
        }

        else
        {
            Debug.Log("Havuz aþýldý. Daha fazla clone koyamayýz.");
        }
    }

    public void CloseClone(GameObject closedObject)
    {  
            PoolPlayerClonesActives.Remove(closedObject);
             closedObject.SetActive(false);

            PoolPlayerClonesDeactives.Add(closedObject); 
    }
}
