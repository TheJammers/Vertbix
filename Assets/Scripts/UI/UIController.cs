using System;
using System.Collections.Generic;
using HyperCasual.Data;
using HyperCasual.Extensions;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] public Dialog TowerShop;
    private class DialogData
    {
        public Dialog dialog;
        public EventHandler<ValueArgs<object>> onClose;
        public EventHandler<ValueArgs<object>> onUpdate;

        public DialogData(Dialog dialog, EventHandler<ValueArgs<object>> onUpdate, EventHandler<ValueArgs<object>> onClose)
        {
            this.dialog = dialog;
            this.onUpdate = onUpdate;
            this.onClose = onClose;
        }
    }

    private Stack<DialogData> dialogStack;
    [SerializeField] private Dialog MainUiDialog;
    
    [SerializeField] private Transform dialogContainer;

    private DialogData currentDialog;

    public bool IsDialogOpen //The main menu is treated as a dialog
    {
        get { return dialogStack.Count > 1; }
    }

    private void Start()
    {
        dialogStack = new Stack<DialogData>();
        PushDialog(MainUiDialog, null, null, null);
    }
    public void PushDialog(Dialog dialog, object[] args, EventHandler<ValueArgs<object>> onUpdate, EventHandler<ValueArgs<object>> onClose)
    {
        if (dialog != null)
        {
            if (currentDialog != null)
            {
                currentDialog.dialog.Hide();
                dialogStack.Push(currentDialog);
            }

            var dialogObject = Instantiate(dialog, dialogContainer);
            dialogObject.gameObject.SetActive(false);
            currentDialog = new DialogData(dialogObject, onUpdate, onClose);
            dialogObject.ShowDialog(DialogUpdate, DialogClosed, args);
        }
        else
        {
            Debug.LogError("Dialog is null");
        }
    }

    private void DialogUpdate(object sender, ValueArgs<object> e)
    {
        this.Raise(currentDialog.onUpdate, e);
    }
    
    private void DialogClosed(object sender, ValueArgs<object> e)
    {
        this.Raise(currentDialog.onClose, e);
        Destroy(currentDialog.dialog.gameObject);
                
        if (dialogStack.Count > 0)
        {
            currentDialog = dialogStack.Pop();
            currentDialog.dialog.Show();
        }
    }
    
}