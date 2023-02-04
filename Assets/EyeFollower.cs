using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollower : MonoBehaviour
{
    [SerializeField] float maxDistance = 1;
    [SerializeField] Transform followRef;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.ClampMagnitude(followRef.position - startPos, maxDistance);
    }
}
