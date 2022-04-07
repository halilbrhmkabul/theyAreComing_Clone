using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using UnityEngine.InputSystem.EnhancedTouch;
using DG.Tweening;
using TMPro;
 


public class scr_PlayerController : MonoBehaviour
{
   public static scr_PlayerController Instance;
   [SerializeField] Animator anim;
   [SerializeField] SplineFollower playerSplineFollower;
   [SerializeField] int playerSpeed;

    public Transform TargetNavMesh;

   void Awake()
   { 
        if(Instance==null)
            Instance=this;
        else
            Destroy(Instance);
   }
    public void PlayAnimation(string animationName)
    {
        anim.Play(animationName);
        
    }

    public void GameStart()
    {
        playerSplineFollower.followSpeed = playerSpeed;
        PlayAnimation("BackWalk");
        StartCoroutine(Shoot());
        Debug.Log("Oyun Başladı");
    }

    public void GameEnd()
    {
        playerSplineFollower.followSpeed = 0;
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1f);
        if(scr_UiManager.Instance.GameActive)
        {
            scr_PoolBullet.Instance.ShootBullet(scr_PlayerChildController.Instance.transform.position + new Vector3(0.051f, 0.192f, -0.1f));
            StartCoroutine(Shoot());
        }
    }


}
