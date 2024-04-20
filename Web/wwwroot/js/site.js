// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function getTest() {
	var selects = getSelect();
	if (!selects.length) {
		alert("请至少选择1课");
		return;
	}
	$("#selectItem").val(selects.join(","));
	$("#frmReport").submit();
}
function getSelect() {
	var arr = [];	//声明一个数组用来存放遍历出来的checkbox value值
	$("input[name='option1']:checked").each(function (i) {
		arr.push($(this).val());	
	})
	return arr;
}

let all = document.getElementById('checkbox-all');
all.addEventListener('click', () => {
	let books = document.querySelectorAll('.option1');
    books.forEach(book => {
        book.checked = all.checked;
    })
})