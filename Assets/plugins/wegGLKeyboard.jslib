mergeInto(LibraryManager.library, {
    createRect: function(_name, _x, _y, _height, _width){
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
            console.log(_name + Pointer_stringify(_name));
            SendMessage(Pointer_stringify(_name), 'ReceiveInputData', div.value);
        }
        document.body.appendChild(div);
    },
});