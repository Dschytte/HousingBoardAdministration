"use strict"
dawaAutocomplete.dawaAutocomplete(document.getElementById("address"), {
    select: function (selected) {
        document.getElementById("chosenAddress").value = selected.tekst;

    }
});