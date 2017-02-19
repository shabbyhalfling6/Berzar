using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelGeneration : MonoBehaviour {

    private GameObject loadedLevel;
    public GameObject nextLevelSpawn;
    public GameObject[] levels;

    public float smoothFactor = 0.1f;
    private bool transitionLevels = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
       
        if(collider.gameObject.tag == "Player")
        {
            GameObject levelExit;
            levelExit = GameObject.FindGameObjectWithTag("LevelExit");
            Destroy(levelExit);

            this.gameObject.tag = "LevelExit";

            int nextlevel = Random.Range(0,levels.Length);

            
            loadedLevel = (GameObject)Instantiate(levels[nextlevel], new Vector3(nextLevelSpawn.transform.position.x, nextLevelSpawn.transform.position.y, 0), nextLevelSpawn.transform.rotation);
            transitionLevels = true;

            this.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    void Update()
    {
        if (transitionLevels)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, nextLevelSpawn.transform.position, Time.deltaTime * smoothFactor);
        }
    }
}
