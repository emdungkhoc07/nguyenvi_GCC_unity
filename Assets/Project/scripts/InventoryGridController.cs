using UnityEngine;
using UnityEngine.UI;

public class InventoryGridController : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private GridLayoutGroup gridLayout;
    [SerializeField] private Slider spacingSlider;
    [SerializeField] private GameObject slotPrefab;

    [Header("Cài đặt bàn cờ")]
    [Range(2, 5)] 
    [SerializeField] private int gridSize = 3; // 2 -> 4 ô, 3 -> 9 ô, 4 -> 16 ô, 5 -> 25 ô

    void Start()
    {
        TaoBanCo();

        // Lắng nghe sự kiện kéo thanh Slider
        if (spacingSlider != null)
        {
            spacingSlider.onValueChanged.AddListener(ThayDoiKhoangCach);
            ThayDoiKhoangCach(spacingSlider.value);
        }
    }

    // Tự động sinh số lượng ô vuông (từ 4 đến 25 ô)
    [ContextMenu("Tạo lại bàn cờ")]
    public void TaoBanCo()
    {
        // 1. Xóa các ô cũ (nếu có)
        for (int i = gridLayout.transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(gridLayout.transform.GetChild(i).gameObject);
        }

        // 2. Ép số cột của Grid Layout Group bằng kích thước cạnh bàn cờ
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = gridSize;

        // 3. Nhân bản số lượng ô vuông (gridSize * gridSize)
        int totalSlots = gridSize * gridSize;
        for (int i = 0; i < totalSlots; i++)
        {
            Instantiate(slotPrefab, gridLayout.transform);
        }
    }

    // Thay đổi Spacing khi kéo thanh trượt
    public void ThayDoiKhoangCach(float value)
    {
        if (gridLayout != null)
        {
            // value = 0: dính sát nhau; value > 0: cách xa nhau
            gridLayout.spacing = new Vector2(value, value);
        }
    }
}