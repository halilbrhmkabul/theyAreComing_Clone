using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class scr_Finish : MonoBehaviour
{
    bool isTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (!isTrigger && other.CompareTag("Player"))
        {
            isTrigger = true;
            scr_PlayerChildController.Instance.isActive = false;
            scr_PlayerChildController.Instance.transform.DOLocalMoveX(0, .25f);

            StartCoroutine(waitForWin());
        }

    }

    IEnumerator waitForWin()
    {
        if (scr_UiManager.Instance.GameActive)
        {
            yield return new WaitForSeconds(6);
            scr_UiManager.Instance.WinGame();
        }
        else
        {
            scr_UiManager.Instance.LoseGame();
        }
    }
}
