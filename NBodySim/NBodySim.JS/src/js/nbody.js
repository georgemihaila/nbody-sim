var ctx;
var canv;

$(window).on('load', function(){
    canv = document.getElementById('sim-canvas');
    ctx = canv.getContext('2d');
    handleResize();
});

$(window).on('resize', handleResize);

function handleResize(){
    var win = $(window); 
    ctx.canvas.width = win.width();
    ctx.canvas.height = win.height();
}

function linearProjection(sourceIntervalMinimum, sourceIntervalMaximum, destinationIntervalMinimum, destinationIntervalMaximum, value) {
    return (value * (destinationIntervalMinimum - destinationIntervalMaximum) + (sourceIntervalMinimum * destinationIntervalMaximum) - (destinationIntervalMinimum * sourceIntervalMaximum)) / (sourceIntervalMinimum - sourceIntervalMaximum);
}