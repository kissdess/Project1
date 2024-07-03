using MyProject.Items;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] protected GameObject[] _commonDropRate;
    [SerializeField] protected GameObject[] _uncommonDropRate;
    [SerializeField] protected GameObject[] _rareDropRate;
    [SerializeField] protected GameObject[] _epicDropRate;
    [SerializeField] protected GameObject[] _legendaryDropRate;
    [SerializeField] protected GameObject _gold;

    public int GoldAmount { get; private set; }

    public bool IsDropped => _isDropped;
    private bool _isDropped = false;

    public void DropTable()
    {
        // 0에서 100 사이의 무작위 값 생성
        float random = Random.Range(0, 100);

        Vector2 randomPosition = Random.insideUnitCircle * 2f; // 반경 2 단위 내에서 무작위 위치 선택
        Vector3 dropPosition = new Vector3(transform.position.x + randomPosition.x, transform.position.y + 0.2f, transform.position.z + randomPosition.y);

        // 일반 아이템 드랍 (50% 확률)
        if (random <= 50)
        {
            int randomIndex = Random.Range(0, _commonDropRate.Length);
            Instantiate(_commonDropRate[randomIndex], dropPosition, Quaternion.identity);
            Debug.Log("일반 아이템 드랍!");
        }
        // 비일반 아이템 드랍 (30% 확률)
        else if (random <= 80)
        {
            int randomIndex = Random.Range(0, _uncommonDropRate.Length);
            Instantiate(_uncommonDropRate[randomIndex], dropPosition, Quaternion.identity);
            Debug.Log("비일반 아이템 드랍!");
        }
        // 희귀 아이템 드랍 (15% 확률)
        else if (random <= 95)
        {
            int randomIndex = Random.Range(0, _rareDropRate.Length);
            Instantiate(_rareDropRate[randomIndex], dropPosition, Quaternion.identity);
            Debug.Log("희귀 아이템 드랍!");
        }
        // 에픽 아이템 드랍 (4% 확률)
        else if (random <= 99)
        {
            int randomIndex = Random.Range(0, _epicDropRate.Length);
            Instantiate(_epicDropRate[randomIndex], dropPosition, Quaternion.identity);
            Debug.Log("에픽 아이템 드랍!");
        }
        // 전설 아이템 드랍 (1% 확률)
        else
        {
            int randomIndex = Random.Range(0, _legendaryDropRate.Length);
            Instantiate(_legendaryDropRate[randomIndex], dropPosition, Quaternion.identity);
            Debug.Log("전설 아이템 드랍!");
        }
        DropGold();
        _isDropped = true;
    }

    private void DropGold()
    {
        var _stat = gameObject.GetComponent<Stat>();
        int coinAmountRange = Random.Range(50, 100);
        GoldAmount = _stat.Level * coinAmountRange;            // 레벨에 따른 골드량 보정

        Vector2 randomPosition = Random.insideUnitCircle * 2f;
        Vector3 dropPosition = new Vector3(transform.position.x + randomPosition.x, transform.position.y + 0.2f, transform.position.z + randomPosition.y);
        GameObject goldInstance = Instantiate(_gold, dropPosition, Quaternion.identity);
        Gold goldComponent = goldInstance.GetComponent<Gold>();
        if (goldComponent != null)
        {
            goldComponent.SetDropItem(this);
        }

        Debug.Log(GoldAmount);
    }


}