using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TileGenerate : MonoBehaviour
{
    [SerializeField] GameObject Tile, player;
    [SerializeField] int height, width;
    public Camera cam;
    
    private void Awake()
    {

        Instantiate(player);
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                var spawnedTile = Instantiate(Tile, new Vector3(i, j, 0), Tile.transform.rotation);
                spawnedTile.name = i + "," + j;
                

            }
        }

        
    }

    // Update is called once per frame

    
}
