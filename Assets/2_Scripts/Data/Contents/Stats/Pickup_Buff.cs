using MyProject.Events.CustomEvents;
using UnityEngine;
using UnityEngine.Events;

public class Pickup_Buff : MonoBehaviour
{
    //[SerializeField] private UnityEvent OnBuffAdjust = null;
    [SerializeField] private Buff buff;

    public void OnTriggerEnter(Collider other)
    {
        PlayerStat playerStat = other.GetComponent<PlayerStat>();
        if (playerStat != null)
        {
            playerStat.ApplyBuff(buff);
            Debug.Log("Buff Applied");
            Destroy(gameObject);
        }

    }



}