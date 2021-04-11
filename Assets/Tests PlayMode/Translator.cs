using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Translator : MonoBehaviour
{
    public bool useDrag = true;
    public float drag = 1.2f;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        ApplyDrag();
    }
    public void Move(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    private void ApplyDrag()
    {
        if (useDrag == false) return;
        rb.velocity /= drag;
    }
}