using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairMasterControlScript : MonoBehaviour
{
    public GameObject FairyPrefab;
    public Transform FairyTarget;
    public Camera CameraObj;

    void Start()
    {
        FairyPrefab.GetComponent<FariyChaseController>().TargetPos = FairyTarget;
    }

    private void SpawnFairy()
    {
        var newObj = Instantiate(FairyPrefab, this.gameObject.transform.position, CameraObj.transform.rotation);
        var newChaseController = newObj.GetComponent<FariyChaseController>();
        newChaseController.LookSpeed = Random.Range(0.5f, 5.0f);
        newChaseController.MinSpeed = Random.Range(300.0f, 600.0f);
        newChaseController.MaxSpeed = Random.Range(800.0f, 1500.0f);
    }

    public void OnReleaseFairyPressed()
    {
        SpawnFairy();
    }
}


