using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointLogic : MonoBehaviour
{
    public List<CheckPoint> spawnPoints;

    public static CheckPointLogic Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        SetFirstPoint();
    }

    private void SetFirstPoint()
    {
        bool hasCurrent = false;
        foreach (CheckPoint point in spawnPoints)
        {
            if (point.isCurrent)
            {
                hasCurrent = true;
                break;
            }
        }

        if (!hasCurrent)
            spawnPoints[0].isCurrent = true;
    }

    public void SpawnOnCheckPoint(GameObject obj)
    {
        CheckPoint spawnPoint = GetCurrentCheckPoint();
        Debug.Log(121212121212);
        if (obj.TryGetComponent(out CharacterController controller))
        {
            Debug.Log(345432);
            obj.GetComponent<CharacterController>().enabled = false;
            obj.AddComponent<Rigidbody>();
            obj.transform.position = spawnPoint.transform.position;
            StartCoroutine(Aaaaaa(obj));
        }
        else
        {
            obj.transform.position = spawnPoint.transform.position;
        }
    }

    private IEnumerator Aaaaaa(GameObject huy)
    {
        yield return new WaitForSeconds(0.5f);
        huy.GetComponent<CharacterController>().enabled = true;
        Destroy(huy.GetComponent<Rigidbody>());
    }

    public CheckPoint GetCurrentCheckPoint()
    {
        foreach (var spawnPoint in spawnPoints)
        {
            if (spawnPoint.isCurrent)
                return spawnPoint;
        }

        return null;
    }

    public void SetCheckPoint(GameObject obj)
    {
        foreach (var spawnPoint in spawnPoints)
        {
            spawnPoint.isCurrent = false;
        }

        obj.GetComponent<CheckPoint>().isCurrent = true;
    }
}