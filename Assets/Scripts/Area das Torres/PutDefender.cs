using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutDefender : MonoBehaviour
{
    public GameObject shooterPrefab;
    public GameObject magePrefab;
    public GameObject tankPrefab;
    private bool hasGameobjg = false;

    void OnMouseDown()
    {
        if (BuyController.isBuying == true)
        {
            if (BuyController.charSelected == "shooter")
            {
                if (hasGameobjg)
                {
                    Debug.Log("Já tem um shooter aqui");
                    return;
                }else
                {
                    GameObject newTower = Instantiate(shooterPrefab, transform.position, Quaternion.identity);
                    hasGameobjg = true;
                    Debug.Log("Colocou o shooter");
                    BuyController.isBuying = false;
                    GameController.coins = GameController.coins - 30;
                    //BuyController.shooterArea.SetActive(false);
                }
            }
            if (BuyController.charSelected == "mage")
            {   
                if (hasGameobjg)
                {
                    Debug.Log("Já tem um mage aqui");
                    return;
                }else 
                {
                    GameObject newTower = Instantiate(magePrefab, transform.position, Quaternion.identity);
                    hasGameobjg = true;
                    Debug.Log("Colocou o mage");
                    BuyController.isBuying = false;
                    GameController.coins = GameController.coins - 50;
                    //BuyController.shooterArea.SetActive(false);
                }
            }
            if (BuyController.charSelected == "tank")
            {
                if (hasGameobjg)
                {
                    Debug.Log("Já tem um tank aqui");
                    return;
                }else
                {
                    GameObject newTower = Instantiate(tankPrefab, transform.position, Quaternion.identity);
                    hasGameobjg = true;
                    Debug.Log("Colocou o tank");
                    BuyController.isBuying = false;
                    GameController.coins = GameController.coins - 70;
                    //BuyController.shooterArea.SetActive(false);
                }
            }
        }
    }
}
