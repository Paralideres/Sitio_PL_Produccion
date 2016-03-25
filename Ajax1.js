var whitespace = ' \t\n\r';

var frmForumValidator = { forum_name: [true, 0, false, false, false], forum_desc: [true, 255], employee_id: [true], division_id_check: [true], division_id_radio: [true], posts: [true, 0, true, false, false], last_post: [true, 0, false, false, true] };

N = (document.all) ? 0 : 1;

var ob;

var over = false;

var rated = false;

var webpath = '/';

if (N) {

    document.captureEvents(Event.MOUSEDOWN | Event.MOUSEMOVE | Event.MOUSEUP);

}

document.onmousedown = MD;

document.onmousemove = MM;

document.onmouseup = MU;

function MD(e) {

    if (over) {

        if (N) {

            ob = document.getElementById("divPanel");

            X = e.layerX;

            Y = e.layerY;

            return false;

        }

        else {

            ob = document.getElementById("divPanel");

            ob = ob.style;

            X = event.offsetX;

            Y = event.offsetY;

        }

    }

}



function MM(e) {

    if (ob) {

        if (N) {

            ob.style.top = e.pageY - Y;

            ob.style.left = e.pageX - X;

        }

        else {

            ob.pixelLeft = event.clientX - X + document.body.scrollLeft;

            ob.pixelTop = event.clientY - Y + document.body.scrollTop;

            return false;

        }

    }

}

function MU() {

    ob = null;
}

//MENU FUNCTIONS
function expand(s, strColor) {

    var d;

    s.style.backgroundColor = strColor;

    //var objFld = document.getElementById(strFldName);

    d = s.getElementsByTagName("div").item(0);

    d.className = "menuHover";

}

function collapse(s, strColor) {

    var d;

    s.style.backgroundColor = strColor;

    d = s.getElementsByTagName("div").item(0);

    d.className = "menuNormal";

    //callingElement.style.visibility = 'hidden';

}


function changeColor(s, strColor) {

    s.style.backgroundColor = strColor;

}



function TextBoxValidation(objFld, isRequired, intMinLen, forceNumeric, forceEmail, isDate) {

    //var frmForumValidator = {forum_name: [true,0,false,false,false],forum_desc: [true,255],employee_id: [true],division_id: [true],posts: [true,0,true,false,false],last_post: [true,0,false,false,true]};

    ClearError(divFrmErrors);

    var blFoundErrors = false;

    objFld.className = 'frmInput';

    //var lbl = eval('lbl' + objFld.name);

    //lbl.className = 'frmError';

    if (isDate && isRequired) {

        if ((objFld.value == "") || (objFld.value == "N/A")) {

            alert('This field is required.  Please enter a valid date for this field.');
            blFoundErrors = true;
            objFld.className = 'frmError';
        }
    }

    else {

        if (isRequired && ((objFld.value == "") || (objFld.value == " "))) {

            alert('This field is required.  Please enter a value for this field.');
            blFoundErrors = true;
            objFld.focus();
            objFld.className = 'frmError';
        }

        else if ((GetFieldLength(objFld) < intMinLen) && (intMinLen > 0)) {

            alert('Please enter a value that is at least ' + intMinLen + ' characters long.');
            blFoundErrors = true;
            objFld.focus();
            objFld.className = 'frmError';
        }

        else if ((isNaN(objFld.value)) && (forceNumeric)) {

            alert('Please enter a numeric value.  Do not use $ or commas.');
            blFoundErrors = true;
            objFld.focus();
            objFld.className = 'frmError';
        }

        else if ((!isEmail(objFld)) && (forceEmail)) {

            alert('Please enter a valid email address.');
            blFoundErrors = true;
            objFld.focus();
            objFld.className = 'frmError';
        }
    }

    return blFoundErrors;

} // end TextBoxValidation function

function TextAreaValidation(objFld, isRequired, intMaxLen) {

    ClearError(divFrmErrors);

    var blFoundErrors = false;

    objFld.className = 'frmInput';

    if (isRequired && (GetFieldLength(objFld) == 0)) {

        alert('This field is required.  Please enter a value for this field.');
        blFoundErrors = true;
        objFld.focus();
        objFld.className = 'frmError';

    }

    else if ((GetFieldLength(objFld) > intMaxLen)) {

        alert('This field only accepts a maximun of ' + intMaxLen + ' characters and you entered ' + GetFieldLength(objFld) + ' characters.');
        blFoundErrors = true;
        objFld.focus();
        objFld.className = 'frmError';

    }

    return blFoundErrors;

} // end TextAreaValidation function

