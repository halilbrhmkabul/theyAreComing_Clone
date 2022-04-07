using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Bullet : MonoBehaviour
{


    private void OnEnable()
    {
        StartCoroutine(waitForClose());
    }

    IEnumerator waitForClose()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
