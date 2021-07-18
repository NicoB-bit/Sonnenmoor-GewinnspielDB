mergeInto(LibraryManager.library, {
    focusHandleAction: function(_name, _x, _y, _height, _width){
        //if(UnityLoader.SystemInfo.mobile == true){
            var name = Pointer_stringify(_name);
            var div = document.createElement("input");
            div.style.top = Pointer_stringify(_y);
            div.style.left = Pointer_stringify(_x);
            div.style.height = Pointer_stringify(_height);
            div.style.width = Pointer_stringify(_width);
            div.style.position = "absolute";
            div.style.background = "red";
            div.style.opacity = "0.5";
            div.style.color = "rgba(0, 0, 0, 0)";
            div.className = "InputFields";
            div.onclick = function(){
                div.focus();
                div.value = "";
                SendMessage("Manager", 'ReceiveInputDataWebGL', name + " ");
            }
            div.oninput = function(){
                var message = name + div.value;
                SendMessage("Manager", 'ReceiveInputDataWebGL', message);
            }
            div.onfocusin = function(){
                console.log("inFocus");
                SendMessage("Manager", 'ReceiveInputDataWebGL', "3" + name);
            }
            div.onfocusout = function(){
                console.log("outOfFocus");
                SendMessage("Manager", 'ReceiveInputDataWebGL', "4" + name);
            }
            document.body.appendChild(div);
        //}
    },
    DestroyDivs: function(){
        var elems = document.getElementsByClassName('InputFields');
        for (var i = 0; i < elems.length; i++) {
            elems[i].remove();           
        }
    },
});