function DropDownListValidation(objFld, isRequired) {

    ClearError(divFrmErrors);

    var blFoundErrors = false;

    objFld.className = 'frmSelect';

    if (isRequired && (objFld.value == "0")) {

        alert('This field is required.  Please select another value for this field.');
        blFoundErrors = true;
        objFld.focus();
        objFld.className = 'frmSelectError';
    }

    return blFoundErrors;

} // end DropDownListValidation function

function CheckBoxValidation(strFrmName, objFld, isRequired) {

    var blFoundErrors = false;

    eval('document.' + strFrmName + '.fldSt' + objFld.name + '.className = "frmLabel"');

    if (isRequired) {

        if (!isBoxChecked(strFrmName, objFld.name)) {

            blFoundErrors = true;

        }

    } //if (isRequired){

    if (blFoundErrors) {

        eval('document.' + strFrmName + '.fldSt' + objFld.name + '.className = "frmError"');

        alert('This field is required.  Please check at least one value for this field.');

    }

    else {

        eval('document.' + strFrmName + '.fldSt' + objFld.name + '.className = "frmLabel"');

    }

    return blFoundErrors;

} // end CheckBoxValidation function

function isBoxChecked(strFrmName, strFldName) {

    var ischecked = false;
    var num_of_items = 0;

    num_of_items = eval('document.' + strFrmName + '.' + strFldName + '.length');

    if (isNaN(num_of_items)) {

        num_of_items = 1;

    }


    if (num_of_items == 1) {

        if (eval('document.' + strFrmName + '.' + strFldName + '.checked') == true) {

            ischecked = true;

        }
    }

    else {

        for (i = 0; i < num_of_items; i++) {

            if (eval('document.' + strFrmName + '.' + strFldName + '[i].checked') == true) {

                ischecked = true;
            }

        }

    }

    return ischecked;

} //isBoxChecked


function RadioButtonValidation(strFrmName, objFld, isRequired) {

    var blFoundErrors = false;

    eval('document.' + strFrmName + '.fldSt' + objFld.name + '.className = "frmLabel"');

    if (isRequired) {

        if (!isRadioChecked(strFrmName, objFld.name)) {

            blFoundErrors = true;

        }

    } //if (isRequired){

    if (blFoundErrors) {

        eval('document.' + strFrmName + '.fldSt' + objFld.name + '.className = "frmError"');

        alert('This field is required.  Please check at least one value for this field.');

    }

    else {

        eval('document.' + strFrmName + '.fldSt' + objFld.name + '.className = "frmLabel"');

    }

    return blFoundErrors;

} // end CheckBoxValidation function


function isRadioChecked(strFrmName, strFldName) {

    var ischecked = false;
    var num_of_items = 1;

    num_of_items = eval('document.' + strFrmName + '.' + strFldName + '.length');

    if (isNaN(num_of_items)) {

        num_of_items = 1;
    }

    if (num_of_items == 1) {

        if (eval('document.' + strFrmName + '.' + strFldName + '.checked') == true) {

            ischecked = true;

        }
    }

    else {

        for (i = 0; i < num_of_items; i++) {

            if (eval('document.' + strFrmName + '.' + strFldName + '[i].checked') == true) {

                ischecked = true;

            }
        } //for
    } //else

    return ischecked;

} //function RadioCheck(ps_fld){



function calendario(fecha) {
    var param = "strFecha=" + fecha.value;
    if (fecha.value == '') {
        param = "strFecha=" + "0";
    }

    Objeto = showModalDialog("./frameCalendario.aspx?" + param, null, "scroll:No;status:no;center:yes;help:no;minimize:no;maximize:no;border:no;statusbar:no;dialogWidth:240px;dialogHeight:270px");
    if (Objeto) {
        //var f = new Date();
        //f = Objeto;
        //var ano = f.getFullYear();
        //var mes = f.getMonth();
        //var dia = f.getDate();

        //alert("fecha: " + dia + "/" + (mes + 1) + "/" + ano);
        //fecha.value = (dia + "/" + (mes +1) + "/" + ano);
        fecha.value = Objeto;
    }
    return false;
}

