using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowEffects : MonoBehaviour
{
    public ParticleSystem snowEffects;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            snowEffects.Play();
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            snowEffects.Stop();
        }
    }
}
