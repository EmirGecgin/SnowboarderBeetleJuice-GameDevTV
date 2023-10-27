using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float delayTime = 0.75f;
    [SerializeField] private ParticleSystem finishLineEffect;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            finishLineEffect.Play();
            Debug.Log("Finish Line");
            Invoke("ReloadScene",delayTime);
        }
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
