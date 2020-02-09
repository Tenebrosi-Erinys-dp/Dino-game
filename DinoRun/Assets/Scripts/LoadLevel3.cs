/* LoadLevel2.cs
 * By: Alex Dzius
 * Last Edited: 2/10/2020
 * Description: Code that allows the loading of Level 2, the velociraptor level. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadLevel3 : MonoBehaviour
{
    public Button b;
    // Start is called before the first frame update
    void Start()
    {
        // get the button and add listener to execute function resetcall if button is pressed
        Button but = b.GetComponent<Button>();
        but.onClick.AddListener(ResetCall);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ResetCall()
    {
        // load the velociraptor scene
        SceneManager.LoadScene("Level3");
    }
}
