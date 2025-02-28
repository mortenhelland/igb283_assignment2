﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QutJr : MonoBehaviour
{
	public GameObject limb;
	public int limbsCount = 4;
	public Material material;

	private Limb[] limbs;
	private float maxAngle = 1f;
	private float minAngle = -1f;
	private float LowerArmSpeed = 3.14f;
	private float UpperArmSpeed = 2.07f;
	private float BaseArmSpeed = 1.035f;
	void Start()
	{
		limbs = new Limb[4];

		// Head
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
		l1.color = new Color32(66, 133, 244, 255);
		limbs[0] = l1;

		//Lower Arm
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
		l2.color = new Color32(219, 68, 55, 255);
		l2.child = l1;
		limbs[1] = l2;

		// Upper Arm
		Limb l3 = Instantiate(limb).GetComponent<Limb>();
		l3.jointLocation = new Vector3(0, 2, 1);
		l3.jointOffset = new Vector3(0, 2, 1);
		l3.limbVertexLocations = new Vector3[] {
						new Vector3(-0.25f,0,1),
						new Vector3(-0.25f,2,1),
						new Vector3(0.25f,2,1),
						new Vector3(0.25f,0,1)
		};
		l3.material = material;
		l3.color = new Color32(244, 180, 0, 255);
		l3.child = l2;
		limbs[2] = l3;

		// Base
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
		l4.color = new Color32(15, 157, 88, 255);
		l4.child = l3;
		limbs[3] = l4;
	}

	void Update()
	{
		Limb LowerArm = limbs[1];

		LowerArm.angle += LowerArmSpeed * Time.deltaTime;

		LowerArm.angle = LowerArm.angle >= maxAngle ? maxAngle : LowerArm.angle;
		LowerArm.angle = LowerArm.angle <= minAngle ? minAngle : LowerArm.angle;

		LowerArmSpeed = LowerArm.angle < maxAngle && LowerArm.angle > minAngle ? LowerArmSpeed : -LowerArmSpeed;

		LowerArm.child.GetComponent<Limb>().RotateAroundPoint(LowerArm.jointLocation, LowerArm.angle, LowerArm.lastAngle);
		LowerArm.mesh.RecalculateBounds();
		LowerArm.lastAngle = LowerArm.angle;

		Limb UpperArm = limbs[2];

		UpperArm.angle += UpperArmSpeed * Time.deltaTime;

		UpperArm.angle = UpperArm.angle >= maxAngle ? maxAngle : UpperArm.angle;
		UpperArm.angle = UpperArm.angle <= minAngle ? minAngle : UpperArm.angle;

		UpperArmSpeed = UpperArm.angle < maxAngle && UpperArm.angle > minAngle ? UpperArmSpeed : -UpperArmSpeed;

		UpperArm.child.GetComponent<Limb>().RotateAroundPoint(UpperArm.jointLocation, UpperArm.angle, UpperArm.lastAngle);
		UpperArm.mesh.RecalculateBounds();
		UpperArm.lastAngle = UpperArm.angle;
	}
}
