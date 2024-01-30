using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float ChangeLaneForce = 10f;
    public float volume = 1.0f;
    public AudioSource audioSource;
    public GameObject effect;
    public AudioClip clip;

    Vector2 startTouchPosition;
    Vector2 endTouchPosition;

    public int health = 3;

    void Update()
    {

        if ( health <= 0 ) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if ( Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if ( Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            endTouchPosition = Input.GetTouch(0).position;

            if (endTouchPosition.y < startTouchPosition.y) {
                Instantiate(effect, transform.position, Quaternion.identity);
                if (!(transform.position.y - ChangeLaneForce < -2f)) {
                    transform.position = new Vector3(transform.position.x, transform.position.y - ChangeLaneForce, transform.position.z);
                }
            }

            if (endTouchPosition.y > startTouchPosition.y) {
                Instantiate(effect, transform.position, Quaternion.identity);
                if (!(transform.position.y + ChangeLaneForce > 4f)) {
                    transform.position = new Vector3(transform.position.x, transform.position.y + ChangeLaneForce, transform.position.z);
                }
            }

            PlayChangeLaneSound();
        }
    }

    void PlayChangeLaneSound()
    {
        if (audioSource)
        {
            audioSource.PlayOneShot(clip, volume);
        }
    }
}
