//===========================================================================================================
//Config File Start
var _ISTOSHOWALERT = true;
var _DROPDOWNHEIGHT = 200;
var _DOMAINDIVID = "divDomain";
var _LOADERDIVID = "divLoader";
var _POPUPLOADERDIVID = "divPopupLoader";
var _MESSAGEDIVID = "divMessage";
var _POPUPMESSAGEDIVID = "divPopupMessage";
var _RESULTDIVID = "divResult";
var MESSAGES = {
    AddSuccessMessage: "SuccessFully Added",
    AddFailMessage: "Failed To Add Please Try Again Later",
    UpdateSuccessMessage: "SuccessFully Updated",
    UpdateFailMessage: "Failed To Update Please Try Again Later",
    UniversalSuccessMessage: "Successfully Done",
    UniversalFailMessage: "SomeThing Goes Wrong Please Try Again Later",
};
//Config File End
//===========================================================================================================

//===========================================================================================================
//Start Common Functions


function MyAlert(msg) {
    try {
        if (_ISTOSHOWALERT) { alert(msg); }
    }
    catch (e) { }
}

//Get WebSite Url.
function GetDomain(domaindivid) {
    try {
        return $("#" + domaindivid).html();
    }
    catch (e) { MyAlert("GetDomain" + e); }
}

//Display Loader.
function DisplayLoader(loderdivId) {
    try { $("#" + loderdivId).show(); }
    catch (e) { MyAlert("DisplayLoader" + e); }
}

//Hide Loader.
function HideLoader(loderdivId) {
    try { $("#" + loderdivId).hide(); }
    catch (e) { MyAlert("HideLoader" + e); }
}

var Validate = {
    StringValueValidate: function validate(id, messagedivid, errormessage) {
        var value = $("#" + id).val();
        var div = "#" + messagedivid;
        if (value == "" || value == null) {
            $(div).html(errormessage);
            $(div).show();
            return false;
        }
        else {
            return true;
        }
    },

    StringHtmlValidate: function validate(id, messagedivid, errormessage) {
        var value = $("#" + id).html();
        var div = "#" + messagedivid;
        if (value == "" || value == null) {
            $(div).html(errormessage);
            $(div).show();
            return false;
        }
        else {
            return true;
        }
    },

    IntValueValidate: function validate(id, messagedivid, errormessage) {
        var value = $("#" + id).val();
        var div = "#" + messagedivid;
        if (value <= 0) {
            $(div).html(errormessage);
            $(div).show();
            return false;
        }
        else {
            return true;
        }
    },

    IntHtmlValidate: function validate(id, messagedivid, errormessage) {
        var value = $("#" + id).val();
        var div = "#" + messagedivid;
        if (value <= 0) {
            $(div).html(errormessage);
            $(div).show();
            return false;
        }
        else {
            return true;
        }
    }
}

// Send Ajax Request.
function SendAjaxRequest(url, messageDivId, btnId, successmsg, failmsg) {
    $("#" + btnId).prop("disabled", true);
    $.ajax({
        method: "POST",
        url: url,
        success: function (data) {
            $("#" + btnId).prop("disabled", false);
            switch (data.code) {
                case 0:
                    $("#" + messageDivId).html(successmsg);
                    $("#" + messageDivId).show();
                    $("#" + btnId).prop("disabled", true);
                    break;
                case -1:
                    $("#" + messageDivId).html(failmsg);
                    $("#" + messageDivId).show();
                    break;
                case -2:
                    $("#" + messageDivId).html(failmsg);
                    $("#" + messageDivId).show();
                    break;
                case 3:
                    $("#" + messageDivId).html(failmsg);
                    $("#" + messageDivId).show();
                    break;
            }
        }
    });
}

//Fill Model View.
function FillViewInModelDiv(url, modelDivId) {
    try {
        SetHtmlBlank(modelDivId);
        $.ajax({
            method: "POST",
            url: url,
            success: function (data) {
                switch (data.code) {
                    case 0:
                        SetHtml(modelDivId, data.result);
                        //$("#" + modelDivId).html(data.result);
                        //$("#" + modelDivId).show();
                        break;
                    case -1:
                        SetHtml(modelDivId, data.result);
                        //$("#" + modelDivId).html(data.result);
                        //$("#" + modelDivId).show();
                        break;
                    case -2:
                        SetHtml(modelDivId, data.result);
                        //$("#" + modelDivId).html(data.result);
                        //$("#" + modelDivId).show();
                        break;
                    case 3:
                        SetHtml(modelDivId, data.result);
                        //$("#" + modelDivId).html(data.result);
                        //$("#" + modelDivId).show();
                        break;
                }
            }
        });
    }
    catch (e) { MyAlert("FillViewInModel : " + e); }
}

