/*$('#upload-notes').change(function()
{
	var i = $(this).prev('label').clone();
	var file = $('#upload-notes')[0].files[0].name;
	$(this).prev('label').text(file);
});*/

var loadfile = function(event){
	var image = document.getElementById('output');
	image.src = URL.createObjectURL()
}