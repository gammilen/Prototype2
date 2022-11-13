using UnityEngine;

namespace Flags
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class PlaneGrid : MonoBehaviour
    {
        [SerializeField] private int _xVertices;
        [SerializeField] private int _yVertices;
        private Vector3[] vertices;
        private Mesh mesh;

        private void Awake()
        {
            Generate();
        }

        private void Generate()
        {
            var xSize = _xVertices - 1;
            var ySize = _yVertices - 1;
            vertices = new Vector3[_xVertices * _yVertices];
            Vector2[] uv = new Vector2[vertices.Length];
            for (int i = 0, y = 0; y <= ySize; y++)
            {
                for (int x = 0; x <= xSize; x++, i++)
                {
                    vertices[i] = new Vector3(x, y, 0);
                    uv[i] = new Vector2((float)x / xSize, (float)y / ySize);
                }
            }

            GetComponent<MeshFilter>().mesh = mesh = new Mesh();
            mesh.name = "Grid";
            mesh.vertices = vertices;
            mesh.uv = uv;

            int[] triangles = new int[xSize * ySize * 6];
            for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++)
            {
                for (int x = 0; x < xSize; x++, ti += 6, vi++)
                {
                    if ((x + y) % 2 == 0)
                    {
                        triangles[ti] = vi;
                        triangles[ti + 1] = triangles[ti + 4] = vi + xSize + 1;
                        triangles[ti + 2] = triangles[ti + 3] = vi + 1;
                        triangles[ti + 5] = vi + xSize + 2;
                    }
                    else
                    {
                        triangles[ti] = triangles[ti + 3] = vi;
                        triangles[ti + 1] = triangles[ti + 5] = vi + xSize + 2;
                        triangles[ti + 2] = vi + 1;
                        triangles[ti + 4] = vi + xSize + 1;
                    }
                }
            }
            mesh.triangles = triangles;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (vertices == null)
            {
                return;
            }
            Gizmos.color = Color.black;
            for (int i = 0; i < vertices.Length; i++)
            {
                Gizmos.DrawSphere(vertices[i], 0.1f);
            }
        }
#endif
    }
}