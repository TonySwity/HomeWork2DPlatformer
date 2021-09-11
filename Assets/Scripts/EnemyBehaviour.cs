using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private float _damage = -10f;

    private void OnCollisionStay2D(Collision2D collision)
    {
        KillPlayer(collision);
    }

    private void KillPlayer(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            player.TakeDamage(_damage);
        }
    }
}
