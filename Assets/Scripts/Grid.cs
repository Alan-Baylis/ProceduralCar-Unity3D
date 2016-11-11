using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{
  Mesh mesh;
	Renderer renderer;

	const int WIDTH = 10;
	const int HEIGHT = 10;
	const float QUAD_SIZE = 0.5f;

	void Start()
	{
		mesh = gameObject.AddComponent<MeshFilter>().mesh;
		renderer = gameObject.AddComponent<MeshRenderer>();

		CreateVertices();
		CreateTriangles();
		CreateUV();
		AddMaterial();

		mesh.RecalculateNormals();
	}

	void CreateVertices()
	{
		Vector3[] vertices = new Vector3[WIDTH * HEIGHT];

		for (int i = 0; i < WIDTH; i++)
		{
			for (int j = 0; j < HEIGHT; j++)
			{
				int index = j * WIDTH + i;
				vertices[index] = new Vector3(i * QUAD_SIZE, j * QUAD_SIZE, 0);
			}
		}

		mesh.vertices = vertices;
	}

	void CreateTriangles()
	{
		int[] triangles = new int[3 * 2 * (WIDTH - 1) * (HEIGHT - 1)];

		int triangleIndex = 0;

		for (int i = 0; i < WIDTH - 1; i++)
		{
			for (int j = 0; j < HEIGHT - 1; j++)
			{
				int index = j * WIDTH + i;

				// triangle 1
				triangles[triangleIndex++] = index;
				triangles[triangleIndex++] = index + WIDTH;
				triangles[triangleIndex++] = index + 1;
				
				// triangle 2
				triangles[triangleIndex++] = index + WIDTH;
				triangles[triangleIndex++] = index + WIDTH + 1;
				triangles[triangleIndex++] = index + 1;
			}
		}

		mesh.triangles = triangles;
	}

	void CreateUV()
	{
		Vector2[] uv = new Vector2[WIDTH * HEIGHT];

		for (int i = 0; i < WIDTH; i++)
		{
			for (int j = 0; j < HEIGHT; j++)
			{
				int index = j * WIDTH + i;
				uv[index] = new Vector2((float)i / (WIDTH - 1), (float)j / (HEIGHT - 1));
			}
		}

		mesh.uv = uv;
	}

	void AddMaterial()
	{
		Material material = Resources.Load("Material") as Material;
		renderer.material = material;
	}
}