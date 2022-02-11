/// <reference path="ext-base.js" />
/// <reference path="ext-all.js" />
var Xcel = {
                Utils: {    
                            BaseUri:"http://localhost/POS", 
                            GetAbsoluteUri:function(relativePath) {return this.BaseUri + relativePath;}
                        }
             };


//CONFIGURATION INFORMATION
var uiForTemplate = false;
var recipeTemplateCombo;
var formBuilder = 
{
    lastFieldId: 0,
    divs: {
                fieldsContainerId: 'div#fields',
                getFieldId: function(id){return 'div#field_' + id},
                fieldNameId: 'div#fieldName'
          },
    html: {
            field: '<div id="field_{0}" class="{6}" ><table cellspacing="3"><tr><td>{1}</td><td>{2}</td><td>{3}</td><td><div id="nestedForm_div_{0}"><input type="hidden" id="nestedForm_{0}" name="nestedForm" value=""/></div><div id="options_div_{0}"><input type="hidden" id="options_{0}" name="options" value=""/></div><div id="defaultValues_div_{0}"><input type="hidden" id="defaultValue_{0}" name="defaultValue" value=""/></div></td><td>{4}</td><td>{5}</td><td><img src="' + Xcel.Utils.GetAbsoluteUri('/res/ext/img/default/dd/drop-no.gif') + '" onclick="removeField({0});"/></td></tr></table></div>',
            fieldIdInput: 'ID <input type="text" size="10" id="id_{0}" name="FieldID" value="{1}"/>',
            fieldNameInput: 'Name <input type="text" size="10" id="name_{0}" name="FieldName" value="{1}"/>',
            fieldTypeCombo:'Type <select id="type_{0}" name="Type" onchange="fieldTypeChanged({0},this);"><option value="Text">Text</option><option value="DropDown">Drop Down List</option><option value="Check">Checkbox</option><option value="NestedForm">Nested Form</option></select>',
            nestedFormSelect:'<div id="nestedForm_div_{0}"> Select <select id="nestedForm_{0}" name="nestedForm"><option value="0">[Embbeded Forms]</option></select></div>',
            nestedFormHidden:'<div id="nestedForm_div_{0}"><input type="hidden" id="nestedForm_{0}" name="nestedForm" value=""/></div>',
            selectOption: '<option {0} value="{1}">{2}</option>',
            isMandatoryCheck:'Validation <select id="isMandatory_{0}" name="isMandatory"><option value="true">Mandatory</option><option value="false">Optional</option></select>',
            maxLengthInput:'Max Length <input type="text" size="4" id="maxLength_{0}" name="maxLength" value="{1}"/>',
            optionsText:'<div id="options_div_{0}"> Options <input type="text" id="options_{0}" name="options" value=""/></div>',
            optionsHidden:'<div id="options_div_{0}"><input type="hidden" id="options_{0}" name="options" value=""/></div>',
            defaultValueText:'<div id="defaultValues_div_{0}"> Default Value <input type="text" id="defaultValue_{0}" name="defaultValue" value=""/></div>',
            defaultValueHidden:'<div id="defaultValues_div_{0}"><input type="hidden" id="defaultValue_{0}" name="defaultValue" value=""/></div>'
            }
};

//INITIALIZE FIELDS TOOLBAR
function formBuilder_UI_init()
{
    Ext.onReady(
    function()
    {
        //Create Ingredients Toolbar
        var tb = new Ext.Toolbar();
        tb.render('fieldsToolbar');
        tb.add(
            {
            text: 'Add Field',
            enableToggle: false,
            pressed: false,
            handler: addFieldHandler
            });
    });
}

//HANDLER OF THE ADDNEWRECIPE TOOLBAR BUTTON
function addFieldHandler(item)
{
    //addNewIngredient(null,'', 1.0, false);
    var fieldsContainer = Ext.DomQuery.selectNode(formBuilder.divs.fieldsContainerId);
    
    //Determine what Field Template to use
    var thisHtml = formBuilder.html.field;
    Ext.DomHelper.append(fieldsContainer,
    {
        html:String.format(thisHtml, 
                           formBuilder.lastFieldId,
                           String.format(formBuilder.html.fieldIdInput,formBuilder.lastFieldId,''),
                           String.format(formBuilder.html.fieldNameInput,formBuilder.lastFieldId,''),
                           String.format(formBuilder.html.fieldTypeCombo,formBuilder.lastFieldId),
                           String.format(formBuilder.html.isMandatoryCheck,formBuilder.lastFieldId),
                           String.format(formBuilder.html.maxLengthInput,formBuilder.lastFieldId,'0'),
                           'newField')
    });
    formBuilder.lastFieldId++;
}            