//Email format is ok.
function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

//Show Success Result.
function FillSuccessResultMSG(data, messagedivId, successmsg, failmsg) {
    try {
        switch (data.code) {
            case 0:
                SetHtml(messagedivId, successmsg);
                break;
            case -1:
                SetHtml(messagedivId, failmsg);
                break;
            case -2:
                SetHtml(messagedivId, failmsg);
                break;
            case -3:
                SetHtml(messagedivId, failmsg);
                break;
        }
    }
    catch (e) { MyAlert("SuccessResult : " + e); }
}

//Fill Success Result View.
function FillSuccessResultView(data, resultDiv) {
    try {
        switch (data.code) {
            case 0:
                SetHtml(resultDiv, data.result);
                break;
            case -1:
                SetHtml(resultDiv, data.result);
                break;
            case -2:
                SetHtml(resultDiv, data.result);
                break;
        }
    }
    catch (e) { MyAlert("SuccessResult : " + e); }
}

// Show Message.
function SetHtml(messagedivId, message) {
    try {
        SetHtmlBlank(messagedivId);
        $("#" + messagedivId).html(message);
        $("#" + messagedivId).show();
    }
    catch (e) { MyAlert("SetHtml : " + e); }
}

// Return Number
function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}

//On Move To Next
function movetoNext(current, nextFiledId) {
    try {

        if (current.value.length == 1) {
            document.getElementById(nextFiledId).focus();
        }
        else {
            document.getElementById(nextFiledId).focus();
        }
    }
    catch (e) {
        MyAlert("movetoNext :" + e);
        return false;
    }
}

//Disable Button.
function Disablebutton(btnId) {
    try {
        $("#" + btnId).prop("disabled", true);
    } catch (e) {
        MyAlert("Disablebutton" + e);
    }
}

//Enable Button.
function Enablebutton(btnId) {
    try {
        $("#" + btnId).prop("disabled", true);
    } catch (e) {
        MyAlert("Enablebutton" + e);
    }
}

//Get Value.
function GetValue(divId) {
    try {
        return $("#" + divId).val();
    } catch (e) {
        MyAlert("GetValue : " + e);
    }
}

//Get HTML.
function GetHtml(divId) {
    try {
        return $("#" + divId).html();
    } catch (e) {
        MyAlert("GetHtml : " + e);
    }
}

//set Value Blank.
function SetValueBlank(divId) {
    try {
        $("#" + divId).val("");
    } catch (e) {
        MyAlert("SetValueBlank : " + e);
    }
}

//set HTML Blank.
function SetHtmlBlank(divId) {
    try {
        $("#" + divId).html("");
    } catch (e) {
        MyAlert("SetHtmlBlank : " + e);
    }
}

// End Common Function;

//==============================================================================================================

function OnAddClassBegin() {
    try {
        if (Validate.StringValueValidate("txtClassName", _MESSAGEDIVID, "Please Enter Class Name")) { }
        else {
            return false;
        }
        DisplayLoader(_LOADERDIVID);
    }
    catch (e) { MyAlert("OnAddClassBegin" + e); }
}

function OnAddClassSuccess(data) {
    try {
        HideLoader(_LOADERDIVID);
        FillSuccessResultMSG(data, _MESSAGEDIVID, MESSAGES.AddSuccessMessage, MESSAGES.AddFailMessage);
    }
    catch (e) { MyAlert("OnAddClassSuccess" + e); }
}

function OnSeachClassByAdvanceSearchBegin() {
    try {
        SetHtmlBlank("divMessage");
        SetHtmlBlank("divResult");
        var classId = GetValue("txtClassId");
        var classname = GetValue("txtClassName");
        if (classId == "" && classname == "") {
            SetHtml("divMessage", "Please Enter Value in above box.")
            return false;
        }
        DisplayLoader("divLoader");

    } catch (e) {
        MyAlert("OnSeachClassByAdvanceSearchBegin : " + e);
    }
}

function OnSeachClassByAdvanceSearchSuccess(data) {
    HideLoader("divLoader");
    FillSuccessResultView(data, "divResult");
}

function OnClassAdvanceSeachIndexReady() {
    SetValueBlank("txtClassId");
}

function ResetEntries() {
    SetValueBlank("txtClassId");
    SetValueBlank("txtClassName");
    SetHtmlBlank("divResult");
    SetHtmlBlank("divMessage");
}

function EditClassPopup(id) {
    try {
        var url = GetDomain("divDomain") + "AjaxRequest/EditClassPopup?id=" + id;
        FillViewInModelDiv(url, "myModal");
    }
    catch (e) {
        MyAlert("EditClassPopup" + e);
    }
}

