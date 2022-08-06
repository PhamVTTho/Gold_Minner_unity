using UnityEngine;
using System.Collections;

public class LuoiCauScript : MonoBehaviour {
	[HideInInspector] public float maxX, minX, minY, maxY;
	[HideInInspector] public Vector2 velocity;
	public float speed;
	public float speedMin;
	public float speedBegin;

	public Transform target;
	Vector3 prePosition;
	public Animator animator;

	public int type;
	public bool isUpSpeed;
	public float timeUpSpeed;
	private GameObject rope;

	void Start () {
		isUpSpeed = false;
		prePosition = transform.localPosition;
		rope = GameObject.FindGameObjectWithTag("Rope");
	}

	public IEnumerator TimeUpSpeed ()
	{
		while(true){
			if(isUpSpeed)
			{
				timeUpSpeed = timeUpSpeed - 1;
				if(timeUpSpeed <= 0)
					isUpSpeed = false;
			}
			yield return new WaitForSeconds (1f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		checkKeoCauXong();
		{
			checkTouchScene();

			checkMoveOutCameraView();
		}
	}
	void FixedUpdate() {
		{
			if(rope.GetComponent<DayCauScript>().typeAction == TypeAction.ThaCau || 
			   rope.GetComponent<DayCauScript>().typeAction == TypeAction.KeoCau)
			   this.GetComponent<Rigidbody2D>().velocity = velocity * speed;
		}
	}

	

	bool checkPositionOutBound() {
		return  this.gameObject.GetComponent<Renderer>().isVisible ;
	}

	void checkTouchScene() {
		bool istouch = Input.GetMouseButtonDown(0);
		if(istouch && rope.GetComponent<DayCauScript>().typeAction == TypeAction.Nghi)
		{
			rope.GetComponent<DayCauScript>().typeAction = TypeAction.ThaCau;
			velocity = new Vector2(transform.position.x - target.position.x, 
			                       transform.position.y - target.position.y);
			animator.Play("Character-Animation");
			velocity.Normalize();
			speed = speedBegin;
		}
	}
	//kiem tra khi luoi cau ra ngoai tam nhin cua camera
	void checkMoveOutCameraView() {
		if(rope.GetComponent<DayCauScript>().typeAction == TypeAction.ThaCau) {
			if(!checkPositionOutBound()) {
				rope.GetComponent<DayCauScript>().typeAction = TypeAction.KeoCau;
				velocity = -velocity;
			}
		}
	}

	//kiem tra khi luoi ca keo len mat nuoc
	void checkKeoCauXong() {
		if(transform.localPosition.y > maxY && rope.GetComponent<DayCauScript>().typeAction == TypeAction.KeoCau) {
			Debug.Log("keo cau xong");
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			rope.GetComponent<DayCauScript>().typeAction = TypeAction.Nghi;
			animator.Play("None");
			transform.localPosition = prePosition;
		}
	}
}
