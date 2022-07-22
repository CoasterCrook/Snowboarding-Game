using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{ 
    [SerializeField] float crashDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool crashOnce = false;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if ((other.tag == "Ground" || other.tag == "Rock") && !crashOnce)
        {
            crashOnce = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", crashDelay);
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Rock")
        {
            crashEffect.Play();
            Invoke("ReloadScene", crashDelay);
        } 
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
