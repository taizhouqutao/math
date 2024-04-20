// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function getTest() {
	var selects = getSelect('option1');
	if (!selects.length) {
		alert("请至少选择1课");
		return;
	}
	var ifMany = getSelect('ifMany');
	$("#selectItem").val(selects.join(","));
	$("#selectifMany").val(ifMany.join(","));
	$("#frmReport").submit();
}
function getSelect(selectName) {
	var arr = [];
	$("input[name='" + selectName+ "']:checked").each(function (i) {
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