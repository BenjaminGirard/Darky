using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGeneration : MonoBehaviour {

    public GameObject []tiles;

    private float nextPosition;
    private float gap;

    GameObject nextObject(GameObject lastObject)
    {
        if (!lastObject)
            return tiles[Random.Range(0, tiles.Length)];

        var nextTiles = lastObject.GetComponent<NextTiles>().nextTiles;

        return nextTiles[Random.Range(0, nextTiles.Length)];
    }

	// Use this for initialization
	void Start () {

        nextPosition = -10;
        gap = 0;

        GameObject lastGenerated = null;
        GameObject toGenerate = null;

        for (var i = 0; i < 50; i++)
        {
            toGenerate = nextObject(lastGenerated);

            Instantiate(toGenerate, new Vector3(nextPosition - toGenerate.transform.position.z, toGenerate.transform.position.y,
                                               toGenerate.transform.position.z), Quaternion.identity);
            print((float)(toGenerate.GetComponent<SpriteRenderer>().bounds.size.x));
            nextPosition += (float)toGenerate.GetComponent<SpriteRenderer>().bounds.size.x + gap;

            lastGenerated = toGenerate;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
