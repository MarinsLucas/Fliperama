using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SWWaveData", menuName = "New Wave Data")]
public class SWWaveData : ScriptableObject
{
    public EnemyLine[] enemyLines;
    public int quantKamikase;
    public int quantMeteor;
    public int quantNormal;
    public int quantLines; 
}
