mergeInto(LibraryManager.library, {
    focusHandleAction: function(_identifier, _x, _y, _height, _width){
        //if(UnityLoader.SystemInfo.mobile == true){
            var div = document.createElement("input");
            div.style.top = Pointer_stringify(_y);
            div.style.left = Pointer_stringify(_x);
            div.style.height = Pointer_stringify(_height);
            div.style.width = Pointer_stringify(_width);
            div.style.position = "absolute";
            div.style.background = "red";
            div.style.opacity = "0.5";
            div.onclick = function(){
                div.focus();
            }
            document.body.appendChild(div);
            div.oninput = function(){
                console.log(_identifier + Pointer_stringify(_identifier));
                //SendMessage(Pointer_stringify(_name), 'ReceiveInputData', div.value);
                SendMessage('Manager', 'ReceiveInputDataWebGL', _identifier + div.value);
            }
        //}
    },
    createRect: function(_name, _x, _y, _height, _width){
        var gameObjectName = _name;
        var div = document.createElement("input");
        div.style.top = Pointer_stringify(_y);
        div.style.left = Pointer_stringify(_x);
        div.style.height = Pointer_stringify(_height);
        div.style.width = Pointer_stringify(_width);
        div.style.position = "absolute";
        div.style.background = "red";
        div.style.opacity = "0.5";
        div.onclick = function(){
            div.focus();
        }
        div.oninput = function(){
            console.log(gameObjectName + Pointer_stringify(gameObjectName));
            SendMessage(Pointer_stringify(gameObjectName), 'ReceiveInputData', div.value);
        }
        document.body.appendChild(div);
    },
});