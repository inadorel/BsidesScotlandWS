var ViewModel = function () {
    var self = this;
    self.sponsors = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();

    var sponsorsUri = '/api/sponsors/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllSponsors() {
        ajaxHelper(sponsorsUri, 'GET').done(function (data) {
            self.sponsors(data);
        });
    }

    
    self.getSponsorDetail = function (item) {
        ajaxHelper(sponsorsUri + item.SponsorId, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    // Fetch the initial data.
    getAllSponsors();
};

ko.applyBindings(new ViewModel());