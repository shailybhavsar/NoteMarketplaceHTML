var input_var = document.getElementById( 'uplaod-notes' );
var infoArea = document.getElementById( 'upload-notes-filename' );

if (input_var) {
    input_var.addEventListener('change', showFileName);
}

function showFileName( event ) {
    alert("function");
    // the change event gives us the input it occurred in 
    var input_var = event.srcElement;

    // the input has an array of files in the `files` property, each one has a name that you can use. We're just using the name here.
    var fileName = input_var.files[0].name;

    // use fileName however fits your app best, i.e. add it into a div
    infoArea.textContent = 'File name: ' + fileName;
}