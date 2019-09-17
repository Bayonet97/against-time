using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogueState
{
    Disabled,
    Typing,
    Displayed
}

public class CharacterDialogue : MonoBehaviour
{
    public delegate void DialogueStateChanged(DialogueState state);
    public static event DialogueStateChanged OnDialogueStateChanged;
    public string DialogueText { get; private set; }
    private DialogueState _dialogueState = DialogueState.Disabled;

    private void Start()
    {

        OpenDialogue("Walk around with the WASD buttons. Press 'E' to interact with objects, multiple interactions can be possible. Fix the bridge before the timer runs out. The timer pauses when the dialogue box is open.");
    }
    public void OpenDialogue(string dialogue)
    {
        DialogueText = dialogue;
        gameObject.GetComponent<Character>().ChangePausedState(true);
        ChangeDialogueState(DialogueState.Typing);
    }
    public void NextDialogue()
    {
        ChangeDialogueState(DialogueState.Typing);
    }

    public void DoneTyping()
    {
        // Instantly show all text call to view
        ChangeDialogueState(DialogueState.Displayed);
    }

    public void CloseDialogue()
    {
        gameObject.GetComponent<Character>().ChangePausedState(false);
        ChangeDialogueState(DialogueState.Disabled);
    }

    private void ChangeDialogueState(DialogueState state)
    {
        _dialogueState = state;
        OnDialogueStateChanged(state);
    }

    public DialogueState GetDialogueState()
    {
        return _dialogueState;
    }

    internal void NextState()
    {
        if(_dialogueState == DialogueState.Disabled)
        {
            return;
        }
        else if(_dialogueState == DialogueState.Typing)
        {
            DoneTyping();
        }
        else if(_dialogueState == DialogueState.Displayed)
        {
            CloseDialogue();
        }
    }
}
