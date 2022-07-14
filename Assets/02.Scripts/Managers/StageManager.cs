using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StageInform
{
    public int _stageNumber;

    public List<int> _stageNumbers;
}

public class StageManager : MonoBehaviour
{
    public List<StageInform> _stageInform;
    public Transform _monsters;
    public GameObject monster;

    List<MapInform> _mapList;

    public void SetStage(int stageNumber)
    {
        foreach (MapInform map in _mapList)
        {
            map._isWay = false;
        }

        StageInform stage = _stageInform[0];
        
        UIManager.Instance.StageUpdate();

        // 스테이지 설정 
        for (int i = 0; i < _stageInform[0]._stageNumbers.Count; i++)
        {
            GameManager.Instance._mapList[stage._stageNumbers[i]]._isWay = true;
        }

        GameManager.Instance._mapList = _mapList;
    }

    private void Start()
    {
        _mapList = GameManager.Instance._mapList;
    }
    
}
