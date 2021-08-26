using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        KillPlayer(collision);
    }

    private void KillPlayer(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.gameObject.SetActive(false);
        }
    }
}
