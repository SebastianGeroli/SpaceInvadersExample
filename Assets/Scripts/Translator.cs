using UnityEngine;

namespace Tests
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Translator : MonoBehaviour
    {
        Rigidbody2D rb;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        public void Move(Vector2 velocity)
        {
            rb.velocity = velocity;
        }
    }
}
