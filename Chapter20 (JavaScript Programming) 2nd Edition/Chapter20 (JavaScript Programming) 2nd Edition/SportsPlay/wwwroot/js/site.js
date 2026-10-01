function ValidateRange(strValue, strErrorMessage, decMinimum, decMaximum) {

    //trim cuts white space charcters at the end of the string
    strValue = strValue.trim();
    //makes sure it isn't empty
    if (strValue != "") {
        //checks if the value is a number and is within the range
        if (!isNaN(strValue) && strValue >= decMinimum && strValue <= decMaximum) {
            return "";
        }
        else {
            var strMessage = strErrorMessage + "\n";
            return strMessage;
        }
    }
    else {
        return "";
    }

}
