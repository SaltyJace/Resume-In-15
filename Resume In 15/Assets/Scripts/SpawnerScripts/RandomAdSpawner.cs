using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAdSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 centerPoint; // TODO: may want to change to use a parent object's position instead
    public float radius;
    public float spawnTime; // how frequently objects spawn
    private float currentTimeToSpawn; // time until next spawn

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // call spawner every X interval of time
        if(currentTimeToSpawn > 0){
            currentTimeToSpawn -= Time.deltaTime;
        }
        else{
            SpawnObject();
            currentTimeToSpawn = spawnTime;
        }
    }

    // spawn the object
    public void SpawnObject(){
        // get random point in sphere
        Vector3 pointOnShpere = GetPointOnSphere(centerPoint, radius);
        // instantiate new ad object at point
        //TODO: change rotation to look at center of sphere
        Instantiate(objectToSpawn, pointOnShpere, Quaternion.identity);
    }

    // TODO: fix method to correctly find sphere center
    // calculate phi from vector3
    /*private float GetPitchFromCartesian(Vector3 pointOnSphere){
        float xSqr = Mathf.Pow(pointOnSphere.x, 2);
        float ySqr = Mathf.Pow(pointOnSphere.y, 2);
        float zSqr = Mathf.Pow(pointOnSphere.z, 2);
        float phi = Mathf.Acos(pointOnSphere.y / Mathf.Sqrt(xSqr + ySqr + zSqr));
        //print("phi is: " + phi);
        return phi * Mathf.Rad2Deg;
    }*/

    // generate random sphere point
    private Vector3 GetPointOnSphere(Vector3 sphereCenter, float radius){
        // generate two rand numbers between 0 and 1
        float u = Random.Range(0.0f, 1.0f);
        float v = Random.Range(0.0f, 1.0f);

        // use rand numbers to get spherical coordinates theta and phi
        float theta = 2 * Mathf.PI * u;
        float phi = Mathf.Acos(2 * v - 1);

        float temp = phi * Mathf.Rad2Deg;

        // convert from spherical coordinates to cartesian coordinates
        // y and z conversions are swapped to account for unity's coordinate system
        float x = sphereCenter.x + radius * Mathf.Sin(phi) * Mathf.Cos(theta);
        float y = sphereCenter.y + radius * Mathf.Cos(phi);
        float z = sphereCenter.z + radius * Mathf.Sin(phi) * Mathf.Sin(theta);

        return new Vector3(x, y, z);
    }

}