function OpenCalendar(fieldName, selectedDate, dateOptions, allowOnly) {

    var mURL = '/calendar.aspx?FormFieldName=' + fieldName + '&SelectedDate=' + selectedDate + '&dateOption=' + dateOptions + '&allowOnly=' + allowOnly;

    var str = 'height=300,innerHeight=300,width=300,innerWidth=300;'

    if (window.screen) {

        var ah = screen.availHeight - 30;
        var aw = screen.availWidth - 10;
        var xc = (aw - 160) / 2;
        var yc = (ah - 160) / 2;

        str += 'left=' + xc + ', screenX =' + xc + ',top=' + yc + ', screenY=' + yc;

    }

    newWin = window.open(mURL, 'calendar', str);

    newWin.focus();

} // end OpenCalendar function


function OpenColorPicker(fieldName, selectedColor) {

    var mURL = '/colorpicker.aspx?FormFieldName=' + fieldName + '&SelectedColor=' + selectedColor;

    var str = 'height=400,innerHeight=400,width=400,innerWidth=400;'

    if (window.screen) {

        var ah = screen.availHeight - 30;
        var aw = screen.availWidth - 10;
        var xc = (aw - 380) / 2;
        var yc = (ah - 380) / 2;
        str += 'left=' + xc + ', screenX =' + xc + ',top=' + yc + ', screenY=' + yc;
    }

    newWin = window.open(mURL, 'colorpicker', str);

    newWin.focus();

} // end OpenColorPicker function


function SubmitOnEnter(objForm) {

    if (event.keyCode == 13) {

        SendData(objButton, strFormName, strURL);

    }
}


function displayError(sField, sErrMsg, iLen) {

    var itop;
    var ileft;
    var size;
    var sName;
    var oItem;

    divFrmErrors.innerText = '';
    iLen = iLen * 6;
    oItem = sField;

    if (typeof (oItem) != 'object') {

        return;

    }

    itop = 0;
    ileft = 0;
    itop = oItem.offsetHeight;

    while (oItem.tagName != "BODY") {

        itop += oItem.offsetTop;
        ileft += oItem.offsetLeft;
        oItem = oItem.offsetParent;

    }

    divFrmErrors.style.left = ileft + "px";
    divFrmErrors.style.top = itop + "px";
    divFrmErrors.style.width = iLen + "pt";

    var innerText = document.createTextNode(sErrMsg);

    divFrmErrors.appendChild(innerText);

    divFrmErrors.style.visibility = 'visible';

}

function growDiv(intMaxWidth, intMaxHeight) {


    //document.getElementById('divAjaxContent').style.border-color = '#D09000';
    document.getElementById('divAjaxContent').style.border = '#D09000 1px solid';
    //document.getElementById('divAjaxContent').style.border-style = 'solid';


    //alert('growDiv was called');

    var intHeight = 0;
    var intWidth = 0;
    var growMore = false;

    intHeight = document.getElementById('divAjaxContent').offsetHeight;
    intWidth = document.getElementById('divAjaxContent').offsetWidth;

    if (intHeight < intMaxHeight) {

        intHeight = intHeight + 5;

        document.getElementById('divAjaxContent').style.height = intHeight + 'px';

        growMore = true;

    }


    if (intWidth < intMaxWidth) {

        intWidth = intWidth + 5;

        document.getElementById('divAjaxContent').style.width = intWidth + 'px';

        growMore = true;

    }

    if (growMore) {

        x = window.setTimeout('growDiv(' + intMaxWidth + ',' + intMaxHeight + ')', 0);

    }

}

function ShowAjaxContent(strURL, intWidth, intHeight, objLink) {

    var itop;
    var ileft;
    var oItem;

    oItem = objLink;

    if (typeof (oItem) != 'object') {

        return;

    }

    itop = 0;
    ileft = 0;
    itop = oItem.offsetHeight;

    while (oItem.tagName != "BODY") {

        itop += oItem.offsetTop;
        ileft += oItem.offsetLeft;
        oItem = oItem.offsetParent;

    }

    //itop = itop + 5;
    //ileft = ileft + 5;

    document.getElementById('divPanel').style.left = ileft + "px";
    document.getElementById('divPanel').style.top = itop + "px";

    document.getElementById('divAjaxContent').innerHTML = '<img src=/images/ajaxred.gif>Cargando...';
    document.getElementById('divPanel').style.visibility = 'visible';
    document.getElementById('divAjaxContent').style.visibility = 'visible';

    //growDiv(intWidth, intHeight);

    //document.getElementById('divPanel').style.width  =  intWidth + 'px';
    //document.getElementById('divPanel').style.height  = '100%';

    //document.getElementById('divAjaxContent').style.width  = intWidth + 'px';
    //document.getElementById('divAjaxContent').style.height  = '100%';

    CreateXMLHTTP();

    // If browser supports XMLHTTPRequest object
    if (XMLHTTP) {
        //Initializes the request object with GET (METHOD of posting), 
        //Request URL and sets the request as asynchronous.
        XMLHTTP.onreadystatechange = DisplayChangeAjaxContent;
        XMLHTTP.open("GET", strURL, true);
        //Sends the request to server
        XMLHTTP.send(null);
    }
}

