using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class S2BuildPieceSystem : MonoBehaviour
{
    [SerializeField] GameObject buildPrefab;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 50 * speed * Time.deltaTime, 0);
    }

    public GameObject GetBuildPrefab() {  return buildPrefab; }
}
