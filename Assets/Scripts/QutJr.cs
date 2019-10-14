using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QutJr : MonoBehaviour
{
	public GameObject limb;
	public int limbsCount = 4;
	public Material material;
	private Limb[] limbs;
	void Start()
	{
		limbs = new Limb[4];
		Limb l1 = Instantiate(limb).GetComponent<Limb>();
		l1.jointLocation = new Vector3(0, 0, 1);
		l1.jointOffset = new Vector3(0, 2, 1);
		l1.limbVertexLocations = new Vector3[] {
						new Vector3(-0.1f,0,1),
						new Vector3(-0.1f,1,1),
						new Vector3(0.1f,1,1),
						new Vector3(0.1f,0,1)
		};
		l1.material = material;
		limbs[0] = l1;
		Limb l2 = Instantiate(limb).GetComponent<Limb>();
		l2.jointLocation = new Vector3(0, 2, 1);
		l2.jointOffset = new Vector3(0, 2, 1);
		l2.limbVertexLocations = new Vector3[] {
						new Vector3(-0.25f,0,1),
						new Vector3(-0.25f,2,1),
						new Vector3(0.25f,2,1),
						new Vector3(0.25f,0,1)
		};
		l2.material = material;
		l2.angle = 3;
		l2.child = l1;
		limbs[1] = l2;
		Limb l3 = Instantiate(limb).GetComponent<Limb>();
		l3.jointLocation = new Vector3(0, 0, 1);
		l3.jointOffset = new Vector3(0, 2, 1);
		l3.limbVertexLocations = new Vector3[] {
						new Vector3(-0.25f,0,1),
						new Vector3(-0.25f,2,1),
						new Vector3(0.25f,2,1),
						new Vector3(0.25f,0,1)
		};
		l3.material = material;
		l3.child = l2;
		limbs[2] = l3;
		Limb l4 = Instantiate(limb).GetComponent<Limb>();
		l4.jointLocation = new Vector3(0, 0, 1);
		l4.jointOffset = new Vector3(0, 0, 0);
		l4.limbVertexLocations = new Vector3[] {
						new Vector3(-1,-1,1),
						new Vector3(-1,0,1),
						new Vector3(1,0,1),
						new Vector3(1,-1,1)
		};
		l4.material = material;
		l4.child = l3;
		limbs[3] = l4;
	}

	void Update()
	{

	}
}
