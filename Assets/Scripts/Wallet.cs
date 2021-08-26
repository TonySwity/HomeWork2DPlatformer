using UnityEngine;

public class Wallet : MonoBehaviour
{

    [SerializeField] private CoinsSpawner _coinsSpawner;

    public bool IsFinished { get; private set; }
    public int CoinsCount { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            CoinsCount++;
            Debug.Log(CoinsCount);
            Debug.Log(_coinsSpawner.CoinsCount);
            coin.gameObject.SetActive(false);

            if (CoinsCount >= _coinsSpawner.CoinsCount)
            {
                IsFinished = true;
            }
        }
    }
}
