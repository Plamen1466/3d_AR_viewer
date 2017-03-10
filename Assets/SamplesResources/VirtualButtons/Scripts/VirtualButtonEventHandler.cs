/*============================================================================== 
 * Copyright (c) 2012-2015 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/
using UnityEngine;
using System.Collections.Generic;
using Vuforia;

/// <summary>
/// This class implements the IVirtualButtonEventHandler interface and
/// contains the logic to swap materials for the teapot model depending on what 
/// virtual button has been pressed.
/// </summary>
public class VirtualButtonEventHandler : MonoBehaviour,
                                         IVirtualButtonEventHandler
{
    #region PUBLIC_MEMBERS
    /// <summary>
    /// The materials that will be set for the teapot model
    /// </summary>
    public Material[] m_TeapotMaterials;
    #endregion // PUBLIC_MEMBERS


    #region PRIVATE_MEMBERS
    private bool horizont;
    private bool vertical;
    private GameObject mTeapot;
    private List<Material> mActiveMaterials;

    #endregion // PRIVATE_MEMBERS
    #region MONOBEHAVIOUR_METHODS
    void Start()
    {
        // Register with the virtual buttons TrackableBehaviour
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            vbs[i].RegisterEventHandler(this);
        }

        // Get handle to the teapot object
        mTeapot = transform.FindChild("VirtualButtons_teapot").gameObject;

        // The list of active materials
        mActiveMaterials = new List<Material>();
        horizont = false;
        vertical = false;
    }

    #endregion // MONOBEHAVIOUR_METHODS
    
    void Update() 
    {
        // Rotate the object around its local X axis at 1 degree per second
        if(horizont)
        {
            mTeapot.transform.Rotate(Vector3.right * Time.deltaTime*10);
        }
        if(vertical)
        {
            mTeapot.transform.Rotate(Vector3.up * Time.deltaTime*10, Space.World);
        }
        // ...also rotate around the World's Y axis
    }
    
    #region PUBLIC_METHODS
    /// <summary>
    /// Called when the virtual button has just been pressed:
    /// </summary>
    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        Debug.Log("OnButtonPressed: " + vb.VirtualButtonName);

        if (!IsValid())
        {
            return;
        }

        // Add the material corresponding to this virtual button
        // to the active material list:
        switch (vb.VirtualButtonName)
        {
        case "red":
            if(horizont)
            {
                horizont = false;
            }
            else
            {
                horizont = true;
            }
        //    mTeapot.transform.Rotate(transform.rotation.eulerAngles + new Vector3(0f, 0.1f, 0f));
        //    mActiveMaterials.Add(m_TeapotMaterials[0]);
            //mTeapot.transform.Rotate(new Vector3(0, 0.5f, 0f), Space.World);
            break;

        case "blue":
        if(vertical)
        {
            vertical = false;
        }
        else
        {
            vertical = true;
        }
            
            //mActiveMaterials.Add(m_TeapotMaterials[1]);
            break;

        case "yellow":
            mTeapot.transform.localScale += new Vector3(0.005f, 0.005f, 0.005f);
            //mActiveMaterials.Add(m_TeapotMaterials[2]);
            break;

        case "green_fill":
            mTeapot.GetComponent<Renderer>().material.color = Color.green;
            //mActiveMaterials.Add(m_TeapotMaterials[3]);
            break;

        case "blue_fill":
            mTeapot.GetComponent<Renderer>().material.color = Color.blue;
            break;

        case "red_fill":
            mTeapot.GetComponent<Renderer>().material.color = Color.red;
            break;
        case "black_fill":
            mTeapot.GetComponent<Renderer>().material.color = Color.black;
            break;

        case "white_fill":
            mTeapot.GetComponent<Renderer>().material.color = Color.white;
            break;
        case "green":
             mTeapot.transform.localScale += new Vector3(-0.005f, -0.005f, -0.005f);
            //mTeapot.GetComponent<Renderer>().material.color = Color.red;
            //mActiveMaterials.Add(m_TeapotMaterials[3]);
            break;
        }

        // Apply the new material:
        //if (mActiveMaterials.Count > 0)
        //    mTeapot.GetComponent<Renderer>().material = mActiveMaterials[mActiveMaterials.Count - 1];

    }

    /// <summary>
    /// Called when the virtual button has just been released:
    /// </summary>
    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        if (!IsValid())
        {
            return;
        }

        // Remove the material corresponding to this virtual button
        // from the active material list:
        switch (vb.VirtualButtonName)
        {
        case "red":
            //mActiveMaterials.Remove(m_TeapotMaterials[0]);
            break;

        case "blue":
            //mActiveMaterials.Remove(m_TeapotMaterials[1]);
            break;

        case "yellow":
            //mActiveMaterials.Remove(m_TeapotMaterials[2]);
            break;

        case "green":
            //mActiveMaterials.Remove(m_TeapotMaterials[3]);
            break;
        }

        // Apply the next active material, or apply the default material:
        //if (mActiveMaterials.Count > 0)
        //    mTeapot.GetComponent<Renderer>().material = mActiveMaterials[mActiveMaterials.Count - 1];
        //else
        //    mTeapot.GetComponent<Renderer>().material = m_TeapotMaterials[4];
    }
    #endregion //PUBLIC_METHODS


    #region PRIVATE_METHODS
    private bool IsValid()
    {
        // Check the materials and teapot have been set:
        return m_TeapotMaterials != null &&
            m_TeapotMaterials.Length == 5 &&
            mTeapot != null;
    }
    #endregion //PRIVATE_METHODS
}
