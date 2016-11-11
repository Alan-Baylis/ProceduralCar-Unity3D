using UnityEngine;
using System.Collections;

public class WithCollider : MonoBehaviour
{
	Mesh mesh;
	Renderer renderer;
	MeshCollider collider;

	const int WIDTH = 10;
	const int HEIGHT = 10;
	const float QUAD_SIZE = 2.0f;

	float offset = 0;

	void Start()
	{
		mesh = gameObject.AddComponent<MeshFilter>().mesh;
		renderer = gameObject.AddComponent<MeshRenderer>();
		collider = gameObject.AddComponent<MeshCollider>();
	}

	void Update()
	{
		mesh.Clear();

		CreateVertices();
		CreateTriangles();
		CreateUV();
		AddMaterial();
		FlatGeometry();
		
		mesh.RecalculateNormals();
		collider.sharedMesh = mesh;

		offset += 0.01f;
	}

	void CreateVertices()
	{
		Vector3[] vertices = new Vector3[WIDTH * HEIGHT];

		for (int i = 0; i < WIDTH; i++)
		{
			for (int j = 0; j < HEIGHT; j++)
			{
				int index = j * WIDTH + i;

				float noiseX = 0.3f * i + offset;
				float noiseY = 0.3f * j + offset;
				vertices[index] = new Vector3(i * QUAD_SIZE, Mathf.PerlinNoise(noiseX, noiseY), j * QUAD_SIZE);
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
				triangles[triangleIndex++] = index + WIDTH;
				triangles[triangleIndex++] = index + 1;
				triangles[triangleIndex++] = index;
				
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

	void FlatGeometry()
	{
		Vector3[] oldVerts = mesh.vertices;
		Vector2[] oldUV = mesh.uv;
		
		int[] newTriangles = mesh.triangles;
		Vector3[] newVertices = new Vector3[newTriangles.Length];
		Vector2[] newUV = new Vector2[newTriangles.Length];

		for (int i = 0; i < newTriangles.Length; i++)
		{
			newVertices[i] = oldVerts[mesh.triangles[i]];
			newUV[i] = oldUV[mesh.triangles[i]];
			newTriangles[i] = i;
		}

		mesh.vertices = newVertices;
		mesh.triangles = newTriangles;
		mesh.uv = newUV;
	}
}

