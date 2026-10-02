using UnityEngine;

public class pillarspawner : MonoBehaviour
{
    public GameObject pipe;
    public float pipedistance = 10f;
    private float timer = 0;
    public float heightoffset = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnpipe();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float spawnrate = pipedistance / movepillar.movespeed;

        if (timer >= spawnrate)
        {
            spawnpipe();
            timer -= spawnrate;
        }
    }
    void spawnpipe()
    {
        float lowestpoint = transform.position.y - heightoffset;
        float highestpoint = transform.position.y + heightoffset;

        Instantiate(pipe, new Vector3(transform.position.x,Random.Range(lowestpoint, highestpoint), 0), transform.rotation);
    }
}
