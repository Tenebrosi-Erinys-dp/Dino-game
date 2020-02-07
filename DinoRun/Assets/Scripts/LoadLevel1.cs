using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadLevel1 : MonoBehaviour
{
    public Button b;
    // Start is called before the first frame update
    void Start()
    {
        Button but = b.GetComponent<Button>();
        but.onClick.AddListener(ResetCall);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ResetCall()
    {
        SceneManager.LoadScene("Level1");
    }
}
