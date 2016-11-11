using UnityEngine;

public class Triangle : MonoBehaviour
{
	Mesh mesh;

	void Start()
	{
		mesh = gameObject.AddComponent<MeshFilter>().mesh;
		gameObject.AddComponent<MeshRenderer>();
		CreateGeometry();
	}

	void CreateGeometry()
	{
		mesh.vertices = new Vector3[]
		{
			new Vector3(0, 0, 0 ),
			new Vector3(5, 0, 0),
			new Vector3(5, 5, 0)
		};

		mesh.triangles = new int[] { 2, 1, 0 };
	}
}


