using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TerrainChunk[] chunks;
    public List<TerrainChunk> possibleChunks;
    public static float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn 2 chunks
        possibleChunks = new List<TerrainChunk>();
        Generate(new Vector3(0, -3, 0));
        Generate();
    }

    public void Generate()
    {
        TerrainChunk newChunk = Instantiate(chunks[Random.Range(0, chunks.Length)], new Vector3(14, -3, 0), Quaternion.identity);
        possibleChunks.Add(newChunk);
        newChunk.gc = this;
    }

    public void Generate(Vector3 position)
    {
        TerrainChunk newChunk = Instantiate(chunks[Random.Range(0, chunks.Length)], position, Quaternion.identity);
        possibleChunks.Add(newChunk);
        newChunk.gc = this;
    }
}