function OnEditClassBegin() {
    if (Validate.StringValueValidate("txtClassNameP", _POPUPMESSAGEDIVID, "Please Enter Class Name")) { }
    else {
        return false;
    }
    DisplayLoader("divPopupLoader");
}

function OnEditClassSuccess(data) {
    HideLoader("divPopupLoader");
    FillSuccessResultMSG(data, _POPUPMESSAGEDIVID, "Updated Successfully", "Failed To Update Try Again Later");
}

function UpdateStatusPoup(id, counter) {
    var tdid = "tdIsActive" + counter;
    var cIsActive = GetHtml(tdid);
    var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/StatusUpdateAlert?id=" + id + "&cIsActive=" + cIsActive;
    FillViewInModelDiv(url, "myModal");
}

function OnStatusUpdateBegin() {
    DisplayLoader(_POPUPLOADERDIVID);
}

function OnStatusUpdateSuccess(data) {
    HideLoader(_POPUPLOADERDIVID);
    FillSuccessResultMSG(data, _POPUPMESSAGEDIVID, MESSAGES.UpdateSuccessMessage, MESSAGES.UpdateFailMessage);
}

function OnAddAdmissionTypeBegin() {
    try {
        if (Validate.StringValueValidate("txtAdmissionTypeName", _MESSAGEDIVID, "Please Enter Admission Type Name")) { }
        else {
            return false;
        }
        DisplayLoader(_LOADERDIVID);
    }
    catch (e) { MyAlert("OnAddAdmissionTypeBegin" + e); }
}

function OnAddAdmissionTypeSuccess(data) {
    try {
        HideLoader(_LOADERDIVID);
        FillSuccessResultMSG(data, _MESSAGEDIVID, MESSAGES.AddSuccessMessage, MESSAGES.AddFailMessage);
    }
    catch (e) { MyAlert("OnAddAdmissionTypeSuccess" + e); }
}

function EditAdmissionTypePopup(id) {
    try {
        var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/EditAdmissionTypePopup?id=" + id;
        FillViewInModelDiv(url, "myModal");
    }
    catch (e) {
        MyAlert("EditAdmissionTypePopup" + e);
    }
}

function OnEditAdmissionTypeBegin() {
    try {
        if (Validate.StringValueValidate("txtAdmissionTypeNameP", _POPUPMESSAGEDIVID, "Please Enter Admission Type Name")) { }
        else {
            return false;
        }
        DisplayLoader(_POPUPLOADERDIVID);
    }
    catch (e) {
        MyAlert("OnEditAdmissionTypeBegin : " + e);
    }
}

function OnEditAdmissionTypeSuccess(data) {
    try {
        HideLoader("divPopupLoader");
        FillSuccessResultMSG(data, _POPUPMESSAGEDIVID, "Updated Successfully", "Failed To Update Try Again Later");
    }
    catch (e) {
        MyAlert("OnEditAdmissionTypeSuccess : " + e);
    }
}

function UpdateAdmissionTypeStatusPoup(id, counter) {
    var tdid = "tdIsActive" + counter;
    var cIsActive = GetHtml(tdid);
    var url = GetDomain(_DOMAINDIVID) + "AjaxRequest/AdmissionTypeStatusUpdateAlert?id=" + id + "&cIsActive=" + cIsActive;
    FillViewInModelDiv(url, "myModal");
}

function OnAdmissionTypeStatusUpdateBegin() {
    DisplayLoader(_POPUPLOADERDIVID);
}

function OnAdmissionTypeStatusUpdateSuccess(data) {
    HideLoader(_POPUPLOADERDIVID);
    FillSuccessResultMSG(data, _POPUPMESSAGEDIVID, MESSAGES.UpdateSuccessMessage, MESSAGES.UpdateFailMessage);
}

function OnSeachAdmissionTypeByAdvanceSearchBegin() {
    try {
        SetHtmlBlank(_MESSAGEDIVID);
        SetHtmlBlank(_RESULTDIVID);
        var admissionTypeId = GetValue("txtAdmissionTypeId");
        var admissionTypename = GetValue("txtAdmissionTypeName");
        if (admissionTypeId == "" && admissionTypename == "") {
            SetHtml(_MESSAGEDIVID, "Please Enter Value in above box.")
            return false;
        }
        DisplayLoader(_LOADERDIVID);

    } catch (e) {
        MyAlert("OnSeachAdmissionTypeByAdvanceSearchBegin : " + e);
    }
}

function OnSeachAdmissionTypeByAdvanceSearchSuccess(data) {
    HideLoader(_LOADERDIVID);
    FillSuccessResultView(data, _RESULTDIVID);
}

function OnAdmissionTypeAdvanceSeachIndexReady() {
    SetValueBlank("txtAdmissionTypeId");
}