function DisplayChangeAjaxContent() {

    // if XMLHTTP shows "loaded"
    if (XMLHTTP.readyState == 4) {

        // if "OK"

        if (XMLHTTP.status == 200) {

            //var returnedVal = XMLHTTP.responseText;

            document.getElementById('divAjaxContent').innerHTML = XMLHTTP.responseText;

        }

        else {

            alert("Problem retrieving XML data:\n" + XMLHTTP.statusText);

        }
    } //if (XMLHTTP.readyState == 4){

} //function DisplayChange{


function ClearAjaxContent() {

    //try{

    //document.getElementById('divPanel').removeChild(document.getElementById('divPanel').childNodes[0]);
    //document.getElementById('divAjaxContent').removeChild(document.getElementById('divAjaxContent').childNodes[0]);
    //}

    //catch(err){
    //}

    document.getElementById('divPanel').style.width = '1px';
    document.getElementById('divPanel').style.height = '1px';
    document.getElementById('divPanel').style.visibility = 'hidden';

    document.getElementById('divAjaxContent').style.width = '1px';
    document.getElementById('divAjaxContent').style.height = '1px';
    document.getElementById('divAjaxContent').style.visibility = 'hidden';


} //end Clear Error function



function ClearError(callingElement) {

    try {

        callingElement.removeChild(callingElement.childNodes[0]);

    }

    catch (err) {

    }

    callingElement.style.visibility = 'hidden';

} //end Clear Error function

function ClearDate(callingElement) {

    callingElement.value = 'N/A';
}


function GetFieldLength(callingElement) {

    var mLength = 0;
    var mContent = callingElement.value;

    mLength = mContent.length;

    return mLength;
}

function isEmpty(s) {

    return ((s == null) || (s.length == 0));

}


function isWhitespace(s) {

    var i;

    if (isEmpty(s)) return true;

    for (i = 0; i < s.length; i++) {

        var c = s.charAt(i);

        if (whitespace.indexOf(c) == -1) return false;

    }

    return true;
}


function isEmail(s) {

    if (isWhitespace(s)) return false;

    var i = 1;
    var sLength = s.length;

    while ((i < sLength) && (s.charAt(i) != '@')) {

        i++

    }

    if ((i >= sLength) || (s.charAt(i) != '@')) return false;

    else i += 2;

    while ((i < sLength) && (s.charAt(i) != '.')) {

        i++

    }

    if ((i >= sLength - 1) || (s.charAt(i) != '.')) return false;

    else return true;

}

function InStr(String1, String2) {

    var a = 0;

    if (String1 == null || String2 == null)

        return 0;

    else {
        String1 = String1.toLowerCase();
        String2 = String2.toLowerCase();
        a = String1.indexOf(String2);

        if (a == -1)

            return 0;

        else

            return a + 1;
    }
}


function HasNumberAndChar(s) {

    var has1Num = 0;
    var has1Char = 0;

    for (i = 0; i <= 9; i++) {

        if (s.match(i)) {

            has1Num++;
        }

        else {

            if (isNaN(s))

                has1Char++;

        }
    }

    if (has1Num > 0 && has1Char > 0)

        return true;

    else

        return false;

}

function PostRating(intArticle, intRaing, objLink) {

    if (!rated) {

        rated = true;

        //alert(webpath + 'post_rating.aspx?stars=' + intRaing + '&article_id=' + intArticle + '&format=print&close=y');

        ShowAjaxContent(webpath + 'post_rating.aspx?stars=' + intRaing + '&article_id=' + intArticle + '&format=print&close=y', 530, 200, objLink);

    }

}

