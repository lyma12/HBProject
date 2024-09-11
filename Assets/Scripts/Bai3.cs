using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Bai3 : MonoBehaviour
{
    [SerializeField]
    private Transform[] listTransform; 
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private TextMeshProUGUI startText;
    private Queue<Vector3> positionQueue;
    private Vector3 startPosition;
    private void Awake() {
        if(listTransform.Length == 3){
            positionQueue = new Queue<Vector3>();
            startPosition = transform.position;
            foreach(Transform i in listTransform){
                positionQueue.Enqueue(i.position);
            }
            positionQueue.Enqueue(transform.position);
            SetupText();
            Debug.Log("start");
        }
        else{
            Debug.Log("Add 3 position");
        }
    }
    private void SetupText(){
        startText.text = "Start move to random position.\n"
            + $"Position 1: {listTransform[0].position.ToString()}\n"
            + $"Position 2: {listTransform[1].position.ToString()}\n"
            + $"Position 3: {listTransform[2].position.ToString()}";
    }
    private Vector3 CreateRandomPosition(){
        return new Vector3(Random.Range(-5, 5), 0.5f, Random.Range(-5, 5));
    }
    private void SetRandomPosition(){
        for(int i = 0; i < 3; i++){
            listTransform[i].position = CreateRandomPosition();
            positionQueue.Enqueue(listTransform[i].position);
        }
        positionQueue.Enqueue(startPosition);
        SetupText();
    }
    private void FixedUpdate() {
        if(listTransform.Length == 3){
            if(positionQueue.Count != 0){
                if(Vector3.Distance(transform.position, positionQueue.Peek()) < 0.1f){
                positionQueue.Dequeue();
            }
            else{
                var step = speed * Time.deltaTime;
                transform.position =  Vector3.MoveTowards(transform.position, positionQueue.Peek(), step);
            }
            }else if(positionQueue.Count == 0){
                SetRandomPosition();
            }
        }
    }
}