//REMOVES THE SPECIFIED FIELD ROW FROM THE FORM
function removeField(id)
{
    var fieldEl = Ext.DomQuery.selectNode(formBuilder.divs.getFieldId(id));
    if(fieldEl != null) 
       fieldEl.parentNode.removeChild(fieldEl);
}

//FILE TYPE CHANGED EVENT
function fieldTypeChanged(id,elem)
{
    var thisField = Ext.get('nestedForm_div_'+id);
    if(elem.value=='NestedForm')
    {
        thisField.replaceWith({html:String.format(formBuilder.html.nestedFormSelect,id)});
        
        //Load Available Nested Forms
        var nested = Ext.getDom('nestedForm_'+id);
        var options = formOptions.split(',');
        var currentOptions = nested.options;
        for(var i=0;i<options.length;i++)
        {
            var oitem = options[i].split(';');
            nested.options[i] = new Option(oitem[0],oitem[1]);
        }
    }
    else
    {
        thisField.replaceWith({html:String.format(formBuilder.html.nestedFormHidden,id)});
    }
    
    thisField = Ext.get('options_div_'+id);
    if(elem.value=='DropDown')
    {
        thisField.replaceWith({html:String.format(formBuilder.html.optionsText,id)});
    }
    else
    {
        thisField.replaceWith({html:String.format(formBuilder.html.optionsHidden,id)});
    }
    
    thisField = Ext.get('defaultValues_div_'+id);
    if(elem.value=='Check')
    {
        thisField.replaceWith({html:String.format(formBuilder.html.defaultValueText,id)});
    }
    else
    {
        thisField.replaceWith({html:String.format(formBuilder.html.defaultValueHidden,id)});
    }
    
    
}

























//REMOVES ALL INGREDIENT ROWS FROM THE FORM
function removeAllIngredients()
{
    var ingredientsContainer = Ext.DomQuery.selectNode(recipe.divs.ingredientsContainerId);
    var ingredients = ingredientsContainer.childElements();
    for(var i = 0; i<ingredients.length;i++)
    {
        ingredientsContainer.removeChild(ingredients[i]);
    }
    recipe.lastIngredientId = 0;
}

function getRecipeTemplateIngredientHidden(htmlId,id)
{
    return String.format(recipe.html.recipeTemplateIngredient, htmlId, id);
}

//GETS THE HTML FOR THE VOLUME FIELD OF THE INGREDIENT ROW
function getVolumeInput(htmlId, vol)
{
    return String.format(recipe.html.volumeInput, htmlId, vol);
}

//GETS THE HTML FOR THE ISBOTTLE FIELD OF THE INGREDIENT ROW
function getBottleComboBox(htmlId,isBottle)
{
    return String.format(recipe.html.isBottleCombo,
                         htmlId,
                         !isBottle? "selected":"",
                         isBottle? "selected":""
                         );
}

//GETS THE HTML FOR THE BRAND FIELD OF THE INGREDIENT ROW
function getBrandCombo(htmlId, subBeverageType, subBeverageTypeId, selectedId, isFromTemplate)
{
    var ds;
    var getItem = function(index){return ds.item(index);};
    var topName = "-- Select " + subBeverageType + " Brand --> ";
    var sel = String.format(recipe.html.selectOption,selectedId==0 ? "selected":"","0",topName);
    
    if(isFromTemplate==null)
    {
        //Go Back Option
        sel += String.format(recipe.html.selectOption,"",-1,"<-- Change Beverage Type of Ingredient");
    }
    
    
    if(subBeverageTypeId != null) {
        ds = allBrandsDs.query('SubBeverageTypeID',subBeverageTypeId,true,false);
    }
    else {
        ds = allBrandsDs;
        getItem = function(index){return ds.getAt(index);};
    }
    for(var i=0;i<ds.getCount();i++) {
        var curItem = getItem(i);
        sel += String.format(recipe.html.selectOption,selectedId==curItem.BrandID ? "selected":"",curItem.get("BrandID") , curItem.get("Name"));
    }
    return String.format(recipe.html.brandCombo,htmlId,sel,"brandChanged(this)");        
}

