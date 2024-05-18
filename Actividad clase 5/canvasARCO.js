function iniciar(){
    var elemento = document.getElementById('lienzo1');
    lienzo1 = elemento.getContext('2d');
    lienzo1.beginPath();
    lienzo1.arc(100,100,50,0,Math.PI*2, false);

    lienzo1.stroke();
}

window.addEventListener("load",iniciar,false);