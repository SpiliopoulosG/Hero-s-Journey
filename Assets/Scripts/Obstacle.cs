using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;
    public float acceleration = 0.05f;
    public GameObject effect;

    private void Update() {
        float maxIncreasedSpeed = 2 * speed;
        float currentSpeed = (maxIncreasedSpeed < speed + acceleration * Time.deltaTime) ? speed + acceleration * Time.deltaTime : maxIncreasedSpeed;
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        if (transform.position.x < -15f) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        startEffect();
        other.GetComponent<Player>().health -= damage;
        Destroy(gameObject);
    }

    void startEffect() {
        GameObject thunderParticle = Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(thunderParticle, 3f);
    }
}