function brandChanged(elem)
{
    var brandId = elem.value;
    var text = elem.options[elem.selectedIndex].text;
    var htmlId = elem.id.replace('ingBrandId_','');
    var thisSelect = Ext.DomQuery.selectNode("#"+elem.id);

    if (brandId == -1)
    {
        //Display Sub Beverage Type Selection Again
        var currentBrand = allBrandsDs.getAt(elem.selectedIndex-1);
        var combo = getSubBeverageTypeCombo(htmlId,currentBrand.get('BeverageType'), currentBrand.get('BeverageTypeID'), 0);
        thisSelect.replace(combo);
    }
}

//GETS THE HTML FOR THE BEVERAGE FIELD OF THE INGREDIENT ROW
function getBeverageTypeCombo(htmlId, selectedId)
{
    //Add Header
    var topName = "-- Select Type of Ingredient --> ";
    var sel = String.format(recipe.html.selectOption,selectedId==0 ? "selected":"","0",topName);
    
    for(var i=0;i<allBeverageTypesDs.getCount();i++) {
        var curItem = allBeverageTypesDs.getAt(i);
        sel += String.format(recipe.html.selectOption,selectedId==curItem.BeverageTypeID ? "selected":"",curItem.get("BeverageTypeID") , curItem.get("Name"));
    }
    return String.format(recipe.html.beverageCombo,htmlId,sel,"beverageTypeChanged(this);");        
}

function beverageTypeChanged(elem)
{
    var beverageTypeId = elem.value;
    var text =elem.options[elem.selectedIndex].text;
    var combo = getSubBeverageTypeCombo(elem.id.replace('ingBeverageTypeId_',''),text,elem.value,0);
    
    var thisSelect = Ext.DomQuery.selectNode("#"+elem.id);
    thisSelect.replace(combo);
}

//GETS THE HTML FOR THE SUBBEVERAGE FIELD OF THE INGREDIENT ROW
function getSubBeverageTypeCombo(htmlId,beverageType, beverageTypeId, selectedId)
{
    var ds;
    var getItem = function(index){return ds.item(index);};
    
    //Header
    var topName = "-- Select " + beverageType + " Type --> ";
    var sel = String.format(recipe.html.selectOption,selectedId==0 ? "selected":"","0",topName);
    
    //Go Back Option
    sel += String.format(recipe.html.selectOption,"",-1,"<-- Change Type of Ingredient");

    //Filter by Beverage Type    
    if(beverageTypeId != null) {
        ds = allSubBeverageTypesDs.query('BeverageTypeID',beverageTypeId,true,false);
    }
    else {
        ds = allSubBeverageTypesDs;
        getItem = function(index){return ds.getAt(index);};
    }
    for(var i=0;i<ds.getCount();i++) {
        var curItem = getItem(i);
        sel += String.format(recipe.html.selectOption,selectedId==curItem.SubBeverageTypeID ? "selected":"",curItem.get("SubBeverageTypeID") , curItem.get("Name"));
    }
    return String.format(recipe.html.subBeverageCombo,htmlId,sel,"subBeverageTypeChanged(this)");        
}

function subBeverageTypeChanged(elem)
{
    if (elem.value ==0) return;
    
    var subBeverageTypeId = elem.value;
    var text = elem.options[elem.selectedIndex].text;
    var htmlId = elem.id.replace('ingSubBeverageTypeId_','');
    var thisSelect = Ext.DomQuery.selectNode("#"+elem.id);

    if (subBeverageTypeId == -1)
    {
        //Display Beverage Type Selection Again
        var combo = getBeverageTypeCombo(id,0);
        thisSelect.replace(combo);
    }
    else
    {
        if (uiForTemplate) return;
        thisSelect.replace(getBrandCombo(htmlId, text, subBeverageTypeId, 0));
    }
}

function railChecked(chk, id)
{
    var elem = Ext.getDom('isRail_'+id);
    elem.value = chk.checked;
}