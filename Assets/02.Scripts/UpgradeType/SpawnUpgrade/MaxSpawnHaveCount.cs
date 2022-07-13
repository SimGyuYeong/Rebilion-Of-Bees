using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxSpawnHaveCount : UpgradeType
{
    public override void Upgrade()
    {
        GameManager.Instance._saveManager._userSave.USER_MAXEGG++;
        GameManager.Instance._saveManager._userSave.USER_MAXHONEY++;
    }
}
