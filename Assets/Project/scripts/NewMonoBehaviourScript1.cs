using UnityEngine;

public class NewMonoBehaviourScript1 : MonoBehaviour
{
    [Header("Cài đặt lưới")]
    [SerializeField] int columns = 8;
    [SerializeField] int rows = 5;
    [SerializeField] float cellSize = 1f;

    void Start()
    {
        transform.position = Vector3.zero;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 90f * Time.deltaTime));
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.matrix = transform.localToWorldMatrix;

        float width = columns * cellSize;
        float height = rows * cellSize;

        Vector3 tamDoThi = new Vector3(-width / 2f, -height / 2f, 0f);

        // Kẻ các đường dọc
        for (int i = 0; i <= columns; i++)
        {
            Vector3 bottom = tamDoThi + Vector3.right * (i * cellSize);
            Gizmos.DrawLine(bottom, bottom + Vector3.up * height);
        }

        // Kẻ các đường ngang
        for (int j = 0; j <= rows; j++)
        {
            Vector3 left = tamDoThi + Vector3.up * (j * cellSize);
            Gizmos.DrawLine(left, left + Vector3.right * width);
        }
    }
}