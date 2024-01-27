using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrder : MonoBehaviour
{
    [SerializeField] bool estatico = false;
    SpriteRenderer sp;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        if (estatico)
        {
            sp.sortingOrder = Mathf.RoundToInt(transform.position.y * -100);
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        sp.sortingOrder = Mathf.RoundToInt(transform.position.y * -100);
    }
}
