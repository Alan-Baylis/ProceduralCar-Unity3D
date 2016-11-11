using UnityEngine;

public class TexturedQuad : MonoBehaviour
{
	Mesh mesh;
	Renderer renderer;

	void Start()
	{
		mesh = gameObject.AddComponent<MeshFilter>().mesh;
		renderer = gameObject.AddComponent<MeshRenderer>();
		CreateGeometry();
	}

	void CreateGeometry()
	{
		mesh.vertices = new Vector3[]
		{
			new Vector3(0, 0, 0),
			new Vector3(5, 0, 0),
			new Vector3(5, 5, 0),
			new Vector3(0, 5, 0)
		};

		mesh.triangles = new int[] { 2, 1, 0, 3, 2, 0 };

		mesh.uv = new Vector2[]
		{
			new Vector2(0, 0),
			new Vector2(1, 0),
			new Vector2(1, 1),
			new Vector2(0, 1)
		};

		mesh.RecalculateNormals();
		renderer.material = Resources.Load("Material") as Material;
	}
}

