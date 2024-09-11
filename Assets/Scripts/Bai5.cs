using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bai5 : MonoBehaviour
{
    [SerializeField]
    private Transform transformA;
    [SerializeField]
    private Transform transformB;
    private Vector3 targetPosition;
    [SerializeField]
    private float speed = 2;
    private void Awake() {
        targetPosition = transformB.position;
        transform.position = transformA.position;
    }
    void Update()
    {
        if(Vector3.Distance(transform.position, targetPosition) < 0.1f){
            targetPosition = targetPosition == transformA.position ? transformB.position : transformA.position;
        }
        else{
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
