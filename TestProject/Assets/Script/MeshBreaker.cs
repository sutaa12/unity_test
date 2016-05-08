using UnityEngine;
using System.Collections;

public class MeshBreaker : MonoBehaviour {
    Vector3[] newVertices;
    Vector2[] newUV;
    int[] newTriangles;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        if (mesh)
        {
            newVertices = mesh.vertices;
            newUV = mesh.uv;
            newTriangles = mesh.triangles;
            int cnt = newTriangles.GetLength(0);
            Vector3[] newVertices_2 = new Vector3[cnt];
            Vector2[] newUV_2 = new Vector2[cnt];
            int[] newTriangles_2 = new int[cnt];
            Vector3 random = GetRandom(500);
            for (int i = 0;i < cnt;++i)
            {
                if(i%3 == 0)
                {
                    random = GetRandom(500);
                }
                newVertices_2[i] = newVertices[newTriangles[i]];
                newVertices_2[i] += random;
                newTriangles_2[i] = i;
                newUV_2[i] = newUV[newTriangles[i]];
            }
            mesh.Clear();
            mesh.vertices = newVertices_2;
            mesh.uv = newUV_2;
            mesh.triangles = newTriangles_2;
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();
        }
    }
    Vector3 GetRandom(float max)
    {
        float rand = Random.Range(0, max);
        rand -= (max / 2.0f);
        float random_coefficient = 10000.0f;
        Vector3 random = new Vector3(rand/ random_coefficient, rand / random_coefficient, rand / random_coefficient);
        return random;
    }
}
