

$(document).ready(function () {
    clearFields();
    $("#transaction-details-body").html("");
    $("#tbl-transaction-details").hide();
});



function getTransactionDetails() {
    $("#tbl-transaction-details").show();
    var fromDate = $("#fromdate-input").val();
    var toDate = $("#todate-input").val();

    if (fromDate == "" && toDate == "") {
        M.toast({ html: 'Required Fields' });
    } else {
        var url = "/api/Transaction/GetTransactionByDates?FromDate=" + fromDate + "&todate=" + toDate + "";
        $.ajax({
            contentType: 'application/json',
            type: "GET",
            url: url,
            success: function (data) {
                buildTransactionTable(JSON.parse(data.result));
            },
            error: function (jqXHR) {

            }
        });
    }
}


function buildTransactionTable(elements) {

    $("#transaction-details-body").html("");
    var transactionBody = "";

    if (elements.length !== 0) {
        for (var i = 0; i < elements.length; i++) {
            console.log(elements[i]);

            var idnetity = i + 1;
            transactionBody += "<tr>\
                        <td>" + idnetity + "</td>\
                        <td class='person-pic'>"+ elements[i].UniqueInstanceID + "</td>\
                        <td class='person-name'>" + elements[i].EffectiveDate + "</td>\
                        <td class='person-sur-name'>" + elements[i].TransactionCode + "</td>\
                        <td class='person-mobile'>" + elements[i].TransactionAmount + "</td>\
                        <td class='person-email'>" + elements[i].TransactionDate + "</td>\
                        <td class='person-name'>" + elements[i].TransactionTime + "</td>\
                        <td class='person-name'>" + elements[i].ChequeNumber + "</td>\
                         <td class='person-name'>" + elements[i].DrCrIndicator + "</td>\
                        <td class='person-sur-name'>" + elements[i].BankName + "</td>\
                        <td class='person-mobile'>" + elements[i].BranchCode + "</td>\
                        <td class='person-email'>" + elements[i].ReferenceNumber + "</td>\
                        <td class='person-name'>" + elements[i].AccountNumber + "</td>\
                        <td class='person-name'>" + elements[i].Identifier + "</td>\
                        </tr>";
        }
    }
    else {
        transactionBody += "<tr>\
                           <td>No records found</td>\
                          </tr>";
    }


    $("#transaction-details-body").html(transactionBody);

}


function clearFields() {
    $("fromdate-input").val("");
   $("todate-input").val("");
}

function clearTable() {
    $("fromdate-input").val("");
    $("todate-input").val("");
    $("#tbl-transaction-details").hide();
    $("#transaction-details-body").html("");
}

