using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyAI : MonoBehaviour
{
    public GameObject waypoint1;
    public GameObject waypoint2;
    public float travelDuration;
    public float wait;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(moveBetweenWaypoints());
    }

    // Moves constantly between waypoints, waiting inbetween
    public IEnumerator moveBetweenWaypoints()
    {
        yield return StartCoroutine(moveToWaypoint(waypoint1));
        yield return new WaitForSeconds(wait);
        yield return StartCoroutine(moveToWaypoint(waypoint2));
        yield return new WaitForSeconds(wait);
        yield return null;
    }

    // Moves to a waypoint over a duration of time
    public IEnumerator moveToWaypoint(GameObject waypoint)
    {
        float counter = 0f;
        Vector2 waypointPos = waypoint.transform.position;
        while (counter < travelDuration)
        {
            transform.position = Vector2.Lerp(transform.position, waypointPos, counter / travelDuration);
            counter += Time.deltaTime;
            yield return null;
        }
        transform.position = waypointPos;
    }

}
