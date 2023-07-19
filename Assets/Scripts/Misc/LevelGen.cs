using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    public Transform startPoint;

    [HideInInspector]
    public int startingPieces = 10;
    
    public List<GameObject> levelPiecePrefabs;
    public int blankPieces = 0;
    public int maxBlankPieces = 2;
    
    List<GameObject> currentLevelPieces = new List<GameObject>();
    Transform nextSpawnPosition;

    void SpawnLevelPiece()
    {
        Transform prevLevelEnd = currentLevelPieces[currentLevelPieces.Count - 1].transform.GetChild(0).transform;
        GameObject newPiece = Instantiate(levelPiecePrefabs[Random.Range(0, levelPiecePrefabs.Count)], prevLevelEnd.position, prevLevelEnd.rotation);
        currentLevelPieces.Add(newPiece);
        if (newPiece.CompareTag("blankTerrain") && blankPieces == maxBlankPieces)
        {
            Destroy(newPiece);
            SpawnLevelPiece();
        }
        //else if (!newPiece.CompareTag("blankTerrain"))
        //{
        //    blankPieces = 0;
        //}

        // Remove oldest piece from list if count is greater than 10
        if (currentLevelPieces.Count > 10)
        {
            GameObject oldestPiece = currentLevelPieces[0];
            currentLevelPieces.RemoveAt(0);
            Destroy(oldestPiece);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject firstPiecePivot = Instantiate(levelPiecePrefabs[Random.Range(0, levelPiecePrefabs.Count)], startPoint.position, startPoint.rotation);

        currentLevelPieces.Add(firstPiecePivot);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevelPieces.Count < 10)
        {
            SpawnLevelPiece();
        }
        else
        {
            bool foundDestroyedPiece = false;
            foreach (GameObject piece in currentLevelPieces)
            {
                if (piece == null)
                {
                    foundDestroyedPiece = true;
                    break;
                }
            }
            if (foundDestroyedPiece)
            {
                SpawnLevelPiece();
            }
        }
    }
}
