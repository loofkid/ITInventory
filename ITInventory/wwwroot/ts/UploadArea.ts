var fileList: DataTransfer = new DataTransfer();
var filesDeleted: number = 0;
$(function () {
    $("#receipt-upload").on("dragover", function (e) {
        e.preventDefault();
        $(this).addClass("border-primary");
    });
    $("#receipt-upload").on("dragleave", function () {
        $(this).removeClass("border-primary");
    });
    $("#receipt-upload").on("drop", function (e: JQueryEventObject) {
        e.preventDefault();
        var file = (e.originalEvent as DragEvent).dataTransfer.files[0];
        $(this).removeClass("border-primary");
        fileList.items.add(file);
        ($("#ReceiptFiles")[0] as HTMLInputElement).files = fileList.files;
        addPreview($(this).find(".receipt-preview-list") as JQuery<HTMLUListElement>, file, fileList.files.length - 1);
    })
    $("#ReceiptFiles").change(function () {
        Array.prototype.forEach.call((this as HTMLInputElement).files, function (file: File) {
            fileList.items.add(file);
            addPreview($("#receipt-upload").find(".receipt-preview-list") as JQuery<HTMLUListElement>, file, fileList.files.length - 1);
        });
    });
    $("#receipt-body").click(function () {
        $("#ReceiptFiles").click();
    });
    if ($("#receipt-body").attr("upload-type", "existing-item")) {
        $("#receipt")
    }
});

function addPreview(element: JQuery<HTMLUListElement>, file: File, index: number, existing = false, documentId?: number): void {
    var listItem: HTMLLIElement;
    // Create overall list element
    listItem = <HTMLLIElement>(document.createElement("li"));
    listItem.classList.add("list-group-item", "d-flex", "justify-content-between", "align-items-center");
    listItem.setAttribute("index", index.toString());
    if (existing)
        listItem.setAttribute("documentid", documentId.toString());
    // Create file name span
    let listItemSpan: HTMLSpanElement = <HTMLSpanElement>(document.createElement("span"));
    listItemSpan.innerText = file.name;
    // Create button group span
    let listItemButtonGroupSpan: HTMLSpanElement = <HTMLSpanElement>(document.createElement("span"));
    // Create download button if an existing file
    if (existing) {
        let listItemDownloadButton: HTMLButtonElement = <HTMLButtonElement>(document.createElement("button"));
        listItemDownloadButton.type = "button";
        listItemDownloadButton.classList.add("download", "listItemAction");
        let icon = document.createElement("i");
        icon.classList.add("fa", "fa-download");
        listItemDownloadButton.appendChild(icon);
        listItemButtonGroupSpan.appendChild(listItemDownloadButton);
    }
    // Create remove button
    let listItemRemoveButton: HTMLButtonElement = <HTMLButtonElement>(document.createElement("button"));
    listItemRemoveButton.type = "button";
    listItemRemoveButton.classList.add("close","listItemAction");
    listItemRemoveButton.setAttribute("index", index.toString());
    if (existing)
        listItemRemoveButton.setAttribute("documentid", documentId.toString());
    listItemRemoveButton.setAttribute("aria-label", "remove");
    // Create close icon span
    let listItemButtonIcon: HTMLSpanElement = <HTMLSpanElement>(document.createElement("span"));
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
        var elemIndex: number = parseInt($(this).attr("index"));
        fileList.items.remove(elemIndex);
        ($("#ReceiptFiles")[0] as HTMLInputElement).files = fileList.files;
        $(this).parent("li").detach();
        if (existing) {
        }
    });
}