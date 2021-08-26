using UnityEngine;


public class FinishGame : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform[] _vfxSpawnPoints;
    [SerializeField] private float _spawnDelay = 1f;
    [SerializeField] private Wallet _wallet;

    private float _timeAfterSpawn;
    private int _numberSpawnPoint = 0;

    private void Start()
    {
        _timeAfterSpawn = _spawnDelay;
    }

    private void Update()
    {
        if (_wallet.IsFinished)
        {
            SpawnFirework();
        }
             
    }

    private void SpawnFirework()
    {
        if (_timeAfterSpawn <= 0)
        {
            if (_numberSpawnPoint >= _vfxSpawnPoints.Length)
            {
                _numberSpawnPoint = 0;
            }

            Instantiate(_template, _vfxSpawnPoints[_numberSpawnPoint].transform.position, Quaternion.identity);
            _numberSpawnPoint++;
            _timeAfterSpawn = _spawnDelay;

        }
        else
        {
            _timeAfterSpawn -= Time.deltaTime;
        }
    }
}
