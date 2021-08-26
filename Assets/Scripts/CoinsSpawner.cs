using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinTemplate;
    [SerializeField] private Transform[] _spawnPoints;

    public int CoinsCount { get { return _spawnPoints.Length; } }

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_coinTemplate, _spawnPoints[i].transform.position, Quaternion.identity);
        }
    }
}
