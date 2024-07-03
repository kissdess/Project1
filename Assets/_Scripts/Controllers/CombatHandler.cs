using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatHandler : MonoBehaviour
{
    private PlayerController _playerController;
    private PlayerStat _playerStat;
    private List<Slashes> _slashes;

    public bool IsAttacking { get; private set; }

    public void Initialize(PlayerController playerController, PlayerStat playerStat, List<Slashes> slashes)
    {
        _playerController = playerController;
        _playerStat = playerStat;
        _slashes = slashes;
    }

    public IEnumerator PerformAttack()
    {
        IsAttacking = true;
        for (int i = 0; i < _slashes.Count; i++)
        {
            yield return new WaitForSeconds(_slashes[i].delay);
            _slashes[i].slashObj.SetActive(true);
            Debug.Log("Slash " + i);
        }
        yield return new WaitForSeconds(0.2f);
        DisableSlash();
    }

    public bool AttackTarget(GameObject target)
    {
        Stat targetStat = target.GetComponent<Stat>();
        targetStat.OnAttacked(_playerStat);
        return targetStat.Hp <= 0;
    }

    private void DisableSlash()
    {
        foreach (var slash in _slashes)
        {
            slash.slashObj.SetActive(false);
        }
        IsAttacking = false;
    }
}

[System.Serializable]
public class Slashes
{
    public GameObject slashObj;
    public float delay;
}