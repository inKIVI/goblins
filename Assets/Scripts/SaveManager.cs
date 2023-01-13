using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Kilosoft.Tools;
public class SaveManager : MonoBehaviour
{
    
    [ContextMenu(itemName: "DeleteSave")]
    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene(0);
    }

    [EditorButton("DeleteSave")]
    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();

       
    }
}
