using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthManager : MonoBehaviour
{
    [SerializeField] private List<Tooth> teeth;
    private List<Tooth> teethToRemove = new List<Tooth>();

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Tooth tooth = transform.GetChild(i).GetComponent<Tooth>();
            if (tooth)
                teeth.Add(tooth);
        }
        //random amount
        foreach (var tooth in teeth)
        {
            if (Random.Range(0, 5) == 0)
            {
                //teeth.Remove(tooth);
                teethToRemove.Add(tooth);
                tooth.gameObject.SetActive(false);
            }
        }
        foreach (var tooth in teethToRemove)
        {
            teeth.Remove(tooth);
        }
        teethToRemove.Clear();

    }

    public void RemoveTooth(Tooth tooth)
    {
        if(teeth.Contains(tooth))
            teeth.Remove(tooth);
    }
}
