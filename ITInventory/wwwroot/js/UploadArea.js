var fileList = new DataTransfer();
var filesDeleted = 0;
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
    if ($("#receipt-body").attr("upload-type", "existing-item")) {
        $("#receipt");
    }
});
function addPreview(element, file, index, existing = false, documentId) {
    var listItem;
    // Create overall list element
    listItem = (document.createElement("li"));
    listItem.classList.add("list-group-item", "d-flex", "justify-content-between", "align-items-center");
    listItem.setAttribute("index", index.toString());
    if (existing)
        listItem.setAttribute("documentid", documentId.toString());
    // Create file name span
    let listItemSpan = (document.createElement("span"));
    listItemSpan.innerText = file.name;
    // Create button group span
    let listItemButtonGroupSpan = (document.createElement("span"));
    // Create download button if an existing file
    if (existing) {
        let listItemDownloadButton = (document.createElement("button"));
        listItemDownloadButton.type = "button";
        listItemDownloadButton.classList.add("download", "listItemAction");
        let icon = document.createElement("i");
        icon.classList.add("fa", "fa-download");
        listItemDownloadButton.appendChild(icon);
        listItemButtonGroupSpan.appendChild(listItemDownloadButton);
    }
    // Create remove button
    let listItemRemoveButton = (document.createElement("button"));
    listItemRemoveButton.type = "button";
    listItemRemoveButton.classList.add("close", "listItemAction");
    listItemRemoveButton.setAttribute("index", index.toString());
    if (existing)
        listItemRemoveButton.setAttribute("documentid", documentId.toString());
    listItemRemoveButton.setAttribute("aria-label", "remove");
    // Create close icon span
    let listItemButtonIcon = (document.createElement("span"));
    listItemButtonIcon.setAttribute("aria-hidden", "true");
    listItemButtonIcon.innerHTML = "&times;";
    // Add button icon to button element
    listItemRemoveButton.appendChild(listItemButtonIcon);
    // Add title span to li element
    listItem.appendChild(listItemSpan);
    // Add remove button to span element
    listItemButtonGroupSpan.appendChild(listItemRemoveButton);
    // Add button group to li element
    listItem.appendChild(listItemButtonGroupSpan);
    element.append($(listItem));
    // Set up removal routine
    element.find("button[aria-label='remove']").click(function () {
        var elemIndex = parseInt($(this).attr("index"));
        fileList.items.remove(elemIndex);
        $("#ReceiptFiles")[0].files = fileList.files;
        $(this).parent("li").detach();
        if (existing) {
        }
    });
}
//# sourceMappingURL=UploadArea.js.map