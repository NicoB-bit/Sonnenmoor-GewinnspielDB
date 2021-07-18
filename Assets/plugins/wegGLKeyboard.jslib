﻿mergeInto(LibraryManager.library, {
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
            div.id = name + "InputFields";
            div.onclick = function(){
                div.focus();
                div.value = "";
                SendMessage("Manager", 'ReceiveInputDataWebGL', name + " ");
                SendMessage("Manager", 'ReceiveInputDataWebGL', "3" + name);
            }
            div.oninput = function(){
                var message = name + div.value;
                SendMessage("Manager", 'ReceiveInputDataWebGL', message);
            }
            div.onblur = function(){
                console.log("outOfFocus");
                SendMessage("Manager", 'ReceiveInputDataWebGL', "4" + name);
            }
            document.body.appendChild(div);
        //}
    },
    DestroyDivs: function(){
        var elem1 = document.getElementById('0InputFields');
        var elem2 = document.getElementById('1InputFields');
        var elem3 = document.getElementById('2InputFields');
        console.log(elem1 + elem2 + elem3);
        elem1.remove();
        elem2.remove();
        elem3.remove();
    },
});