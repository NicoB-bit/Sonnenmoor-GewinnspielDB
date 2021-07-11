mergeInto(LibraryManager.library, {
    focusHandleAction: function(_name, _str, _inputValue){
        if(UnityLoader.SystemInfo.mobile == true){
            var _inputTextData = prompt(Pointer_stringify(_inputValue), Pointer_stringify(_str));
            if (_inputTextData == null || _inputTextData == "") {
                //canceled text
            } else {
                //send data to unity
                SendMessage(Pointer_stringify(_name), 'ReceiveInputData', _inputTextData);
            }  
        }
    },
    createRect: function(x, y, height, width, _nameGO){
        var div = document.createElement("input");
        div.style.top = Pointer_stringify(y);
        div.style.left = Pointer_stringify(x);
        div.style.height = Pointer_stringify(height);
        div.style.width = Pointer_stringify(width);
        div.style.position = "absolute";
        div.style.background = "red";
        div.onclick = function(){
            div.focus();
        }
        div.onchange = function(){
                SendMessage(Pointer_stringify(_name), 'ReceiveInputData', div.value);
        }
        document.body.appendChild(div);
    },
});