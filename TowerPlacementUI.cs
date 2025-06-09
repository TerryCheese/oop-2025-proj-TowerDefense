using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerPlacementUI : MonoBehaviour
{
    public GameObject[] towerPrefabs; // Array of tower prefabs
    public Texture2D[] towerSprites; // Array of tower sprite images
    public Button[] towerButtons; // Array of tower buttons
    public float towerYOffset = 0.3f; // Offset to position the tower above the tile

    private int selectedIndex = -1; // Index of the currently selected tower
    private Color selectedButtonColor = new Color(1f, 1f, 1f, 0.5f); // Color for the selected button
    private Color defaultButtonColor = new Color(1f, 1f, 1f, 1f); // Default color for the buttons


    void Start()
    {
        // Initialize the tower button images and colors
        for (int i = 0; i < towerButtons.Length; i++)
        {
            towerButtons[i].GetComponent<RawImage>().texture = towerSprites[i];
            towerButtons[i].GetComponent<RawImage>().color = defaultButtonColor;

            // Add a listener to each button to call SelectTower with the correct index
            int index = i; // Capture the current index in a local variable
            towerButtons[i].onClick.AddListener(() => SelectTower(index));
        }
    }

    public void SelectTower(int index)
    {
        // Deselect the previously selected tower, if any
        if (selectedIndex != -1)
        {
            towerButtons[selectedIndex].GetComponent<RawImage>().color = defaultButtonColor;
        }

        // Set the selected tower based on the index
        selectedIndex = index;
        towerButtons[selectedIndex].GetComponent<RawImage>().color = selectedButtonColor;

        Debug.Log("Selected tower: " + towerPrefabs[selectedIndex].name);
    }

    void Update()
    {
        if (selectedIndex != -1 && Input.GetMouseButtonDown(0))
        {
            // Get the cost from the prefab
            int towerCost = towerPrefabs[selectedIndex].GetComponent<TowerBehavior>().towerCost;

            // Find the CoinSystem in the scene
            CoinSystem coinSystem = FindFirstObjectByType<CoinSystem>();
            if (coinSystem != null && coinSystem.SpendCoins(towerCost))
            {
                PlaceTower(towerPrefabs[selectedIndex]);
            }
            else
            {
                Debug.Log("Not enough coins to build the tower.");
            }
        }
    }

    private void PlaceTower(GameObject tower)
    {
        // Skip if the pointer is over a UI element
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Pointer is over a UI element. Skipping raycast.");
            return;
        }

        // Cast a ray from the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the ray hit a valid tile
            if (hit.collider.CompareTag("Tile"))
            {
                // Calculate the tower's position above the tile
                Vector3 towerPosition = new Vector3(hit.transform.position.x, hit.transform.position.y + towerYOffset, hit.transform.position.z);
                // Instantiate the selected tower at the hit position
                Instantiate(tower, towerPosition, Quaternion.identity);
                // newTower.GetComponent<TowerBehavior>().BuildTower();
                Debug.Log("Tower placed at: " + towerPosition);
            }
            else
            {
                Debug.Log("Raycast hit an object, but it is not a tile.");
            }
        }
        else
        {
            Debug.Log("Raycast did not hit anything.");
        }
    }
}
