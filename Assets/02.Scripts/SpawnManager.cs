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
        _stageNumber = 0;
        GameManager.Instance._stageManager.SetStage(_stageNumber);
        SpawnInitialSet(_stageNumber);
    }

    public void SpawnInitialSet(int stage)
    {
        int index = GameManager.Instance._stageManager._stageInform[stage]._stageNumbers[0];

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
        obj.GetComponent<MonsterMove>()._stageInform = GameManager.Instance._stageManager._stageInform[_stageNumber];
        _index += 1;

        if (_index == spawns[_stageNumber]._spawns.Count)
        {
            _isSpawning = false;

            _index = 0;

            _stageNumber += 1;

            if (GameManager.Instance._stageManager._stageInform.Count == _stageNumber) return;
            GameManager.Instance._stageManager.SetStage(_stageNumber);
        }
    }

}

[System.Serializable]
public class SpawnSet
{
    [Header("���� ����")]

    [Tooltip("���� ����")]
    public List<SpawnInfo> _spawns = new List<SpawnInfo>();
}

[System.Serializable]
public class SpawnInfo
{
    [Tooltip("���� �� ���� �̸�")]
    public GameObject _monster;

    [Tooltip("���� �Ǵ� ������ ������ �ð�")]
    public float _spawnDelay;
}
