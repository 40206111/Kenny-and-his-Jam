using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHighlighter : MonoBehaviour
{
    public Transform HighlighterPrefab;
    private Transform Highlighter;
    private void Awake()
    {
        Highlighter = Instantiate(HighlighterPrefab);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LocateTile();
    }

    private void LocateTile()
    {
        Vector3 forward = transform.rotation * Vector3.forward;
        Vector3Int tPos = Vector3Int.RoundToInt(transform.position + forward);
        Highlighter.position = tPos;
    }
}
