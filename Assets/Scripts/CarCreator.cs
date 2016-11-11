using UnityEngine;
using UnityEditor;
using System.Collections;

public class CarCreator : MonoBehaviour
{
	Mesh mesh;
	MeshFilter meshFilter;
	Renderer renderer;

	[Range(-8, -6)]
	public float frontUp;

	[Range(-12, -8)]
	public float frontDown;

	[Range(10, 13)]
	public float backUp;

	[Range(13, 15)]
	public float backDown;

	[Range(5, 10)]
	public float top;

	[Range(-4, -6)]
	public float bottom;

	[Range(8, 12)]
	public float width;

	[Range(5, 8)]
	public float topWidth;
	
	void Start()
	{
		meshFilter = gameObject.AddComponent<MeshFilter>();
		mesh = meshFilter.mesh;
		renderer = gameObject.AddComponent<MeshRenderer>();

		NewCar();
	}

	void Update()
	{
		CreateGeometry();
	}

	void CreateGeometry()
	{
		mesh.Clear();

		mesh.vertices = new Vector3[]
		{
			new Vector3(frontUp, top , topWidth), // 0
			new Vector3(backUp, top, topWidth),
			new Vector3(frontUp, top , -topWidth),
			new Vector3(backUp, top , -topWidth),

			new Vector3(frontUp, top , topWidth), // 4
			new Vector3(backUp, top, topWidth),
			new Vector3(frontDown, 0 , width),
			new Vector3(backDown, 0 , width),

			new Vector3(frontUp, top , -topWidth), // 8
			new Vector3(backUp, top , -topWidth),
			new Vector3(frontDown, 0 , -width),
			new Vector3(backDown, 0 , -width),

			new Vector3(frontUp, top , topWidth), // 12
			new Vector3(frontUp, top , -topWidth),
			new Vector3(frontDown, 0 , width),
			new Vector3(frontDown, 0 , -width),

			new Vector3(backUp, top, topWidth), // 16
			new Vector3(backUp, top , -topWidth),
			new Vector3(backDown, 0 , width),
			new Vector3(backDown, 0 , -width),

			new Vector3(-15, 0 , width), // 20
			new Vector3(frontDown, 0 , width),
			new Vector3(-15, 0 , -width),
			new Vector3(frontDown, 0 , -width),

			new Vector3(backDown, 0 , width), // 24
			new Vector3(15, 0 , width),
			new Vector3(backDown, 0 , -width),
			new Vector3(15, 0 , -width),

			new Vector3(-15, 0 , width), // 28
			new Vector3(-15, 0 , -width),
			new Vector3(-15, bottom , width),
			new Vector3(-15, bottom , -width),

			new Vector3(15, 0 , width), //32
			new Vector3(15, 0 , -width),
			new Vector3(15, bottom , width),
			new Vector3(15, bottom , -width),

			new Vector3(-15, 0 , width), // 36
			new Vector3(15, 0 , width),
			new Vector3(-15, bottom , width),
			new Vector3(15, bottom , width),

			new Vector3(-15, 0 , -width), //40
			new Vector3(15, 0 , -width),
			new Vector3(-15, bottom , -width),
			new Vector3(15, bottom , -width)
		};

		mesh.triangles = new int[]
		{
			0, 1, 2,
			1, 3, 2,
			5, 4, 6,
			5, 6, 7,
			8, 9, 10,
			9, 11, 10,
			12, 13, 14,
			13, 15, 14,
			17, 16, 18,
			19, 17, 18,
			20, 21, 22,
			21, 23, 22,
			24, 25, 26,
			25, 27, 26,
			28, 29, 30,
			29, 31, 30,
			37, 36, 38,
			37, 38, 39,
			33, 32, 34,
			33, 34, 35,
			40, 41, 42,
			41, 43, 42,
		};

		mesh.uv = new Vector2[]
		{
			new Vector2(0, 0.5f), // 0
			new Vector2(0, 1),
			new Vector2(0.5f, 1),
			new Vector2(0.5f, 0.5f),
			
			new Vector2(1, 1), // 4
			new Vector2(0.5f, 1),
			new Vector2(1, 0.5f),
			new Vector2(0.5f, 0.5f),
			

			new Vector2(0.5f, 1), // 8
			new Vector2(1, 1),
			new Vector2(0.5f, 0.5f),
			new Vector2(1, 0.5f),
			

			new Vector2(0.5f, 1), // 12
			new Vector2(1, 1),
			new Vector2(0.5f, 0.5f),
			new Vector2(1, 0.5f),

			new Vector2(1, 1), // 16
			new Vector2(0.5f, 1),
			new Vector2(1, 0.5f),
			new Vector2(0.5f, 0.5f),

			new Vector2(0, 0.5f), // 20
			new Vector2(0, 1),
			new Vector2(0.5f, 1),
			new Vector2(0.5f, 0.5f),

			new Vector2(0, 0.5f), // 24
			new Vector2(0, 1),
			new Vector2(0.5f, 1),
			new Vector2(0.5f, 0.5f),

			new Vector2(0, 0.5f), // 28
			new Vector2(0.5f, 0.5f),
			new Vector2(0, 0),
			new Vector2(0.5f, 0),

			new Vector2(1, 0.5f), // 32
			new Vector2(0.5f, 0.5f),
			new Vector2(1, 0),
			new Vector2(0.5f, 0),

			new Vector2(0, 1), // 36
			new Vector2(0, 0.5f),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.5f, 1),

			new Vector2(0, 0.5f), // 40
			new Vector2(0, 1),
			new Vector2(0.5f, 1),
			new Vector2(0.5f, 0.5f),
		};

		mesh.RecalculateNormals();
		renderer.material = Resources.Load("Car") as Material;
	}

	public void NewCar()
	{
		frontUp = Random.Range(-8, -6);
		frontDown = Random.Range(-12, -8);
		backUp = Random.Range(10, 13);
		backDown = Random.Range(13, 15);
		top = Random.Range(5, 10);
		bottom = Random.Range(-4, -7);
		width = Random.Range(8, 12);
		topWidth = Random.Range(5, 8);
	}

	public void SaveCar()
	{
		AssetDatabase.CreateAsset(mesh, "Assets/car.prefab");
		AssetDatabase.SaveAssets();
	}
}
