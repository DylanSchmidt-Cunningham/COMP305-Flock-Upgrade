using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour {

    public GameObject boidPrefab;
    public int numBoids = 30;
    public GameObject[] allBoids;
    public Vector3 range = new Vector3(5, 5, 5);
    public static Vector3 goalPos = Vector3.zero;

    public bool seekGoal = true;
    public bool obedient = true;
    public bool willful = false;

    [Range(0, 200)]
    public int neighbourDistance = 50;

    [Range(0, 2)]
    public float maxForce = 0.5f;

    [Range(0, 5)]
    public float maxVelocity = 2.0f;

    private void OnDrawGizmosSelected()
    {
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(this.transform.position, range * 2);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(this.transform.position, 0.2f);
        }
    }

	// Use this for initialization
	void Start () {
        allBoids = new GameObject[numBoids];

        for (int i = 0; i < numBoids; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-range.x, range.x),
                                      Random.Range(-range.y, range.y),
                                      0);
            allBoids[i] = Instantiate(boidPrefab, pos, Quaternion.identity);
            allBoids[i].GetComponent<Flock>().manager = this.gameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
        // update the goal position
        goalPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
	}
}
