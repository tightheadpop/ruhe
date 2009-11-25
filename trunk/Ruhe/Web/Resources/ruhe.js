if (![].some)
Array.prototype.some = function(callback, thisObject) {
	for (var i = 0; i < this.length; i++)
		if (!!callback.apply(thisObject || {}, [this[i]]))
			return true;
	return false;
};
if (![].contains)
Array.prototype.contains = function(item) {
	return this.some(function(each) { return each == item; });
};
function Ruhe_IsDefined(object) {
	return typeof object !== 'undefined';
};

function Ruhe_HasValue(value) {
	return Ruhe_IsDefined(value) && value !== null;
};

function Ruhe_CreateFunction(value) {
	if(Ruhe_HasValue(value)) {
		if(value.constructor === Function)
			return value;
		else
			return new Function(value);
	} else {
		return function() {};
	}
};

function Ruhe_GetProperty(element, propertyName) {
	var returnValue = element[propertyName];
	if(!Ruhe_IsDefined(returnValue) && element.getAttribute)
		returnValue = element.getAttribute(propertyName);

	if(Ruhe_HasValue(returnValue) && returnValue.startsWith && returnValue.startsWith('@'))
		returnValue = Ruhe_CreateFunction("return (" + returnValue.replace(/^@/, '') + ")").apply(element, []);
		
	if (Ruhe_HasValue(returnValue) && returnValue.constructor === Function)
		returnValue = returnValue.apply(element, [element]);

	return returnValue;
};

function Ruhe_PropertyOn(/* attribute list */) {
	var isOn, attribute, length = arguments.length;
	for(var i=0;i<length;i++){
		attribute = arguments[i];
		if(typeof attribute=='string')
			attribute = attribute.toLowerCase();
		isOn = Ruhe_HasValue(attribute) &&
			   attribute!='false' &&
			   attribute!='off' &&
			   attribute!='no' &&
		       attribute!=false &&
		       attribute!='';
		if(isOn) break;
	}
	return !!isOn;
};

function Ruhe_EvaluateInputDateIsValid(validator) {
    var control = $get(validator.controltovalidate);
    var value = ValidatorGetValue(validator.controltovalidate);
    if (!value)
        return true;
    return Ruhe_GetDate(value, control.datePattern) != null;
};

function Ruhe_GetDate(input, format) {
    try {
        return Date.parseLocale(input, format);
    } catch (e) {
        return null;
    }
};

function Ruhe_EvaluateInputDateRangeIsValid(validator) {
    var toDate = $get(validator.controltovalidate);
    var fromDate = $get(toDate.id.replace(/_to$/, "_from"));
    if (!toDate.value && !fromDate.value)
        return true;
    var to = Ruhe_GetDate(toDate.value, toDate.datePattern);
    var from = Ruhe_GetDate(fromDate.value, fromDate.datePattern);
    return to == null || from == null || from <= to;
};

function Ruhe_OrGroupValidatorEvaluateIsValid(validator) {
    var controlList = validator.grouptovalidate.split(',');
    for (i = 0; i < controlList.length; i++) {
		if (!!ValidatorGetValue(controlList[i]))
		    return true;
	}
    return false;
};

function Ruhe_KeyPressFilter(regex) {
    if (regex == null)
        return function(){};
    return function(oEvent) {
	    var keyEnter = 13, keyNewLine = 10, keyTab = 9, keyBackspace = 8, keyNull = 0, keyDelete = 0, keyEscape = 27;
	    this.FILTER = regex;
	    var filter = Ruhe_GetProperty(this, 'FILTER');
	    if (Ruhe_PropertyOn(filter)){
		    if (filter.constructor !== RegExp)
			    filter = new RegExp(filter);
		    oEvent = oEvent || window.event;
    		
		    var keyCode = keyNull;
		    if (Ruhe_HasValue(oEvent.charCode))
			    keyCode = oEvent.charCode;
		    else
			    keyCode = oEvent.keyCode;

		    if(![keyNull, keyTab, keyEnter, keyNewLine, keyBackspace, keyDelete, keyEscape].contains(keyCode)
				    && !filter.test(String.fromCharCode(keyCode)))
			    return false;
	    }
	    return true;
	};
};

$(function(){
    $('.integer').live('keypress', Ruhe_KeyPressFilter(Ruhe$INTEGER));
    $('.integer.positive').live('keypress', Ruhe_KeyPressFilter(Ruhe$POSITIVE_INTEGER));
});

/* keystroke filters */
var Ruhe$POSITIVE_INTEGER = /\d/;
var Ruhe$INTEGER = 	function(){
    if (document.selection) {
        var currentRange = document.selection.createRange();
        var wholeRange = this.createTextRange();
        if (currentRange.compareEndPoints('StartToStart', wholeRange) > 0)
            return /[\d]/;
    }
    return /[\d-]/;
};
var Ruhe$NUMBER = function(){
    if (document.selection) {
        var currentRange = document.selection.createRange();
        var wholeRange = this.createTextRange();
        if (currentRange.compareEndPoints('StartToStart', wholeRange) < 1)
            return /[\d\.\-]/;
    }
    if(this.value.indexOf('.') >= 0)
        return /[\d]/;
    return /[\d\.]/;
};
var Ruhe$POSITIVE_NUMBER = function(){
    if(this.value.indexOf('.') >= 0)
        return /[\d]/;
    return /[\d.]/;
};
var Ruhe$DATE = null;