function RateArticle(intrating) {

    var pic_on_path = webpath + 'images/stars/star_on.gif';
    var pic_off_path = webpath + 'images/stars/star_off.gif';

    if (!rated) {

        for (i = 1; i < 6; i++) {

            if (intrating > i) {

                eval('document.star' + i + '.src=\'' + pic_on_path + '\'');

            }

            else if (intrating == i) {

                eval('document.star' + i + '.src=\'' + pic_on_path + '\'');

                document.getElementById("rating").innerHTML = eval('document.star' + i + '.title');
            }

            else {

                eval('document.star' + i + '.src=\'' + pic_off_path + '\'');

            }

        }

    }

    else {

        document.getElementById("rating").innerHTML = "Tu voto ha sido registrado";

    }

}

//Creating and setting the instance of appropriate XMLHTTP Request object to a XmlHttp variable
function CreateXMLHTTP() {

    try {

        XMLHTTP = new ActiveXObject("Msxml2.XMLHTTP");

    }
    catch (e) {

        try {

            XMLHTTP = new ActiveXObject("Microsoft.XMLHTTP");

        }

        catch (oc) {

            XMLHTTP = null;

        }
    }

    //Creating object in Mozilla and Safari 
    if (!XMLHTTP && (typeof (XMLHttpRequest) != "undefined")) {

        XMLHTTP = new XMLHttpRequest();
    }
}


function DisplayChange() {

    // if XMLHTTP shows "loaded"
    if (XMLHTTP.readyState == 4) {

        // if "OK"

        if (XMLHTTP.status == 200) {

            //var returnedVal = XMLHTTP.responseText;

            document.getElementById('AjaxContent').innerHTML = XMLHTTP.responseText;

        }

        else {

            alert("Problem retrieving XML data:\n" + XMLHTTP.statusText);

        }
    } //if (XMLHTTP.readyState == 4){

} //function DisplayChange{



function DisplayChangeCalendar() {

    // if XMLHTTP shows "loaded"
    if (XMLHTTP.readyState == 4) {

        // if "OK"

        if (XMLHTTP.status == 200) {

            //var returnedVal = XMLHTTP.responseText;

            document.getElementById('AjaxCalendarContent').innerHTML = XMLHTTP.responseText;

        }

        else {

            alert("Problem retrieving XML data:\n" + XMLHTTP.statusText);

        }
    } //if (XMLHTTP.readyState == 4){

} //function DisplayChange{


function Edit(intID, strURL, strParameter) {

    // construct the URL 
    strURL = strURL + strParameter + '=' + intID;

    CreateXMLHTTP();

    // If browser supports XMLHTTPRequest object
    if (XMLHTTP) {

        //Initializes the request object with GET (METHOD of posting), 
        //Request URL and sets the request as asynchronous.
        XMLHTTP.onreadystatechange = DisplayChange;
        XMLHTTP.open("GET", strURL, true);
        //Sends the request to server
        XMLHTTP.send(null);

    }

}

function ShowList(intIndex, strURL) {

    // construct the URL 
    strURL = strURL + 'index=' + intIndex;
    CreateXMLHTTP();
    // If browser supports XMLHTTPRequest object
    if (XMLHTTP) {
        //Initializes the request object with GET (METHOD of posting), 
        //Request URL and sets the request as asynchronous.
        XMLHTTP.onreadystatechange = DisplayChange;
        XMLHTTP.open("GET", strURL, true);
        //Sends the request to server
        XMLHTTP.send(null);
    }
}

function ShowCalendar(fieldName, selectedDate, dateOptions, allowOnly) {

    var strURL = '/calendar.aspx?FormFieldName=' + fieldName + '&SelectedDate=' + selectedDate + '&dateOption=' + dateOptions + '&allowOnly=' + allowOnly;

    CreateXMLHTTP();

    // If browser supports XMLHTTPRequest object
    if (XMLHTTP) {
        //Initializes the request object with GET (METHOD of posting), 
        //Request URL and sets the request as asynchronous.
        XMLHTTP.onreadystatechange = DisplayChangeCalendar;
        XMLHTTP.open("GET", strURL, true);
        //Sends the request to server
        XMLHTTP.send(null);
    }
}


function Delete(intID, strURL, strParameter) {

    var confirmResponse = false;

    confirmResponse = confirm('Warning! \n \n Are you sure you want to delete this record?');

    if (confirmResponse) {

        // construct the URL 
        strURL = strURL + strParameter + '=' + intID;
        CreateXMLHTTP();
        // If browser supports XMLHTTPRequest object
        if (XMLHTTP) {
            //Initializes the request object with GET (METHOD of posting), 
            //Request URL and sets the request as asynchronous.
            XMLHTTP.onreadystatechange = DisplayChange;
            XMLHTTP.open("GET", strURL, true);
            //Sends the request to server
            XMLHTTP.send(null);
        }
    }
}

