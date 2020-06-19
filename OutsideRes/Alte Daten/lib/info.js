        window.onload = function () {
            var R = Raphael("paper", 1250, 800);
			    var attr = {
                fill: "#707070",
                stroke: "none",
                "stroke-width": 0.0,
                "stroke-linejoin": "round",

            };



var box =  R.rect(12,0,1230,620, 1).attr({"fill": "#000000", "stroke": "#707070", "stroke-width": 1});
box.toBack();



//-------------------------------
var textbox =  R.rect(12,620,1230,70, 1).attr({"fill": "#000", "stroke": "#707070", "stroke-width": 1, "opacity": 1})

//-------------------------------


var infobutton = R.set();
var button3 = R.rect(82,620,70,70, 1).attr({"fill": "#000", "stroke": "#FFFFFF", "stroke-width": 1, "opacity": 1});
infobutton.push(button3);
var info = R.text(115,655, "i").attr({"fill": "#707070", "stroke": "none", "font-size":"45px", "font-family":"Times New Roman"});

//-------------------------------
var backbutton = R.set();
var button = R.rect(12,620,70,70, 1).attr({"fill": "#000000", "stroke": "#707070", "stroke-width": 1, "opacity": 1});
backbutton.push(button);
var home = R.path("M60.578,42.747h-6.491v15.412H43.22V44.31H32.924v13.85H22.68V42.747h-7.682  l22.568-22.79l9.854,9.758v-5.636h5.937v11.515L60.578,42.747z"
).attr({"fill": "#707070", "stroke": "none", "stroke-width": 3, "opacity": 1});
home.translate(9,613);backbutton.push(home);
//-------------------------------




//-------------------------------
backbutton.click (function() {
button.animate({stroke: "#FFFFFF"}, 500), home.animate({fill: "#FFFFFF"}, 500),
setTimeout(gohome, 2000)
});
function gohome(){
history.back()
};
				
//-------------------------------

        };
