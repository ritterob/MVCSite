const copyright = document.querySelector('#copyright');
const thisYear = new Date().getFullYear();
copyright.innerHTML = `&copy; ${thisYear} aus dem Ritterhaus`;

function ImgMouseOver(traceID) {
    const detailsBox = document.querySelector('#detailsBox');
    const trace = document.querySelector(traceID);
    let content;
    trace.classList.add('trigger');
    detailsBox.textContent = '';
    switch (traceID) {
        case '#game':
            content =
                '<h4>Archaeological Adventure!</h4>' +
                '<p>A dungeon crawler in the style of ' +
                '<a href="https://www.myabandonware.com/game/braminar-2g3" target="_blank">Braminar.</a></p>'+
                '<p>This project uses C# to create a console application. It demonstrates the use of enums, ' +
                'classes, inheritance, polymorphism, interfaces, and unit tests.';
                break;
        case '#store':
        case '#api':
        case '#react':
        case '#schedule':
            content = '<h4>Coming Soon</h4><p>This section is not yet ready. Please pardon our dust.</p>';
            break;
    }
    detailsBox.innerHTML = content;
}

function ImgMouseOut(traceID) {
    const trace = document.querySelector(traceID);
    trace.classList.remove('trigger');
}

function ImgClick(traceID) {
    switch (traceID) {
        case '#game':
            window.location = '/adventure.html';
            break;
        case '#store':
        case '#api':
        case '#react':
        case '#schedule':
            break;
    }
}