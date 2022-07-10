using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLine : MonoBehaviour
{
    [SerializeField] ParticleSystem confetti;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(GameStopCoroutine());
    }

    IEnumerator GameStopCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        PlayerMovement.Instance.gameState = false;
        PlayerMovement.Instance.canRun = false;
        confetti.Play();
        yield return new WaitForSeconds(1.0f);
        UIManager.Instance.SuccessPanel();

    }

}
