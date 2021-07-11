mergeInto(LibraryManager.library, {
    createRect: function(x, y, height, width, _name){
        var div = document.createElement("input");
        div.style.top = Pointer_stringify(y);
        div.style.left = Pointer_stringify(x);
        div.style.height = Pointer_stringify(height);
        div.style.width = Pointer_stringify(width);
        div.style.position = "absolute";
        div.style.background = "red";
        div.style.opacity = "0.5";
        div.onclick = function(){
            div.focus();
        }
        div.oninput = function(){
            console.log(_name + Pointer_stringify(_name));
            SendMessage(_name, 'ReceiveInputData', div.value);
        }
        document.body.appendChild(div);
    },
});