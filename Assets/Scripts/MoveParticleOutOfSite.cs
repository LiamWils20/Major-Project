using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveParticleOutOfSite : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = new Vector3(0, -1, 0);
        transform.Translate(v * speed * Time.deltaTime);
    }
}
