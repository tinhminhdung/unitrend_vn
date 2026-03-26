$(document).ready(function(){
    $('.tab_content:not(:first)').hide();//ẩn hết tất cả các tab khác nhưng không phải cái đầu tiên
    $('.tabs li a').click(function(){
        $('.tabs li a').removeClass('active'); //xóa bỏ hết các class = active
        //this: là thành phần đang được click
        $(this).addClass('active'); //thêm class active vào đối tượng vừa được click
        $('.tab_content').hide();//ẩn hết nội dung
        
        var activeTab = $(this).attr('href'); //gán giá trị href cho activeTab
        //activeTab = #news// activeTab =#random
        $(activeTab).fadeIn();
        return false; //chỉ hiện thị, thay đổi nội dung - không refesh trang
    });
    
})