using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITEST : MonoBehaviour
{
    public Image prefab;
    [SerializeField] Image uiScene;
    public Transform canvas;
    void Start()
    {
        uiScene = Instantiate(prefab, canvas).GetComponent<Image>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    uiScene.transform.position = Camera.main.WorldToScreenPoint(transform.position);

    //}
    private void LateUpdate()
    {
        uiScene.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnBecameVisible()
    {
        //Debug.Log("+++++++++++++++++");
        //uiScene.gameObject.SetActive(true);
    }

    private void OnBecameInvisible()
    {
        //Debug.Log("___________");
        //uiScene.gameObject.SetActive(false);
    }
}
