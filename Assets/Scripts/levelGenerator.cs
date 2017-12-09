using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour {

    public Texture2D map;

    public colorToPrefab[] colorMappings;

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
                Vector2 pos = new Vector2(x, y);
                Instantiate(colorMapping.prefab, pos, Quaternion.identity, transform);
            }
        }


    }

}