function CheckForErrors(strFormName, objGlobalVar) {

    var blFoundErrors = false;
    var objFrm = document.forms[strFormName];
    var objFld;
    var objValidator;
    var strCurrentFld = '';

    for (i = 0; i < objFrm.elements.length; i++) {

        objFld = objFrm.elements[i];

        //alert(objFld.name + ' - ' + objFld.type + ': ' + objFld.value);

        switch (objFld.type) {

            case 'textarea':

                if (!blFoundErrors) {

                    objValidator = objGlobalVar[objFld.name];

                    if (TextAreaValidation(objFld, objValidator[0], objValidator[1])) {

                        blFoundErrors = true;

                    }
                }

                break;

            case 'text':

                if (!blFoundErrors) {

                    objValidator = objGlobalVar[objFld.name];

                    if (TextBoxValidation(objFld, objValidator[0], objValidator[1], objValidator[2], objValidator[3], objValidator[4])) {

                        blFoundErrors = true;

                    }
                }

                break;

            case 'select-one':

                if (!blFoundErrors) {

                    objValidator = objGlobalVar[objFld.name];

                    if (DropDownListValidation(objFld, objValidator[0])) {

                        blFoundErrors = true;

                    }
                }

                break;


            case 'checkbox':

                if (strCurrentFld != objFld.name) {

                    if (!blFoundErrors) {

                        objValidator = objGlobalVar[objFld.name];

                        if (CheckBoxValidation(strFormName, objFld, objValidator[0])) {

                            blFoundErrors = true;

                        }
                    } //if (!blFoundErrors) {

                } //if (strCurrentFld != objFld.name){

                break;

            /*	
            case 'radio':
						
				if (strCurrentFld != objFld.name){
		
					if (!blFoundErrors) {
					
						objValidator = objGlobalVar[objFld.name];
						
						if(RadioButtonValidation(strFormName, objFld, objValidator[0])){
						
							blFoundErrors = true;
							
						}
            }//if (!blFoundErrors) {
								
				}//if (strCurrentFld != objFld.name){
			
				break;
            */ 

        } //end switch


        if (strCurrentFld != objFld.name) {

            strCurrentFld = objFld.name;

        }


    } //end for

    return blFoundErrors;
}


function SendData(objButton, strFormName, strURL) {

    var objGlobal;
    var blObjectFound = true;

    try {

        eval(strFormName + 'Validator');

    }

    catch (caca) {

        blObjectFound = false;

    }

    if (!blObjectFound) {

        alert('Object to validate the form is missing and the form cannot be submitted.  Please contact support.');

    }

    else {

        objGlobal = eval(strFormName + 'Validator');

        if (CheckForErrors(strFormName, objGlobal)) {

            //Errors were found, do nothing
        }

        else {

            var strSubmit = '';
            var objFrm = document.forms[strFormName];
            var objFld;

            for (i = 0; i < objFrm.elements.length; i++) {

                objFld = objFrm.elements[i];

                objFld.disabled = false;

                alert(objFld.name + ' - ' + objFld.type + ': ' + objFld.value);

                switch (objFld.type) {

                    case 'checkbox':

                        if (objFld.checked) {

                            strSubmit += objFld.name + '=' + escape(objFld.value);

                            if (i < objFrm.elements.length - 1) {

                                strSubmit += '&';

                            } //end if

                        } //end if

                        break;

                    default:

                        strSubmit += objFld.name + '=' + escape(objFld.value);

                        if (i < objFrm.elements.length - 1) {

                            strSubmit += '&';

                        } //end if

                } //end switch			

            } //end for

            objButton.value = "Please Wait...";
            objButton.disabled = true;

            if (document.getElementById("AjaxContent") != null) {

                CreateXMLHTTP();

                // If browser supports XMLHTTPRequest object
                if (XMLHTTP) {

                    //Initializes the request object with GET (METHOD of posting), 
                    //Request URL and sets the request as asynchronous.
                    XMLHTTP.onreadystatechange = DisplayChange;
                    XMLHTTP.open("POST", strURL, true);
                    XMLHTTP.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');

                    //Sends the request to server
                    XMLHTTP.send(strSubmit);

                    //alert(strSubmit);

                } //end if

            } //end if

            else {

                objFrm.submit();

            } //end else

        } //end else

    } //end else for if typeof(eval(	

} //end function

