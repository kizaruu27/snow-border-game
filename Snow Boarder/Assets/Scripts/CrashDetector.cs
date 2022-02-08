using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float delayTime = 2f;
    [SerializeField] AudioClip crashSFX;
    bool isCrashed = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground" && !isCrashed) {
            isCrashed = true;
            FindObjectOfType<PlayerController>().DisableControl();
            FindObjectOfType<PlayerController>().stopMove();
            Invoke("ReloadScene", delayTime); 
            crashEffect.Play();  
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
