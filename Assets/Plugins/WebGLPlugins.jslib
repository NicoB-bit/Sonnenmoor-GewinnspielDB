mergeInto(LibraryManager.library, {
    focusHandleAction: function(_name, _x, _y, _height, _width){
        var name = Pointer_stringify(_name);
        var div = document.createElement("input");
        div.style.top = Pointer_stringify(_y);
        div.style.left = Pointer_stringify(_x);
        div.style.height = Pointer_stringify(_height);
        div.style.width = Pointer_stringify(_width);
        div.style.position = "absolute";
        div.style.background = "red";
        div.style.opacity = "0";
        div.style.color = "rgba(0, 0, 0, 0)";
        div.id = name + "InputFields";
        div.onclick = function(){
            console.log("focused");
            //div.focus();
            div.value = "";
            SendMessage("Manager", 'ReceiveInputDataWebGL', name + " ");
            //set focus
            SendMessage("Manager", 'ReceiveInputDataWebGL', "3" + name);
        }
        div.oninput = function(){
            var message = name + div.value;
            SendMessage("Manager", 'ReceiveInputDataWebGL', message);
        }
        div.onblur = function(){
            console.log("outOfFocus");
            //unfocus
            SendMessage("Manager", 'ReceiveInputDataWebGL', "4" + name);
        }
        document.body.appendChild(div);
    },
    Debug: function(){
        SendMessage("Manager", 'ReceiveInputDataWebGL', /Android|iPhone|iPad|IEMobile/.test(navigator.userAgent))
    },
    DestroyDivs: function(){
        var elem1 = document.getElementById('0InputFields');
        var elem2 = document.getElementById('1InputFields');
        var elem3 = document.getElementById('2InputFields');
        elem1.remove();
        elem2.remove();
        elem3.remove();
    },
    IsMobile: function (){
        if(/Android|iPhone|iPad|IEMobile/.test(navigator.userAgent))
        {
            return true;
        }
        else
        {
            return false;
        }
    },
});