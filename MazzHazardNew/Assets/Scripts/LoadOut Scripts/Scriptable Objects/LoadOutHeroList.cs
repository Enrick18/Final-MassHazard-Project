using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerIndex", menuName = "Player Index")]
public class LoadOutHeroList : ScriptableObject
{
    public List<int> heroChoosenIndex;
}
