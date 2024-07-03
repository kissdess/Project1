using UnityEngine;

public enum BuffType
{
    None,
    Attack,
    Defense,
    HitPoint,
    MoveSpeed,
    AttackSpeed,
    ManaPoint
}


[CreateAssetMenu(fileName = "New Buff", menuName = "Buff System/Buff")]
public class Buff : ScriptableObject
{
    public BuffType buffType;
    public string buffName;
    public float duration;
    public int buffValue;

}
