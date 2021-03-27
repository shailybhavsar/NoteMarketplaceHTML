//$(document).ready(function(){
  
// $('.card .collapse').on('shown.bs.collapse',function(){
//     $(this).parent().find('img').attr('src','/Content/images/FAQ/minus.png');
//  $(this).parent().find('.card-header').css('background-color','#fff').css('border-bottom','none');
// });
//    $('.card .collapse').on('hidden.bs.collapse', function () {
//        alert("Hiiii");
//     $(this).parent().find('img').attr('src','/Content/images/FAQ/add.png');
//  $(this).parent().find('.card-header').css('background-color','rgba(0,0,0,.03)').css('border-bottom','1px solid rgba(0,0,0,0.125)');
// });
//});
$(document).ready(function () {

    $(document).on('shown.bs.collapse', '.card .collapse', function () {
        $(this).parent().find('img').attr('src', '/Content/images/FAQ/minus.png');
        $(this).parent().find('.card-header').css('background-color', '#fff').css('border-bottom', 'none');
    });
    $(document).on('hidden.bs.collapse', '.card .collapse', function () {
        $(this).parent().find('img').attr('src', '/Content/images/FAQ/add.png');
        $(this).parent().find('.card-header').css('background-color', 'rgba(0,0,0,.03)').css('border-bottom', '1px solid rgba(0,0,0,0.125)');
    });
});