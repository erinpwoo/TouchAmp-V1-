﻿

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityOSC;
    
    public class OSCController : MonoBehaviour
    {
        
        public string serverId = "MaxMSP";
        public string serverIp = "127.0.0.1";
        public int serverPort = 7400;
        // Use this for initialization
        void Start()
        {
            OSCHandler.Instance.Init(this.serverId, this.serverIp, this.serverPort);
        }

        public KeyCode debugKey = KeyCode.S;
        public string debugMessage = "/sample";


    //Presets updating based on collision with colored buttons
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Button")
        {
            string buttonTag = collision.gameObject.name;
            int preset;
            switch(buttonTag)
            {
                case "Orange Button":
                    preset = 1;
                    break;
                case "Green Button":
                    preset = 2;
                    break;
                case "Red Button":
                    preset = 3;
                    break;
                case "Yellow Button":
                    preset = 4;
                    break;
                case "Light Blue Button":
                    preset = 5;
                    break;
                case "Grey Button":
                    preset = 6;
                    break;
                case "Pink Button":
                    preset = 7;
                    break;
                case "Blue Button":
                    preset = 8;
                    break;
                case "Purple Button":
                    preset = 9;
                    break;
                default: //default preset: 36
                    preset = 36;
                    break;
            }
            OSCHandler.Instance.SendMessageToClient(this.serverId, this.debugMessage, preset);
        }
    }

    void Update()
        {
            if (Input.GetKeyDown(this.debugKey))
            {
                OSCHandler.Instance.SendMessageToClient(this.serverId, this.debugMessage,34); //to change preset number, timeSinceLevelLoad
            }
        }
    }

