using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveStuff : MonoBehaviour
{
    public GameObject CubeBehaviour;
    private CubeBehaviour CubeBehaviourScript;

    public InputField inputTextFriction;
    public InputField inputTextGravity;
    public InputField inputTextmass_c;
    public InputField inputTextmass_b;
    float FrictionTx;
    float GravityTx;
    float mass_cTx;
    float mass_bTx;

    void Start()
    {
        FrictionTx = PlayerPrefs.GetFloat("Friction");
        inputTextFriction.text = FrictionTx.ToString();

        GravityTx = PlayerPrefs.GetFloat("Gravity");
        inputTextGravity.text = GravityTx.ToString();

        mass_cTx = PlayerPrefs.GetFloat("mass_c");
        inputTextmass_c.text = mass_cTx.ToString();

        mass_bTx = PlayerPrefs.GetFloat("mass_b");
        inputTextmass_b.text = mass_bTx.ToString();
    }
    public void SaveThis()
    {
        FrictionTx = float.Parse(inputTextFriction.text);
        PlayerPrefs.SetFloat("Friction", FrictionTx);
        
        GravityTx = float.Parse(inputTextGravity.text);
        PlayerPrefs.SetFloat("Gravity", GravityTx);

        mass_cTx = float.Parse(inputTextmass_c.text);
        PlayerPrefs.SetFloat("mass_c", mass_cTx);

        mass_bTx = float.Parse(inputTextmass_b.text);
        PlayerPrefs.SetFloat("mass_b", mass_bTx);
    }



}
