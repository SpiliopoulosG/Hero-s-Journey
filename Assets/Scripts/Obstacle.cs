using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;
    public GameObject effect;

    private void Update() {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -15f) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Instantiate(effect, transform.position, Quaternion.identity);
        other.GetComponent<Player>().health -= damage;
        Debug.Log("Player Hit");
        Destroy(gameObject);
    }
}
