mergeInto(LibraryManager.library, {
    focusHandleAction: function(_name, _str, _inputValue){
        if(UnityLoader.SystemInfo.mobile == true){
            var _inputTextData = prompt(_inputValue, Pointer_stringify(_str));
            if (_inputTextData == null || _inputTextData == "") {
                //canceled text
            } else {
                //send data to unity
                SendMessage(Pointer_stringify(_name), 'ReceiveInputData', _inputTextData);
            }  
        }
    },
});