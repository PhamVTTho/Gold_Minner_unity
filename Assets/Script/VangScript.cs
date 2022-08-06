using UnityEngine;
using System.Collections;

public class VangScript : MonoBehaviour {
	public bool isMoveFollow = false;
	public float maxY;
	public int score;
	public float speed;

	private GameObject moNeo;
	private GameObject rope;
	void Start () {
		isMoveFollow = false;
		moNeo = GameObject.FindGameObjectWithTag("MoNeo");
		rope = GameObject.FindGameObjectWithTag("Rope");
        if (GameObject.FindGameObjectWithTag("Rock"))
        {
			score = Random.Range(50, 150);
        }
	}
	void FixedUpdate() {
		moveFllowTarget(moNeo.transform);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("MoNeo")) {
			isMoveFollow = true;
			rope.GetComponent<DayCauScript>().typeAction = TypeAction.KeoCau;
			moNeo.GetComponent<LuoiCauScript>().velocity = -moNeo.GetComponent<LuoiCauScript>().velocity;
			moNeo.GetComponent<LuoiCauScript>().speed -= this.speed;
		}
	}

	void moveFllowTarget(Transform target) {
		if(isMoveFollow) 
		{
				Quaternion tg = Quaternion.Euler(target.parent.transform.rotation.x, 
				                                 target.parent.transform.rotation.y, 
				                                 90 + target.parent.transform.rotation.z);
				transform.position = new Vector3(target.position.x, 
				                                 target.position.y - gameObject.GetComponent<Collider2D>().GetComponent<Collider2D>().bounds.size.y / 2, 
				                                 transform.position.z);	
			if(rope.GetComponent<DayCauScript>().typeAction == TypeAction.Nghi) {
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GamePlayScript>().score += this.score;
                Destroy(gameObject);
			}
		}
	}
}
