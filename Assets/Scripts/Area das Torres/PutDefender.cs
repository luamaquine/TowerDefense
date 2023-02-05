using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutDefender : MonoBehaviour
{
    public GameObject shooterPrefab;
    public GameObject magePrefab;
    public GameObject tankPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnMouseDown()
    {
        if (BuyController.isBuying == true)
        {
            if (BuyController.charSelected == "shooter")
            {
                GameObject newTower = Instantiate(shooterPrefab, transform.position, Quaternion.identity);
                Debug.Log("Colocou o shooter");
                BuyController.isBuying = false;
                GameController.coins = GameController.coins - 30;
                //BuyController.shooterArea.SetActive(false);
            }
            if (BuyController.charSelected == "mage")
            {
                GameObject newTower = Instantiate(magePrefab, transform.position, Quaternion.identity);
                Debug.Log("Colocou o mage");
                BuyController.isBuying = false;
                GameController.coins = GameController.coins - 50;
                //BuyController.shooterArea.SetActive(false);
            }
            if (BuyController.charSelected == "tank")
            {
                GameObject newTower = Instantiate(tankPrefab, transform.position, Quaternion.identity);
                Debug.Log("Colocou o tank");
                BuyController.isBuying = false;
                GameController.coins = GameController.coins - 70;
            }
        }
    }
}
