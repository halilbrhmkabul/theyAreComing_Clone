using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PoolBullet : MonoBehaviour
{
    public static scr_PoolBullet Instance; 

    [SerializeField] GameObject bulletObject; 
    public List<GameObject> poolBulletObjects;

    [SerializeField] Transform poolParentTransform;
    public int PoolSize; 
    [SerializeField] Transform gunAimPos;

     private GameObject _shootBullet;
    private Rigidbody _shootBulletRB;

    void Awake()
   {
        if(Instance==null)
            Instance = this;
        else
            Destroy(Instance);

       for(int i=0; i<PoolSize;i++)
       {         
            poolBulletObjects.Add(Instantiate(bulletObject, Vector3.zero, Quaternion.identity, poolParentTransform));

            poolBulletObjects[i].SetActive(false);
            
       }  

   }

   public void ShootBullet(Vector3 startPos)
   {
       _shootBullet = poolBulletObjects[0];
       poolBulletObjects.Remove(_shootBullet);
       _shootBullet.SetActive(true);
       _shootBullet.transform.position = startPos;
       _shootBulletRB = _shootBullet.GetComponent<Rigidbody>(); 
 
       _shootBulletRB.AddForce(scr_PlayerChildController.Instance.transform.forward*100f,ForceMode.Force);
 
       poolBulletObjects.Add(_shootBullet);
   }
   
   

      
}
