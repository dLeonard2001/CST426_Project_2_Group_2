using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    public List<Transform> randomPositionList = new List<Transform>();
    private float portalRadius;
    [SerializeField] private Transform cube;
    private Transform currentCube;
    [SerializeField] private bool showGizmos = false;

    public void Init(float portalRadius)
    {
        this.portalRadius = portalRadius;
        currentCube = Instantiate(cube, transform);
        RandomPosition();
        StartCoroutine(WaitForFalling());
    }

    private void OnDrawGizmos()
    {
        if (!showGizmos) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, portalRadius);
    }

    IEnumerator WaitForFalling()
    {
        var speedControl = currentCube.GetComponent<SpeedControl>();

        yield return new WaitUntil(() => speedControl.startFalling == false);

        if(randomPositionList.Count < 1)    randomPositionList.Add(currentCube);

        yield return new WaitForSeconds(0.3f);

        RandomPosition();

    }

    private void RandomPosition()
    {
        var randomX = Random.Range(-portalRadius, portalRadius);
        var randomZ = Random.Range(-portalRadius, portalRadius);
        //        Debug.Log(randomX + " " + randomZ);
        currentCube.transform.localPosition = new Vector3(randomX, 10, randomZ);
    }

    public List<Transform> GetPartolList()
    {
        if(randomPositionList.Count > 0 && randomPositionList[0].GetComponent<SpeedControl>().startFalling == false)  
        {
            randomPositionList[0].gameObject.SetActive(true);
            StartCoroutine(WaitForFalling());
            return randomPositionList;
        }
        else
        {
            return null;
        }
    }
}
