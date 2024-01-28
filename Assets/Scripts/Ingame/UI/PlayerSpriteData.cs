using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSpriteData", menuName = "Player Sprite Data")]
public class PlayerSpriteData : ScriptableObject
{
    public List<Sprite> PlayerSprites;
    public List<Sprite> PlayerReadySprites;
    public List<Sprite> PlayerDeadSprites;
    public List<GameObject> PlayerCylinders;
    public GameObject HeartPrefab;
}
