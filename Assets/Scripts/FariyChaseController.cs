using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FariyChaseController : MonoBehaviour
{
    public Transform TargetPos;
    [Range(300.0F, 600.0F)]
    public float MinSpeed = 500;
    [Range(800.0F, 1500.0F)]
    public float MaxSpeed = 1200;
    [Range(0.5F, 5.0F)]
    public float LookSpeed = 2.0f;

    public VisualEffect FairyParticles;
    private Rigidbody _rBody;
    // Start is called before the first frame update
    void Start()
    {
        _rBody = GetComponent<Rigidbody>();
        FairyParticles.SetVector4("MainColour", Random.ColorHSV(0,1));
    }

    // Update is called once per frame
    void Update()
    {
        var dir2target = (TargetPos.position - transform.position).normalized;
        var dist2Target = Vector3.Distance(TargetPos.position, transform.position);
        // smoothdamp, slep, or just apply it instantly
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir2target), LookSpeed * Time.deltaTime);
        
        _rBody.AddForce(transform.forward * Mathf.Lerp(MinSpeed, MaxSpeed, dist2Target / 10.0f) * Time.deltaTime, ForceMode.Force);
    }
}
