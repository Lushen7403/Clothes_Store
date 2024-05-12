// Lấy các phần tử DOM
const allDepartments = document.getElementById("all-departments");
const departmentList = document.getElementById("department-list");


// Bắt sự kiện click trên "All departments"
allDepartments.addEventListener("click", function () {
    // Kiểm tra trạng thái hiển thị của danh sách mục con
    if (departmentList.style.display === "none" || departmentList.style.display === "") {
        // Nếu đang ẩn, hiển thị nó
        departmentList.style.display = "block";
    } else {
        // Nếu đang hiển thị, ẩn nó
        departmentList.style.display = "none";
    }
});

const bar = document.getElementById('bar');
const nav = document.getElementById('navbar');
const close = document.getElementById('close');
if (bar) {
    bar.addEventListener('click', () => {
        nav.classList.add('active')
    })
}
if (close) {
    close.addEventListener('click', () => {
        nav.classList.remove('active')
    })
}



// Lấy thẻ cha và thẻ con
var parentListItem = document.querySelector('#dropdown-child');
var childList = document.querySelector('.dropdown');

// Thêm sự kiện click vào thẻ cha
parentListItem.addEventListener('click', function (event) {
    // Ngăn chặn sự kiện mặc định của thẻ <a> để tránh chuyển hướng khi bấm vào "Tài Khoản"
    event.preventDefault();

    // Kiểm tra xem thẻ con có lớp CSS "open" hay không
    if (childList.classList.contains('open')) {
        // Nếu có, loại bỏ lớp "open" để ẩn thẻ con
        childList.classList.remove('open');
    } else {
        // Nếu không, thêm lớp "open" để hiển thị thẻ con
        childList.classList.add('open');
    }
});