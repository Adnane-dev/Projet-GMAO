
 // Form extension method 
 HTMLElement.prototype.serialize = function(elements)
 {
    var obj = {};
    for( var i = 0; i < elements.length; ++i ) {
        var element = elements[i];
        var id = element.id;
        var value = element.value;
        if( id && element.value) {
              obj[id] = value;
        }
    }
    return obj;
}

// Date validation method
function dateFormat(inputFormat) 
{
    if(inputFormat){
        function pad(s) { return (s < 10) ? '0' + s : s; }
        var d = new Date(inputFormat)
        return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('/')
    }
}