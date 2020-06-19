        window.onload = function () {
            var R = Raphael("paper", 1250, 800);
			    var attr = {
                fill: "#707070",
                stroke: "none",
                "stroke-width": 0.0,
                "stroke-linejoin": "round",

            };
           var nematoda = {};
		
nematoda.nematoda0 = R.rect(0,0,0.01,0.01).attr({fill:"#333", stroke: "none"});
nematoda.nematoda0.toBack();
  

nematoda.plathelminthes022 =   R.path("M49.422,569.541L46.265,453.15   c0,0-5.659-2.815-5.251-4.732c0.403-1.907,2.053-2.785,7.581-4.158c5.532-1.364,20.05-2.32,25.522-2.389   c5.475-0.077,9.682-0.539,9.682-0.539s-1.932-7.152-2.201-15.505c-0.274-8.366,1.72-16.946,8.536-18.247   c6.814-1.306,12.431,2.484,13.145,15.354c0.708,12.886-1.507,19.208-1.507,19.208s18.262,1.777,22.424,2.277   c4.154,0.499,11.851,1.169,14.052,2.232c2.208,1.062,4.356,3.416,2.995,4.959c-1.349,1.543-3.63,2.077-3.63,2.077l-3.598,116.411   c0,0,7.073,3.833,6.338,9.278c-0.675,4.979-3.256,9.91-14.443,9.91c-18.211,0-52.675,0-65.982,0c-15.794,0-18.02-3.713-18.757-7.91   c-0.896-5.096,2.385-7.445,4.38-8.959C47.549,570.904,49.422,569.541,49.422,569.541z").attr(attr);



nematoda.nematoda023 =   R.path("M324.683,408.332c0,0,4.938-0.762,4.305-2.674   c-0.628-1.893-3.409-2.626-5.848-3.023c-2.441-0.413-4.574,0.456-4.872-1.131c-0.289-1.578-2.312-3.849-23.63-5.877   c-21.324-2.043-33.898-3.437-33.898-3.437s1.529-3.401,2.417-8.386c0.881-4.989,0.835-22.873-2.206-26.129   c-3.038-3.252-9.568-6.935-13.873-4.261c-4.307,2.665-8.015,8.172-8.381,18.199c-0.366,10.031,2.776,19.869,2.776,19.869   s-6.341,0.708-13.729,1.378c-7.384,0.679-18.968,0.878-28.097,1.175c-9.131,0.286-15.79,0.049-16.881,1.262   c-1.1,1.213-1.1,1.213-1.1,1.213s-5.617,0.111-8.449,0.951c-2.841,0.835-1.878,3.383-0.146,4.072   c1.721,0.688,4.167,1.092,4.167,1.092s1.138,16.67,1.131,26.396c-0.002,9.735,2,50.903,1.956,61.575   c-0.036,10.668,0.425,46.4,0.425,55.554c0,9.206-0.032,20.077-0.032,20.077s-4.994,2.329-5.899,7.939   c-0.91,5.62-0.961,14.56,13.217,14.56c18.604,0,45.524-0.117,68.089-0.117c18.398,0,39.586-0.175,55.815,0   c12.472,0.117,11.577-12.467,10.291-15.637c-1.286-3.192-6.105-7.435-6.105-7.435s0.206-24.779,0.711-38.577   c0.504-13.782,0.633-46.099,0.791-59.892c0.153-13.812,2.962-33.151,3.579-40.354C321.82,419.523,324.683,408.332,324.683,408.332z   ").attr(attr);






 



var box =  R.rect(12,0,1230,620, 1).attr({"fill": "#000000", "stroke": "#707070", "stroke-width": 1});
box.toBack();


//-------------------------------
var textbox =  R.rect(12,620,1230,70, 1).attr({"fill": "#000", "stroke": "#707070", "stroke-width": 1, "opacity": 1})

//-------------------------------


var infobutton = R.set();
var button3 = R.rect(1172,620,70,70, 1).attr({"fill": "#000000", "stroke": "#707070", "stroke-width": 1, "opacity": 1});
infobutton.push(button3);
var info = R.text(1208,655, "i").attr({"fill": "#707070", "stroke": "none", "font-size":"45px", "font-family":"Times New Roman", "font-weight":"bold"});
//-------------------------------
//-------------------------------
var backbutton = R.set();
var button = R.rect(12,620,70,70, 1).attr({"fill": "#000000", "stroke": "#707070", "stroke-width": 1, "opacity": 1});
backbutton.push(button);
var home = R.path("M60.578,42.747h-6.491v15.412H43.22V44.31H32.924v13.85H22.68V42.747h-7.682  l22.568-22.79l9.854,9.758v-5.636h5.937v11.515L60.578,42.747z"
).attr({"fill": "#707070", "stroke": "none", "stroke-width": 3, "opacity": 1});
home.translate(9,613);backbutton.push(home);
//-------------------------------

var refreshbutton = R.set();
var button2 = R.rect(82,620,70,70, 1).attr({"fill": "#000", "stroke": "#FFFFFF", "stroke-width": 1, "opacity": 1});

refreshbutton.push(button2);
//-------------------------------


var curve = R.path("M59.234,26.431c0,0,1.221-0.188,1.064-0.662  c-0.156-0.468-0.844-0.649-1.446-0.748c-0.604-0.102-1.133,0.113-1.206-0.28c-0.072-0.39-0.572-0.952-5.846-1.454  c-5.276-0.505-8.387-0.85-8.387-0.85s0.378-0.842,0.598-2.075c0.217-1.234,0.207-5.659-0.546-6.464  c-0.751-0.805-2.366-1.716-3.432-1.054c-1.066,0.659-1.983,2.022-2.073,4.502c-0.091,2.482,0.687,4.916,0.687,4.916  s-1.569,0.176-3.397,0.341c-1.827,0.168-4.693,0.217-6.952,0.291c-2.259,0.071-3.906,0.012-4.176,0.312  c-0.272,0.3-0.272,0.3-0.272,0.3s-1.389,0.028-2.091,0.235c-0.702,0.207-0.464,0.837-0.036,1.007c0.426,0.17,1.031,0.27,1.031,0.27  s0.281,4.125,0.28,6.531c-0.001,2.409,0.495,12.594,0.484,15.235c-0.01,2.639,0.104,11.48,0.104,13.745  c0,2.278-0.007,4.967-0.007,4.967s-1.235,0.576-1.46,1.964c-0.225,1.391-0.238,3.602,3.271,3.602c4.603,0,11.263-0.029,16.846-0.029  c4.552,0,9.794-0.043,13.81,0c3.086,0.029,2.863-3.084,2.546-3.869c-0.318-0.79-1.511-1.839-1.511-1.839s0.051-6.131,0.176-9.544  c0.125-3.41,0.156-11.406,0.196-14.818c0.037-3.417,0.732-8.202,0.885-9.984C58.525,29.2,59.234,26.431,59.234,26.431").attr({"fill": "#FFFFFF", "stroke": "none", "stroke-width": 3, "opacity": 1});
curve.translate(77,613);refreshbutton.push(curve);
//-------------------------------

infobutton.click (function() {
button2.animate({stroke: "#707070"}, 500), curve.animate({fill: "#707070"}, 500),
button3.animate({stroke: "#FFFFFF"}, 500), info.animate({fill: "#FFFFFF"}, 500),
setTimeout(goinfo, 2000)
});
function goinfo(){
parent.location.href="info.html"
button3.animate({stroke: "#707070"}, 500), info.animate({fill: "#707070"}, 500)
};

//-------------------------------
backbutton.click (function() {
button2.animate({stroke: "#707070"}, 500), curve.animate({fill: "#707070"}, 500),
button.animate({stroke: "#FFFFFF"}, 500), home.animate({fill: "#FFFFFF"}, 500),
setTimeout(gohome, 2000)
});
function gohome(){
history.back()
};
				
//-------------------------------


var current = null;
var start = "nematoda0";
refreshbutton.click (function() {
curve.animate({"fill": "#FFFFFF"}, 500), button2.animate({"stroke": "#FFFFFF"}, 500),
current && nematoda[current].animate({fill: "#707070", stroke: "none"}, 500) && (document.getElementById(current).style.display = ""),
                        R.safari(),
						document.getElementById(start).style.display = "block"
});


            for (var species in nematoda) {

				nematoda[species].color = Raphael.getColor(),
                (function (sp, species) {
                    sp[0].style.cursor = "pointer",
                    sp[0].onclick = function () {
                        current && button2.animate({stroke: "#707070"}, 500) && curve.animate({fill: "#707070"}, 500) && nematoda[current].animate({fill: "#707070", stroke: "none"}, 500) && (document.getElementById(current).style.display = ""),
						(document.getElementById(start).style.display = ""),
                        sp.animate({fill: "#fedfa8", stroke: "#fedfa8"}, 500),
                        sp.toFront(),
                        R.safari(),
                        document.getElementById(species).style.display = "block",
                        current = species
                    };

                    if (species == "nematoda0") {
                        sp[0].onclick();
                    }

                })(nematoda[species], species);
            }
        };
