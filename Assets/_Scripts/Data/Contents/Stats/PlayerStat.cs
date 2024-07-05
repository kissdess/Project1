using System.Collections;
using System.Collections.Generic;
using MyProject.Items;
using UnityEngine;

public class PlayerStat : Stat
{
    [SerializeField]
    protected int _exp;
    [SerializeField]
    protected int _gold;

    private Coroutine buffCoroutine;

    #region Exp
    public int Exp
    {
        get
        {
            return _exp;
        }
        set
        {
            _exp = value;

            int level = Level;
            while (true)
            {
                Data.Stat stat;
                if (Managers.Data.StatDict.TryGetValue(level + 1, out stat) == false)
                    break;
                if (_exp < stat.totalExp)
                    break;
                level++;
            }

            if (level != Level)
            {
                Debug.Log("Level Up");
                Level = level;
                SetStat(Level);
            }
        }
    }
    #endregion    

    public int Gold { get { return _gold; } set { _gold = value; } }

    private void SetStat(int level)
    {
        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;
        Data.Stat stat = dict[level];
        _hp = stat.maxHp;
        _maxHp = stat.maxHp;
        _attack = stat.attack + 50;
    }

    protected override void OnDead(Stat attacker)
    {
        Debug.Log("Player is dead");
    }

    public void ApplyBuff(Buff buff)
    {
        switch (buff.buffType)
        {
            case BuffType.HitPoint:
                _hp += buff.buffValue;
                Debug.Log($"{buff.buffName} applied. HP increased by {buff.buffValue}");
                break;
            case BuffType.Attack:
                _attack += buff.buffValue;
                Debug.Log($"{buff.buffName} applied. Attack increased by {buff.buffValue}");
                break;
            case BuffType.Defense:
                _defense += buff.buffValue;
                Debug.Log($"{buff.buffName} applied. Defense increased by {buff.buffValue}");
                break;
            case BuffType.MoveSpeed:
                _moveSpeed += buff.buffValue;
                Debug.Log($"{buff.buffName} applied. MoveSpeed increased by {buff.buffValue}");
                break;
        }

        if (buffCoroutine != null)
            StopCoroutine(buffCoroutine);

        buffCoroutine = StartCoroutine(RemoveBuffAfterDelay(buff, buff.duration)
        );
    }

    public void AddStats(int attackBonus, int defenseBonus)
    {
        _attack += attackBonus;
        _defense += defenseBonus;
    }

    public void RemoveStats(int attackBonus, int defenseBonus)
    {
        _attack -= attackBonus;
        _defense -= defenseBonus;
    }


    private IEnumerator RemoveBuffAfterDelay(Buff buff, float delay)
    {
        yield return new WaitForSeconds(delay);

        switch (buff.buffType)
        {
            case BuffType.HitPoint:
                _hp -= buff.buffValue;
                break;
            case BuffType.Attack:
                _attack -= buff.buffValue;
                break;
            case BuffType.Defense:
                _defense -= buff.buffValue;
                break;
            case BuffType.MoveSpeed:
                _moveSpeed -= buff.buffValue;
                break;
        }

        Debug.Log("Player's buff has worn off");
    }
}

