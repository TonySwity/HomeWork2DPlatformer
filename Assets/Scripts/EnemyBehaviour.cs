using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private float _damage = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        KillPlayer(collision);
    }

    private void KillPlayer(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<HealthPlayer>(out HealthPlayer player))
        {
            player.TakeDamage(_damage);
        }
    }
}
