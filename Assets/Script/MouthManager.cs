using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthManager : MonoBehaviour
{
    [SerializeField] public GameObject toothParticles;
    [SerializeField] private List<Tooth> teeth;
    private List<Tooth> teethToRemove = new List<Tooth>();

    public Animator patientAnim;

    public void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            Tooth tooth = transform.GetChild(i).GetComponent<Tooth>();
            if (tooth)
            {
                tooth.transform.rotation = Quaternion.identity;
                teeth.Add(tooth);
            }
        }
        //random amount
        foreach (var tooth in teeth)
        {
            if (Random.Range(0, 3) == 0)
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

        if(teeth.Count <= 0)
        {
            GameManager.instance.NextPatient();
            GameManager.instance.score += 10;
        }
    }
}
