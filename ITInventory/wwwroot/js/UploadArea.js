var fileList = new DataTransfer();
$(function () {
    $("#receipt-upload").on("dragover", function (e) {
        e.preventDefault();
        $(this).addClass("border-primary");
    });
    $("#receipt-upload").on("dragleave", function () {
        $(this).removeClass("border-primary");
    });
    $("#receipt-upload").on("drop", function (e) {
        e.preventDefault();
        var file = e.originalEvent.dataTransfer.files[0];
        $(this).removeClass("border-primary");
        fileList.items.add(file);
        $("#ReceiptFiles")[0].files = fileList.files;
        addPreview($(this).find(".receipt-preview-list"), file, fileList.files.length - 1);
    });
    $("#ReceiptFiles").change(function () {
        Array.prototype.forEach.call(this.files, function (file) {
            fileList.items.add(file);
            addPreview($("#receipt-upload").find(".receipt-preview-list"), file, fileList.files.length - 1);
        });
    });
    $("#receipt-body").click(function () {
        $("#ReceiptFiles").click();
    });
});
function addPreview(element, file, index) {
    element.append(function () {
        return '<li class="list-group-item d-flex justify-content-between align-items-center" index=' + index + '><span>' + file.name + '</span><button type="button" class="close" index=' + index + ' aria-label="remove"><span aria-hidden="true">&times;</span></button></li>';
    });
    element.find("button[aria-label='remove']").click(function () {
        var elemIndex = parseInt($(this).attr("index"));
        fileList.items.remove(elemIndex);
        $("#ReceiptFiles")[0].files = fileList.files;
        $(this).parent("li").detach();
    });
}
//# sourceMappingURL=UploadArea.js.map