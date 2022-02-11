
var errorMessage = "";
function validateTextbox(id, name)
{
    var elem = Ext.getDom(id);
    if(elem.value.length==0)
    {
        errorMessage += String.format("- {0} field must be filled.\n",name);
        return false;
    }
    return true;
}

function validateCombo(id, name)
{
    var elem = Ext.getDom(id);
    if (elem.options[elem.selectedIndex].value==0)
    {
        errorMessage += String.format("- {0} field selection is invalid.\n", name);
        return false;
    }
    return true;
}

function addInstance(id,max)
{
    var countField = Ext.getDom(id+'_count');
    var currentCount = parseInt(countField.value);
    if(currentCount<max)
    {
        //Duplicate Field
        var firstInstance = Ext.getDom(id+'_1');
        var newItem = '<tr>' + firstInstance.innerHTML + '</tr>';
        
        //remove unnecesary fields
        //var re = new RegExp("\<input type=\"hidden\"[^\>]+_fields[^\>]+\>", "g");
        var re = new RegExp("\<input[^\>]+_fields[^\>]+\>", "g");
        newItem = newItem.replace(re,'');
        Ext.DomHelper.insertAfter(firstInstance.parentNode,newItem);

        //Update count field
        countField.value = currentCount+1;
    }
    

}

function onCheckboxChanged(clickedChkBox)
{
    //Get Previous Element, it has to be a HiddenInput
    var chk = Ext.get(clickedChkBox);
    var chkStatus = Ext.getDom(chk.prev());
    
    if(chkStatus.value == 'true')
        chkStatus.value = 'false';
    else
        chkStatus.value = 'true';
}