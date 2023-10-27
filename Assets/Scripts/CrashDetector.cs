using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float delayTime = 0.5f;
    
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSound;
    private bool _playCrashSound=false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ground")&&!_playCrashSound)
        {
            FindObjectOfType<SnowEffects>().snowEffects.gameObject.SetActive(false);
            FindObjectOfType<PlayerController>().DisableController();
            GetComponent<AudioSource>().PlayOneShot(crashSound);
            crashEffect.Play();
            _playCrashSound = true; 
            Debug.Log("Ouch,my head is gone");
            Invoke("ReloadScene",delayTime);
        }
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
