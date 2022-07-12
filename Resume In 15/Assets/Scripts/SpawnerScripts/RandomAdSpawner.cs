using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RandomAdSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject parent;
    public Vector2 adSize = new Vector2(300, 300);
    public float spawnTime = 3.0f;
    private float timeUntilSpawn;
    private List<Object> adsList;

    // Start is called before the first frame update
    void Start()
    {
        // Read in all ad videos
        adsList = new List<Object>(Resources.LoadAll("AdVideos"));
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: add an animation curve to adjust rates over time
        // call spawner every X interval of time
        if(timeUntilSpawn > 0){
            timeUntilSpawn -= Time.deltaTime;
        }
        else{
            SpawnObject();
            timeUntilSpawn = spawnTime;
        }
    }

    // Instantiate an advertisement in the UI canvas
    void SpawnObject(){
        // Instantiate new advertisement object
        GameObject adObj = (GameObject)Instantiate(objectToSpawn, Vector3.zero, Quaternion.identity);
        adObj.transform.SetParent(parent.transform, false);

        // Get a random spawn point in the canvas
        Vector2 spawnPoint = getRandomSpawnPoint();

        // Adjust position of ad obj
        adObj.GetComponent<RectTransform>().anchoredPosition = spawnPoint;

        // Adjust size of ad obj
        adObj.GetComponent<RectTransform>().sizeDelta = adSize;

        // Create new render texture
        //var rendTexture = new RenderTexture(Screen.width, Screen.height, 24);
        var rendTexture = new RenderTexture((int)adSize.x, (int)adSize.y, 24);

        // Add texture to ad obj raw image
        adObj.GetComponent<RawImage>().texture = rendTexture;

        // Add texture to ad obj video player
        adObj.GetComponent<VideoPlayer>().targetTexture = rendTexture;

        // Select random video from list
        int index = Random.Range(0, adsList.Count);

        // add video clip to video player
        adObj.GetComponent<VideoPlayer>().clip = (VideoClip)adsList[index];
    }

    // Generate a random spawn location within the UI
    Vector2 getRandomSpawnPoint(){
        Vector2 spawnRange = parent.GetComponent<RectTransform>().sizeDelta - adSize;

        Vector2 spawnPoint =  new Vector2();
        spawnPoint.x = Random.Range(-0.5f * spawnRange.x, 0.5f * spawnRange.x);
        spawnPoint.y = Random.Range(-0.5f * spawnRange.y, 0.5f * spawnRange.y);

        return spawnPoint;
    }
}
