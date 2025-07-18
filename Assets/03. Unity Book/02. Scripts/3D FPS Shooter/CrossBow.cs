using System;
using System.Collections;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPos;

    public bool isShoot;


    private void Update()
    {
        Ray ray = new Ray(shootPos.position, shootPos.forward);
        RaycastHit hit; // 레이저 닿은 대상
        
        bool isTargetring = Physics.Raycast(ray, out hit);

        Debug.DrawRay(shootPos.position,shootPos.forward,Color.green);
        
        if (isTargetring && !isShoot)
        {
            StartCoroutine(ShootRoutine());
        }
    }

    IEnumerator ShootRoutine()
    {
        isShoot = true;
        GameObject arraw = Instantiate(arrowPrefab, transform);
        Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));
        
        // arraw.transform.SetPositionAndRotation(shootPos.position, rot);
        arraw.transform.position = shootPos.position;
        arraw.transform.rotation = rot;
        
        yield return new WaitForSeconds(3f);
        isShoot = false;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shootPos.position, shootPos.forward * 100f);
    }
    
}