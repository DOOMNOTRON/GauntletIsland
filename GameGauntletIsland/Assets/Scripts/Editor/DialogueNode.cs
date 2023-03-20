using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

// Unique ID to distiguish the nodes from each other
public class DialogueNode : Node
{
    public string GUID;

    public string DialogueText;
    // The start point
    public bool EntryPoint = false;
}
