

function isValidMerchant(country, dateadded) {
    var currentDate = new Date(dateadded);
    if (country.toString() == "France") {
        if ((dateadded > "01/09/" + currentDate.getFullYear()) && (dateadded < "02/25/" + currentDate.getFullYear())) {
            alert("Merchant being added during Jan 10th to Feb 24th can not be added in France");
            $("#DateAdded").val("");
        }
    }
    if (country.toString() == "Spain") {
        if ((dateadded > "02/14/" + currentDate.getFullYear()) && (dateadded < "04/02/" + currentDate.getFullYear())) {
            alert("Merchant being added during Feb 15th to April 1st can not be added in France");
            $("#DateAdded").val("");
        }
    }
}
