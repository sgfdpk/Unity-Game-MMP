using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

	public Transform prefab;
	public int numberOfObjects;
	public Vector2 startPosition;
	private Vector2 nextPosition;
	public float recycleOffset;
	private Queue <Transform> objectQueue;
	public Vector2 minSize, maxSize,minGap,maxGap;
	public float minY, maxY;
	public Material[] materials;
	public PhysicMaterial[] physicMaterial;
	public Player player;
	//public Booster booster;


	private void Recycle(){
		Vector2 scale= new Vector2(Random.Range(minSize.x,maxSize.x),Random.Range(minSize.y,maxSize.y));
		Vector2 position = nextPosition;
		position.x += scale.x * 0.5f;
		position.y += scale.y * 0.5f;
//		booster.SpawnIfAvailable (position);

		Transform o = objectQueue.Dequeue ();
		o.localScale = scale;
		o.localPosition = position;
		nextPosition.x += scale.x;
		objectQueue.Enqueue (o);

		nextPosition += new Vector2 (Random.Range(minGap.x,maxGap.x)+scale.x,Random.Range(minGap.y,maxGap.y));
		if (nextPosition.y < minY)
			nextPosition.y = minY + maxGap.y;
		if (nextPosition.y > maxY)
			nextPosition.y = maxY - maxGap.y;
	}

	// Use this for initialization
	void Start () {
		
		objectQueue = new Queue<Transform> (numberOfObjects);
		for (int i = 0; i < numberOfObjects; i++) {
			objectQueue.Enqueue((Transform)Instantiate (prefab));
		}
		nextPosition = startPosition;
	for (int i = 0; i < numberOfObjects; i++) {
			Recycle ();
		}

		//PlatformsRestart();
	}

	public void PlatformsRestart(){
		Debug.Log ("ooo");
		nextPosition = startPosition;
	}

	// Update is called once per frame
	void Update () {
		if (objectQueue.Count != 0) {
			if (objectQueue.Peek ().localPosition.x + recycleOffset < Player.distanceTreveled) {
				Recycle ();
			}
		} 
	}
}
