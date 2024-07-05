// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function getTest() {
	var selects = getSelect('option1');
	if (!selects.length) {
		alert("请至少选择1课");
		return;
	}
	for(var i=0;i<selects.length;i++){
		if(selects[i]=="5.1" && selects.length > 1){
			alert("因为排版问题，“5.1认识人民币”无法和其他课题混选，如要练习5.1课题，需单独勾选5.1课，请见谅");
			return;
		}
		else if(selects[i]=="5.1.2" && selects.length > 1){
			alert("因为排版问题，“5.1混合运算”无法和其他课题混选，如要练习5.1课题，需单独勾选5.1课，请见谅");
			return;
		}
	}
	var ifMany = getSelect('ifMany');
	var ifKH = getSelect('ifKH');
	$("#selectItem").val(selects.join(","));
	$("#selectifMany").val(ifMany.join(","));
	$("#selectifKH").val(ifKH.join(","));
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