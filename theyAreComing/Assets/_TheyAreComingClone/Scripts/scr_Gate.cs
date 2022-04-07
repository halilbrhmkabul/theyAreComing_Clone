using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class scr_Gate : MonoBehaviour
{
    bool isTriggered;

    [SerializeField] bool isAdd;
    [SerializeField] bool isMargin;

    [SerializeField] int number;

    [SerializeField] scr_Gate otherGate;
    private void Start()
    {
        if (isAdd)
        {
            GetComponentInChildren<TextMeshPro>().text = "+" + number;
        }

        else
        {
            GetComponentInChildren<TextMeshPro>().text = "x" + number;
        }

        
    }

    void OnTriggerEnter(Collider other)
   {
       if(other.CompareTag("Player")&& !isTriggered)
       {
            isTriggered = true;
            otherGate.enabled = false;
            otherGate.gameObject.transform.DOLocalMoveY(-1f, 2f);
            gameObject.transform.DOLocalMoveY(-1f, 2f);

            if (isAdd)
           {
                for (int i = 0; i < number; i++)
                {
                    scr_PoolPlayer.Instance.OpenClone();
                }
         
           }

           else
           {
                int no = scr_PoolPlayer.Instance.PoolPlayerClonesActives.Count + 1;
                no *= number;

                no-= scr_PoolPlayer.Instance.PoolPlayerClonesActives.Count + 1;
                for (int i = 0; i < no; i++)
                { 
                    scr_PoolPlayer.Instance.OpenClone();
                }
            }


        }
   }
}
