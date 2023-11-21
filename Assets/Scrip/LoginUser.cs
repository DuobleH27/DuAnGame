using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginUser : MonoBehaviour
{
    public TMP_InputField edtUser, edtPass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckLogin()
    {
        var user = edtUser.text;
        var pass = edtPass.text;

        //goi AP!
    }
}
