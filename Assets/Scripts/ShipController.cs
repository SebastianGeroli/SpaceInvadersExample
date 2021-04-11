using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    private Vector2 movement;
    [SerializeField]
    private float maxSpeed = 7f;
    [SerializeField]
    private float minSpawnX = -8f, maxSpawnX = 8f;
    public float speed = 1f;
    private Vector2 newVelocity;
    [SerializeField]
    private Transform[] enemies;
    private float dangerDistance = 3f;

    // Se llama a Start antes de la primera actualización del cuadro

    void Start()
    {
        RandomSpawn();
        rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(DoCheck());
    }

    // Update se llama una vez por frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        movement = new Vector2(moveHorizontal, 0f);
    }

    // FixedUpdate se llama en cada fixed frame-rate frame. (50 llamadas por segundo, por defecto)
    void FixedUpdate()
    {
        // Aplica la fuerza al Rigidbody2d
        if (Mathf.Abs(rigidbody.velocity.x) >= maxSpeed)
        {
            newVelocity = rigidbody.velocity;
            newVelocity.x = newVelocity.x > 0 ? 5f : -5f;
            rigidbody.velocity = newVelocity;
            return;
        }
        rigidbody.AddForce(movement * speed * 5f);
    }

    void RandomSpawn()
    {
        Vector2 spawnPos = transform.position;
        spawnPos.x = Random.Range(minSpawnX, maxSpawnX);
        transform.position = spawnPos;
    }

    bool ProximityCheck()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (Vector3.Distance(transform.position, enemies[i].transform.position) < dangerDistance)
            {
                return true;
            }
        }

        return false;
    }
    IEnumerator DoCheck()
    {
        for (; ; )
        {
            ProximityCheck();
            yield return new WaitForSeconds(.1f);
        }
    }
}
