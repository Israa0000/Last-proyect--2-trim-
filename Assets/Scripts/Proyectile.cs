using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}