using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform _spawnPos = null;
    [SerializeField] private List<SpawnSet> spawns = new List<SpawnSet>();

    public bool _isSpawning = false;
    public Transform _spawnTransform;

    public int _stageNumber;

    private void Start()
    {
        Invoke("MonsterStart", 1);
    }
    void MonsterStart()
    {
        GameManager.Instance._stageManager.SetStage(GameManager.Instance._saveManager._userSave.USER_STAGE);
        SpawnInitialSet(GameManager.Instance._saveManager._userSave.USER_STAGE);
    }

    public void SpawnInitialSet(int stage)
    {
        // int index = GameManager.Instance._stageManager._stageInform[stage]._stageNumbers[0];

        _isSpawning = true;
    }

    private void Update()
    {
        if (_isSpawning)
        {
            Spawning();
        }
    }

    public int _index = 0;
    void Spawning()
    {
        if (spawns[_stageNumber]._spawns[_index]._spawnDelay > 0)
        {
            spawns[_stageNumber]._spawns[_index]._spawnDelay -= Time.deltaTime;
            return;
        }

        GameObject obj = Instantiate(spawns[_stageNumber]._spawns[_index]._monster, _spawnPos);
        obj.GetComponent<MonsterMove>()._stageInform = GameManager.Instance._stageManager._stageInform[0];
        _index += 1;

        if (_index == spawns[_stageNumber]._spawns.Count)
        {
            _index = 0;

            _stageNumber += 1;

            _isSpawning = false;

            GameManager.Instance._saveManager._userSave.USER_STAGE = _stageNumber;
            
            if (spawns.Count == _stageNumber)
            {
                return;
            }

            // GameManager.Instance._stageManager.SetStage(_stageNumber);
            Invoke("StartStage", 2f);
        }
    }
    void StartStage()
    {
        SpawnInitialSet(GameManager.Instance._saveManager._userSave.USER_STAGE);
    }

}

[System.Serializable]
public class SpawnSet
{
    [Header("스폰 설정")]

    [Tooltip("스폰 순서")]
    public List<SpawnInfo> _spawns = new List<SpawnInfo>();
}

[System.Serializable]
public class SpawnInfo
{
    [Tooltip("스폰 될 것의 이름")]
    public GameObject _monster;

    [Tooltip("스폰 되는 사이의 딜레이 시간")]
    public float _spawnDelay;
}
