using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebGLSendTransactionExample : MonoBehaviour
{
    public GameObject network_panel;
    public GameObject error_panel;
    public GameObject button_bet;
    async public void OnSendTransaction()
    {
        if(Web3GL.Network() != 97){
            network_panel.SetActive(true);
            return;
        }
        // smart contract method to call
        string method = "addTotal";
        // abi in json format
        string abi = "[{\"inputs\":[{\"internalType\":\"uint8\",\"name\":\"_myArg\",\"type\":\"uint8\"}],\"name\":\"addTotal\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"myTotal\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"name\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"uint8\",\"name\":\"_myArg\",\"type\":\"uint8\"}],\"name\":\"reward\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[],\"name\":\"symbol\",\"outputs\":[{\"internalType\":\"string\",\"name\":\"\",\"type\":\"string\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]";
        // address of contract
        string contract = "0xF40dc5Eb1c66Ce3465Ac677787cA80F0EbfC6beF";
        // array of arguments for contract
        string args = "[\"1\"]";
        // value in wei
        string value = "0";
        // gas limit OPTIONAL
        string gasLimit = "";
        // gas price OPTIONAL
        string gasPrice = "";
        // connects to user's browser wallet (metamask) to update contract state
        try {
            string response = await Web3GL.SendContract(method, abi, contract, args, value, gasLimit, gasPrice);
            button_bet.SetActive(false);
            Debug.Log(response);
        } catch (Exception e) {
            error_panel.SetActive(true);
            Debug.LogException(e, this);
        }
        // // account to send to
        // string to = "0xF81E4C9bE33F9925d7D04cd25cC84DbE79F8B8a6";
        // // amount in wei to send
        // string value = "12300000000000000";
        // // gas limit OPTIONAL
        // string gasLimit = "";
        // // gas price OPTIONAL
        // string gasPrice = "";
        // // connects to user's browser wallet (metamask) to send a transaction
        // try {
        //     string response = await Web3GL.SendTransaction(to, value, gasLimit, gasPrice);
        //     Debug.Log(response);
        // } catch (Exception e) {
        //     Debug.LogException(e, this);
        // }
    }
}
