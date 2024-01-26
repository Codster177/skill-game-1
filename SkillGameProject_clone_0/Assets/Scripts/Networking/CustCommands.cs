using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustCommands
{
    private string fullText;
    private string commandType;
    private string commandPerams;
    private int commandInt = 0;

    public CustCommands(string newFullText)
    {
        fullText = newFullText;
        for(int i = 0; i < fullText.Length; i++)
        {
            if (fullText[i] == ' ')
            {
                Debug.Log("i = " + i);
                Debug.Log("Length = " + fullText.Length);
                commandType = fullText.Substring(0, i);
                Debug.Log("commandType = " + commandType);
                commandPerams = fullText.Substring(i+1);
                Debug.Log("commandPerams = " + commandPerams);
                break;
            }
        }
        checkCommand();
    }
    void checkCommand()
    {
        if (commandType == "/ip")
        {
            Debug.Log("IP COMMAND");
            commandInt = 1;
        }
        else if (commandType == "/testing")
        {
            Debug.Log("TESTING COMMAND");
            commandInt = 2;
        }
        else
        {
            commandInt = 0;
        }
    }

    public int getCommandInt()
    {
        return commandInt;
    }
    public string getCommandPerams()
    {
        return commandPerams;
    }


    public string commandIP()
    {
        int[] pLocations = new int[3];
        int pIndex = 0;
        for (int i = 0; i < commandPerams.Length; i++)
        {
            if (pIndex >= 3)
            {
                break;
            }
            if (commandPerams[i] == '.')
            {
                pLocations[pIndex] = i;
                pIndex++;
            }
        }
        String ipString = 
            "ec2-" + commandPerams.Substring(0, pLocations[0]) +
            "-" + commandPerams.Substring(pLocations[0]+1, ((pLocations[1]-pLocations[0])-1)) +
            "-" + commandPerams.Substring(pLocations[1]+1, ((pLocations[2]-pLocations[1])-1)) +
            "-" + commandPerams.Substring(pLocations[2]+1) +
            ".us-east-2.computer.amazonaws.com";
        Debug.Log(ipString);
        return ipString;
    }
    public bool commandTesting()
    {
        bool testingBool;
        Boolean.TryParse(commandPerams, out testingBool);
        return testingBool;
    }
}
