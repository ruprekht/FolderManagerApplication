$(document).ready(function(){
    $(".btn-add-folder").click(function () {
        $(".btn-add-folder").attr('value', 'TEST');
        $("#folder-div").slideToggle("slow");
        $(this).toggleClass("active-folder");
        
        return false;
    });
    
    $(".btn-add-file").click(function(){
        $("#file-div").slideToggle("slow");
        $(this).toggleClass("active-file");
        return false;
    });

});