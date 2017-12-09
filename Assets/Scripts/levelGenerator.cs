using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour {

    public Texture2D map;

    public colorToPrefab[] colorMappings;

    [SerializeField]
    private GameObject spikePrefab;

    [SerializeField]
    private GameObject invisSpikePrefab;

    [SerializeField]
    private GameObject spikePrefabSmall;

    [SerializeField]
    private GameObject invisSpikePrefabSmall;

    private void Start()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++){
            for (int y = 0; y < map.height;y++){
                GenerateTile(x, y);
            }
        }   
    }

    public void GenerateTile(int x,int y){
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0f){
            return;
        }

        foreach(colorToPrefab colorMapping in colorMappings){
            if(colorMapping.color.Equals(pixelColor)){
                if(colorMapping.prefab.Equals(spikePrefab) || colorMapping.prefab.Equals(invisSpikePrefab))
                {
                    Vector3 pos = new Vector3(x - 20, y - 8.78f,10);
                    Instantiate(colorMapping.prefab, pos, Quaternion.identity, transform);
                }else if (colorMapping.prefab.Equals(spikePrefabSmall) || colorMapping.prefab.Equals(invisSpikePrefabSmall))
                {
                    Vector3 pos = new Vector3(x - 20, y - 9.1f, 10);
                    Instantiate(colorMapping.prefab, pos, Quaternion.identity, transform);
                }
                else
                {
                    Vector2 pos = new Vector2(x - 20, y - 10);
                    Instantiate(colorMapping.prefab, pos, Quaternion.identity, transform);
                }
            }
        }


    }

}
