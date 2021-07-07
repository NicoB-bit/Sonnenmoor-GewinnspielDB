mergeInto(LibraryManager.library, {
    focusHandleAction: function(_name, _str, _inputValue){
        //if(UnityLoader.SystemInfo.mobile == true){
        var _inputTextData = prompt(Pointer_stringify(_inputValue), Pointer_stringify(_str));
        if (_inputTextData == null || _inputTextData == "") {
            //canceled text
        } else {
            //send data to unity
            SendMessage(Pointer_stringify(_name), 'ReceiveInputData', _inputTextData);
        }  
        //}
    },
    createRect: function(x, y, height, width){
        var div = document.createElement("div");
        div.style.top = x;
        div.style.left = y;
        div.style.height = height;
        div.style.width = width;
        div.color = "white";
        div.background = "red";
    },
});