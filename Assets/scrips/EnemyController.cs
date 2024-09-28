using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
