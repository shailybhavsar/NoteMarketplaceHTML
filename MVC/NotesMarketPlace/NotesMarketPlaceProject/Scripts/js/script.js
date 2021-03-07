$(function () {
  showHidenav();
  
  $(window).scroll(function () {

      showHidenav();    
      

  });

  function showHidenav() {


      if ($(window).scrollTop() > 50) {

          //show White navbar
          $("#navbar").addClass("bg-light");
          $("ul.navbar-nav > li > a").css("color","#333");
          
          //dark logo

          $("#top-logo img").attr("src", "../images/home/logo.png");
          $("ul#home-list > li > a > button").css({"background-color":"#6255a5"});
          $("ul#home-list > li > a > button").css({"color":"#fff"});          

      } else {
          $("#navbar").removeClass("bg-light");
          $("ul#home-list > li > a").css("color","#fff");
          // normal logo
          $("#top-logo img").attr("src", "../images/home/top-logo.png");
          $("ul#home-list > li > a > button").css({"background-color":"#fff"});
          $("ul#home-list > li > a > button").css({"color":"#6255a5"});          
      }
  }
});

/*JS when click on the navbar button*/

$(function () {

  $(".navbar-toggler-icon").click(function(){
      $("header").css('background-color', '#6255a5').css('opacity' ,0.6).css('background-image', 'none');
      $("ul#home-list > li > a > button").css({"background-color":"#000"});
      $("ul#home-list > li > a").css({"color":"#000"});
      $("ul#home-list > li > a > button").css({"color":"#fff"});
  });

});


