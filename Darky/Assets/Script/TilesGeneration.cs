using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGeneration : MonoBehaviour {

    public GameObject []tiles;

    public GameObject followingCamera;

    public GameObject BackGroundObject;

    private float nextPositionBackGround;

    private float nextPositionTile;
    private float gap;

    private GameObject lastGenerated;

    GameObject nextObject(GameObject lastObject)
    {
        if (!lastObject)
            return tiles[Random.Range(0, tiles.Length)];

        var nextTiles = lastObject.GetComponent<NextTiles>().nextTiles;

        return nextTiles[Random.Range(0, nextTiles.Length)];
    }

	// Use this for initialization
	void Start () {
        Random.seed = System.DateTime.Now.Millisecond;
        nextPositionBackGround = (float)BackGroundObject.GetComponent<SpriteRenderer>().bounds.size.x;
        nextPositionTile = -10;
        gap = 0;

        lastGenerated = null;
        GameObject toGenerate = null;

        for (var i = 0; i < 50; i++)
        {
            toGenerate = nextObject(lastGenerated);

            Instantiate(toGenerate, new Vector3(nextPositionTile - toGenerate.transform.position.z, toGenerate.transform.position.y,
                                               toGenerate.transform.position.z), Quaternion.identity);
            nextPositionTile += (float)toGenerate.GetComponent<SpriteRenderer>().bounds.size.x + gap;



            lastGenerated = toGenerate;
        }
    }
	
	// Update is called once per frame
	void Update () {
        var camera = followingCamera.GetComponent<Camera>();
        Vector3 p = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));

        if (p.x > nextPositionBackGround - (float)BackGroundObject.GetComponent<SpriteRenderer>().bounds.size.x) {
            Instantiate(BackGroundObject, new Vector3(nextPositionBackGround, BackGroundObject.transform.position.y,
                                                      BackGroundObject.transform.position.z), Quaternion.identity);
            nextPositionBackGround += (float)BackGroundObject.GetComponent<SpriteRenderer>().bounds.size.x;
        }

        GameObject toGenerate = nextObject(lastGenerated);

        if (p.x > nextPositionTile - (toGenerate.GetComponent<SpriteRenderer>().bounds.size.x + gap)) {

            Instantiate(toGenerate, new Vector3(nextPositionTile - toGenerate.transform.position.z, toGenerate.transform.position.y,
                                               toGenerate.transform.position.z), Quaternion.identity);
            nextPositionTile += (float)toGenerate.GetComponent<SpriteRenderer>().bounds.size.x + gap;

            lastGenerated = toGenerate;
        }

    }
}
