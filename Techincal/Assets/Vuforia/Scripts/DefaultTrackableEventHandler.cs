/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using System.Collections.Generic;
namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;
    
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS

        //
        public GameObject m_ground;
        public GameObject m_objTemplete;
        public GameObject m_warmingScreen;

        private void OnTrackingFound()
        {
            if (!CoregameController.Instance.m_isplaying)
            {
                CoregameController.Instance.m_isplaying = true;
            }

            SpawnManager.Instance.m_canSpawn = true;
            //Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            //Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            //// Enable rendering:
            //foreach (Renderer component in rendererComponents)
            //{
            //    component.enabled = true;
            //}

            //// Enable colliders:
            //foreach (Collider component in colliderComponents)
            //{
            //    component.enabled = true;
            //}
            CoregameController.Instance.StartUpdateTimer();
            SpawnManager.Instance.ResumeWhenTrackingLost();
            SpawnManager.Instance.StartSpawnAll();
            if(m_ground)
            {
                m_ground.SetActive(true);
            }
            if(m_objTemplete)
            {
                m_objTemplete.SetActive(true);
            }
            if(m_warmingScreen)
            {
                m_warmingScreen.SetActive(false);
            }
            //CoregameController.Instance.Showtemplete3DByLevel();
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }


        private void OnTrackingLost()
        {
            if (CoregameController.Instance.m_isplaying)
            {
                CoregameController.Instance.m_isplaying = false;
                SpawnManager.Instance.m_canSpawn = false;
            }
            //Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            //Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            //// Disable rendering:
            //foreach (Renderer component in rendererComponents)
            //{
            //    component.enabled = false;
            //}

            //// Disable colliders:
            //foreach (Collider component in colliderComponents)
            //{
            //    component.enabled = false;
            //}
            if (m_ground)
            {
                m_ground.SetActive(false);
            }
            if (m_objTemplete)
            {
                m_objTemplete.SetActive(false);
            }
            if (m_warmingScreen)
            {
                m_warmingScreen.SetActive(true);
            }
            SpawnManager.Instance.StoptSpawnAll();
            SpawnManager.Instance.PauseWhenTrackingLost();
            CoregameController.Instance.StopUpdateTimer();
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }

        #endregion // PRIVATE_METHODS
    }
}
