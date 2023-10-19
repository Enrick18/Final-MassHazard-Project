using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Database", menuName = "Hero Database")]
public class HeroDatabase : ScriptableObject
{
    public List<HeroList> heroLists;
}

[System.Serializable]
public class HeroList
{
    public int heroIndex;
    public Sprite heroCard;
    public GameObject buttonPrefab;
    public GameObject characterCard;
}
